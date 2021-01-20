using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Http;

namespace DTcms.Web.mobile
{
    /// <summary>
    /// sendSMS 的摘要说明
    /// </summary>
    public class sendSMS : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["phone"]))
            {
                string phone_num = HttpContext.Current.Request.QueryString["phone"].ToString();
                senSMS(phone_num, build_code(phone_num));
            }
        }

        private void senSMS(string mobile_phone_num, string verification_code)
        {
            IClientProfile profile = DefaultProfile.GetProfile("cn-hangzhou", "LTAI4FtZoCWx7m9dRkZDGU6y", "8pfL5CgBOrkz3YFn7g0fgBUDh92mRu");
            DefaultAcsClient client = new DefaultAcsClient(profile);
            CommonRequest request = new CommonRequest();
            request.Method = MethodType.POST;
            request.Domain = "dysmsapi.aliyuncs.com";
            request.Version = "2017-05-25";
            request.Action = "SendSms";
            //request.Protocol = ProtocolType.HTTP;
            request.AddQueryParameters("PhoneNumbers", mobile_phone_num);
            request.AddQueryParameters("SignName", "绿徒体育");
            request.AddQueryParameters("TemplateCode", "SMS_181785136");
            request.AddQueryParameters("TemplateParam", "{\"code\":\"" + verification_code + "\"}");
            try
            {
                CommonResponse response = client.GetCommonResponse(request);
                Console.WriteLine(System.Text.Encoding.Default.GetString(response.HttpResponse.Content));
            }
            catch (ServerException e)
            {
                Console.WriteLine(e);
            }
            catch (ClientException e)
            {
                Console.WriteLine(e);
            }
        }

        private string build_code(string phone_num)
        {
            Random random = new Random();
            int code = random.Next(100000, 999999);
            string _str = code.ToString();
            string sql = "insert into action_code values('" + code + "',DATEADD(minute,15,GETDATE()),'" + phone_num + "')";
            DBUtility.DbHelperSQL.ExecuteSql(sql);
            return _str;
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