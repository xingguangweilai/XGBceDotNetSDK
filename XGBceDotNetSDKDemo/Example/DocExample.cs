using System;
using XGBceDotNetSDK.BaseClass;
using XGBceDotNetSDK.Services.DOC;
using XGBceDotNetSDK.Services.DOC.Model;
using XGBceDotNetSDK.Sign;

namespace XGBceDotNetSDKDemo.Example
{
    public class DocExample
    {
        private static string access_key_id = @"";
        private static string secret_access_key = @"";
        public DocExample()
        {
            Console.WriteLine("DocExample!");
            XGBceClientConfiguration bceClientConfiguration = new XGBceClientConfiguration()
            {
                Credentials = new DefaultBceCredentials(access_key_id, secret_access_key),
            };

            XGDocClient docClient = new XGDocClient(bceClientConfiguration);

            RegisterDocument(docClient);
            //PublishDocument(docClient);
            //QueryDocument(docClient);
            //ListDocumentImages(docClient);
            //DeleteDocument(docClient);
        }

        /// <summary>
        /// 根据BOS Object创建文档
        /// </summary>
        /// <param name="docClient"></param>
        public void RegisterDocument(XGDocClient docClient)
        {
            try
            {
                XGDocRegisterBosDocumentResponse registerBosDocumentResponse = docClient.RegisterBosDocument("", "图解HTTP.epub", "图解HTTP",XGDocFileFormat.epub);
                Console.WriteLine("注册BOS文档成功：\n"+registerBosDocumentResponse);
                //doc-mm3w9266w4c9t7f
            }
            catch (Exception ex)
            {
                Console.WriteLine("注册BOS文档失败：\n"+ex.Message);
            }
        }

        /// <summary>
        /// 发布文档
        /// </summary>
        /// <param name="docClient"></param>
        public void PublishDocument(XGDocClient docClient)
        {
            try
            {
                docClient.PublishDocument("doc-mm3w9266w4c9t7f");
                Console.WriteLine("发布文档成功\n");
                //doc-mm3w9266w4c9t7
            }
            catch (Exception ex)
            {
                Console.WriteLine("发布文档失败：\n" + ex.Message);
            }
        }

        /// <summary>
        /// 查询文档
        /// </summary>
        /// <param name="docClient"></param>
        public void QueryDocument(XGDocClient docClient)
        {
            try
            {
                XGDocQueryDocumentResponse queryDocumentResponse = docClient.QueryDocument("doc-mm3w9266w4c9t7f");
                Console.WriteLine("查询文档成功：\n" + queryDocumentResponse);
            }
            catch (Exception ex)
            {
                Console.WriteLine("查询文档失败：\n" + ex.Message);
            }
        }

        /// <summary>
        /// 文档列表
        /// </summary>
        /// <param name="docClient"></param>
        public void ListDocuments(XGDocClient docClient)
        {
            try
            {
                XGDocListDocumentsResponse listDocumentImagesRequest = docClient.ListDocuments();
                Console.WriteLine("列举文档成功：\n" + listDocumentImagesRequest);
            }
            catch (Exception ex)
            {
                Console.WriteLine("列举文档失败：\n" + ex.Message);
            }
        }

        /// <summary>
        /// 查询文档转码结果图片列表
        /// </summary>
        /// <param name="docClient"></param>
        public void ListDocumentImages(XGDocClient docClient)
        {
            try
            {
                XGDocListDocumentImagesResponse listDocumentImagesResponse = docClient.ListDocumentImages("doc-mm3w9266w4c9t7f");
                Console.WriteLine("查询文档转码结果图片列表成功：\n" + listDocumentImagesResponse);
            }
            catch (Exception ex)
            {
                Console.WriteLine("查询文档转码结果图片列表失败：\n" + ex.Message);
            }
        }

        /// <summary>
        /// 删除文档
        /// </summary>
        /// <param name="docClient"></param>
        public void DeleteDocument(XGDocClient docClient)
        {
            try
            {
                docClient.DeleteDocument("doc-mm3w9266w4c9t7f");
                Console.WriteLine("删除文档成功：\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("删除文档失败：\n" + ex.Message);
            }
        }
    }
}
