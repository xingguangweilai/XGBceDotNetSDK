using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using XGBceDotNetSDK.BaseClass;
using XGBceDotNetSDK.Http;
using XGBceDotNetSDK.Sign;
using XGBceDotNetSDK.Utils;

namespace XGBceDotNetSDK.Sign
{
    /// <summary>
    /// V1版本签名工具
    /// </summary>
    public class XGBceSignerV1 : IXGBceSigner
    {
        private static readonly string TAG = "XGBceSignerV1";
        private string signedHeaders = "";
        private static readonly string BCE_AUTH_VERSION = "bce-auth-v1";
        private static List<string> defaultHeadersToSign= new List<string>() {
            XGBceHeaders.HOST.ToLower(),
            XGBceHeaders.CONTENT_LENGTH.ToLower(),
            XGBceHeaders.CONTENT_TYPE.ToLower(),
            XGBceHeaders.CONTENT_MD5.ToLower()
        };

        private XGBceLog logger = XGBceLog.GetLog();

        /// <summary>
        /// 签名
        /// </summary>
        /// <param name="request"></param>
        /// <param name="credentials"></param>
        public void Sign(XGBceIternalRequest request, XGBceCredentials credentials = null)
        {
            Sign(request, credentials, null);
        }

        /// <summary>
        /// 签名
        /// </summary>
        /// <param name="request"></param>
        /// <param name="credentials"></param>
        /// <param name="options"></param>
        public void Sign(XGBceIternalRequest request, XGBceCredentials credentials = null, BceSignOption options=null)
        {
            if (request == null)
                throw new ArgumentNullException("请求不能为空");

            if (credentials == null)
                return;
            if(options==null)
            {
                if (request.SignOptions != null)
                    options = request.SignOptions;
                else
                    options = BceSignOption.defaultBceSignOption;
            }

            string accessKeyId = credentials.AccessKeyId;
            string secretAccessKey = credentials.SecretKey;

            request.Host = request.Uri.Host;

            if(credentials is XGBceSessionCredentials)
            {
                request.AddMoreHeader(XGBceHeaders.BCE_SECURITY_TOKEN, ((XGBceSessionCredentials)credentials).SessionToken);
            }

            DateTime? timeStamp = options.TimeStamp;
            if (timeStamp == null)
                timeStamp = DateTime.UtcNow;

            //前缀字符串
            string authStringPrefix = BCE_AUTH_VERSION+"/" + accessKeyId + "/" + HttpUtil.FormatUTCTime(timeStamp.Value) + "/" + options.ExpirationPeriodInSeconds.ToString();

            string canonicalURI = GeneralCanonicalURI(request.Uri.AbsolutePath);

            string canonicalHeaders = GeneralCanonicalHeaders(GetHeaderToSign(request.Headers,options.HeadersToSign));

            string canonicalRequest = HttpUtil.BceHttpMethodToString(request.HttpMethod) + "\n"+canonicalURI+"\n"+ GeneralCanonicalQueryString(request.Parameters)+"\n"+canonicalHeaders;

            string signingKey = HMAC_SHA256_HEX(secretAccessKey, authStringPrefix);

            string signature = HMAC_SHA256_HEX(signingKey, canonicalRequest);

            string authorization = authStringPrefix + "/"+signedHeaders+"/"+signature;

            request.AddMoreHeader("Authorization", authorization);

            logger.Debug(TAG, "canonicalURI：" +canonicalURI);
            logger.Debug(TAG, "canonicalHeaders：" + canonicalHeaders);
            logger.Debug(TAG, "signedHeaders：" + signedHeaders);
            logger.Debug(TAG, "canonicalRequest：" + canonicalRequest);
            logger.Debug(TAG, "signingKey：" + signingKey);
            logger.Debug(TAG, "signature：" + signature);
            logger.Debug(TAG, "authorization：" + authorization);
        }

