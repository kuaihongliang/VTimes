using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Web;
using Senparc.Weixin.MP.CommonAPIs;
using Senparc.Weixin.Exceptions;
using Senparc.Weixin;

namespace DTcms.Web
{
    public partial class CommonApiTest
    {
        public string _appId = "wxa7bb4da826782600"; 
        public string _appSecret = "3e11cf41247ab74f99da1586b46d5c2e";

        public CommonApiTest()
        {
            //全局只需注册一次
            AccessTokenContainer.Register(_appId, _appSecret);
        }

        [TestMethod]
        public void GetTokenTest()
        {
            var tokenResult = CommonApi.GetToken(_appId, _appSecret);
            Assert.IsNotNull(tokenResult);
            Assert.IsTrue(tokenResult.access_token.Length > 0);
        }

        [TestMethod]
        public void GetTokenFailTest()
        {
            try
            {
                var result = CommonApi.GetToken("appid", "secret");
                Assert.Fail();//上一步就应该已经抛出异常
            }
            catch (ErrorJsonResultException ex)
            {
                //实际返回的信息（错误信息）
                Assert.AreEqual(ex.JsonResult.errcode, ReturnCode_QY.不合法的corpid);
            }
        }
        
    }
}