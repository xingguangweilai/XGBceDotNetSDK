using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using XGBceDotNetSDK.Sign;
using XGBceDotNetSDK.Utils;

namespace XGBceDotNetSDK.Sign
{
    public class XGBceSignerV1 : XGBceSigner
    {
        /// <summary>
        /// 默认需要签名的请求头
        /// </summary>
        private readonly List<string> headerSignList = new List<string>(){@"Host", @"Content-Type", @"Content-Length", @"Content-MD5" };
        private string signedHeaders = "";
        public void Sign(XGBceIternalRequest request)
        {
            //前缀字符串
            string authStringPrefix = "bce-auth-v1/" + request.Credentials.AccessKeyId + "/" + HttpUtil.FormatUTCTime(request.SignOptions.TimeStamp) + "/" + request.SignOptions.ExpirationPeriodInSeconds;

            string canonicalURI = GeneralCanonicalURI(request.Uri.AbsolutePath);

            string canonicalHeaders = GeneralCanonicalHeaders(request.GetIternalHeaders());

            string canonicalRequest = HttpUtil.BceHttpMethodToString(request.HttpMethod) + "\n"+canonicalURI+"\n"+GeneralCanonicalQueryString(request.QueryParams)+"\n"+canonicalHeaders;

            string signingKey = HMAC_SHA256_HEX(request.Credentials.SecretKey,authStringPrefix);

            string signature = HMAC_SHA256_HEX(signingKey, canonicalRequest);

            string authorization = authStringPrefix+ "/"+signedHeaders+"/"+signature;

            request.Headers.Add("Authorization",authorization);

            Console.WriteLine("canonicalURI："+canonicalURI);
            Console.WriteLine("canonicalHeaders：" + canonicalHeaders);
            Console.WriteLine("signedHeaders：" + signedHeaders);
            Console.WriteLine("canonicalRequest：" + canonicalRequest);
            Console.WriteLine("signingKey：" + signingKey);
            Console.WriteLine("signature：" + signature);
            Console.WriteLine("authorization：" + authorization);
        }

        

        private string GeneralCanonicalURI(string path)
        {
            string canonicalURI = (path ?? "/").Trim();
            canonicalURI = canonicalURI.StartsWith("/") ? canonicalURI : "/" + canonicalURI;
            return HttpUtil.UriEncode(canonicalURI);
        }

        private string GeneralCanonicalQueryString(Dictionary<string,string> param)
        {
            string canonicalQueryString = "";

            if (param!=null&&param.Count > 0)
            {
                List<string> paraList = new List<string>();
                foreach(KeyValuePair<string,string> kvp in param)
                {
                    paraList.Add(HttpUtil.UriEncode(kvp.Key.Trim().ToLower())+"="+(kvp.Value.Trim().Length>0?HttpUtil.UriEncode(kvp.Value.Trim(),true):""));
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
            string canonicalHeaders = "";
            signedHeaders = "";

            List<string> signedHeaderList = new List<string>();

            if (headers != null && headers.Count > 0)
            {
                List<string> headerList = new List<string>();
                foreach (KeyValuePair<string, string> kvp in headers)
                {
                    if (kvp.Key.Trim().ToLower() == "authorization")
                        continue;
                    headerList.Add(HttpUtil.UriEncode(kvp.Key.Trim().ToLower()) + ":" + (kvp.Value.Trim().Length > 0 ? HttpUtil.UriEncode(kvp.Value.Trim(), true) : ""));
                    signedHeaderList.Add(HttpUtil.UriEncode(kvp.Key.Trim().ToLower()));
                }
                headerList.Sort();
                signedHeaderList.Sort();

                foreach (string key in headerList)
                {
                    canonicalHeaders += key + "\n";
                }
                canonicalHeaders = canonicalHeaders.TrimEnd('\n');

                foreach (string signedStr in signedHeaderList)
                {
                    signedHeaders += signedStr + ";";
                }
                signedHeaders = signedHeaders.TrimEnd(';');
            }


            return canonicalHeaders;
        }

        //private bool IsDefaultHeader(string header)
        //{
        //    header = header.Trim().ToLower();
        //    return header.StartsWith("x-bce-") || defaultHeader.Contains(header);
        //}

        //private void DefaultHeader(Dictionary<string,string> headers)
        //{
        //    if (!headers.Keys.OfType<string>().Any(k => string.Equals(k, @"Content-Type", StringComparison.InvariantCultureIgnoreCase)))
        //        headers.Add(@"Content-Type",@"application/json");
        //}

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