        private Dictionary<string,string> GetHeaderToSign(Dictionary<string,string> headers,List<string> headersToSign)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            if (headersToSign != null)
            {
                List<string> temp = new List<string>();
                foreach (string header in headersToSign)
                {
                    temp.Add(header.Trim().ToLower());
                }
                headersToSign = temp;
            }
            List<string> signedHeaderList = new List<string>();
            foreach (KeyValuePair<string,string> kvp in headers)
            {
                string key = kvp.Key;
                if(!string.IsNullOrEmpty(kvp.Value)&&!string.IsNullOrWhiteSpace(kvp.Value))
                {
                    key = key.Trim().ToLower();
                    if (headersToSign == null)
                    {   //您使用上述推荐范围的Header进行编码，那么认证字符串中的 {signedHeaders} 可以直接留空.
                        if (IsDefaultHeaderToSign(key))
                            result.Add(key, kvp.Value);
                    }
                    else
                    {
                        if(headersToSign.Contains(key.ToLower())&&!XGBceHeaders.AUTHORIZATION.Equals(key, StringComparison.CurrentCultureIgnoreCase))
                        {
                            signedHeaderList.Add(key);  //如果发送的请求里包含推荐的header，出现的header必须签名。
                            result.Add(key, kvp.Value);
                        }
                    }
                }
            }
            signedHeaderList.Sort();
            signedHeaders = string.Join(";",signedHeaderList);
            return result;
        }

        private static bool IsDefaultHeaderToSign(string header)
        {
            header = header.Trim().ToLower();
            return header.StartsWith(XGBceHeaders.BCE_PREFIX) || defaultHeadersToSign.Contains(header);
        }

        private static string GeneralCanonicalURI(string path)
        {
            string canonicalURI = (path ?? "/").Trim();
            canonicalURI = canonicalURI.StartsWith("/") ? canonicalURI : "/" + canonicalURI;
            return HttpUtil.UriEncode(canonicalURI);
        }

        private static string GeneralCanonicalQueryString(Dictionary<string,string> param)
        {
            string canonicalQueryString = "";

            if (param!=null&&param.Count > 0)
            {
                List<string> paraList = new List<string>();
                foreach(KeyValuePair<string,string> kvp in param)
                {
                    paraList.Add(HttpUtil.UriEncode(kvp.Key.Trim())+"="+((!string.IsNullOrEmpty(kvp.Value)&&!string.IsNullOrEmpty(kvp.Value))?HttpUtil.UriEncode(kvp.Value.Trim(),true):""));
                }
                paraList.Sort();

                foreach(string key in paraList)
                {
                    canonicalQueryString += key+"&";
                }
                canonicalQueryString = canonicalQueryString.TrimEnd('&');
            }
            
            return canonicalQueryString;
        }

        private string GeneralCanonicalHeaders(Dictionary<string,string> headers)
        {
            if (headers == null)
                return "";
            List<string> headerList = new List<string>();
            foreach (KeyValuePair<string, string> kvp in headers)
            {
                if (kvp.Key.Trim().Equals(XGBceHeaders.AUTHORIZATION, StringComparison.CurrentCultureIgnoreCase))
                    continue;
                if (string.IsNullOrEmpty(kvp.Value) || string.IsNullOrWhiteSpace(kvp.Value))
                    continue;
                headerList.Add(HttpUtil.UriEncode(kvp.Key.Trim().ToLower()) + ":" + HttpUtil.UriEncode(kvp.Value.Trim(), true));
            }
            headerList.Sort();
            return string.Join("\n", headerList);
        }

        private static string HMAC_SHA256_HEX(string key, string message)
        {
            return Hex(new HMACSHA256(Encoding.UTF8.GetBytes(key)).ComputeHash(Encoding.UTF8.GetBytes(message)));
        }

        private static string Hex(byte[] data)
        {
            var sb = new StringBuilder();
            foreach (var b in data)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }

    }
}
