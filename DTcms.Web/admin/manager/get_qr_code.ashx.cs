using Senparc.Weixin.MP.AdvancedAPIs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using ThoughtWorks.QRCode.Codec;
using WxPayAPI;

namespace DTcms.Web.admin.manager
{
    /// <summary>
    /// get_qr_code 的摘要说明
    /// </summary>
    public class get_qr_code : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string id = context.Request["id"];
            if (id != null && id != "")
            {
                MemoryStream stream = new MemoryStream();
                ThoughtWorks.QRCode.Codec.QRCodeEncoder encoder = new QRCodeEncoder();
                encoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;//编码方法
                encoder.QRCodeScale = 4;//大小
                encoder.QRCodeVersion = 0;//版本
                encoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
                string data = GetUrl(id);
                System.Drawing.Bitmap image = encoder.Encode(data);
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                context.Response.ClearContent();
                context.Response.ContentType = "image/jpeg";
                context.Response.BinaryWrite(stream.ToArray());
            }
        }

        private string GetUrl(string id)
        {
            string student_id = id;
            string _str = "http://" + "www.59online.com" + "/mobile/student_bind.aspx?id=" + student_id;
            string url = OAuthApi.GetAuthorizeUrl(WxPayConfig.GetConfig().GetAppID(), _str, "state", Senparc.Weixin.MP.OAuthScope.snsapi_userinfo);
            return url;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}