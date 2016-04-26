using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayLoadion.Gcm.Factories;
using PayLoadion.Gcm.GcmDownStreamHttpMessage.Message.Enums;

namespace PayLoadion.Google.Tests
{
    [TestClass]
    public class GcmPayLoadBuilderTests
    {
        [TestMethod]
        public void ShouldBuildSimpleGcmPayLoad()
        {
            try
            {
                var gcmPayLoadString = GcmPayLoadBuilderFactory.Create().Notification()
                                       .Title("Message")
                                       .Icon("defaulticon")
                                       .Body("124")
                                       .BodyLocalizableKey("123")
                                       //.AddBodyLocalizableArgument("124")
                                       .TitleLocalizableKey("123")
                                       //.AddTitleLocalizableArgument("123")
                                       .AddCustomData("123","123")
                                       .BuildPayLoadToString(true);
                                 

                Console.WriteLine(gcmPayLoadString);

                Assert.IsNotNull(gcmPayLoadString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void ShouldBuildSimpleGcmDownStremMessage()
        {
            try
            {
                var gcmmessage = GcmDownStreamHttpMessageBuilderFactory.CreateGcmDownStreamHttpJsonMessageBuilder()
                                .AddDeviceId("123")
                                .AddDeviceId("4")
                                .Priority(GcmPriorityEnum.Normal)
                                .TimeToLiveUntil(DateTimeOffset.Now.AddMonths(1))
                                .IsDryRun(true)
                                .PayLoad()
                                .Notification()
                                .Title("Message")
                                .Icon("defaulticon")
                                .AddCustomData("123", "123");


                Console.WriteLine(gcmmessage.BuildGcmDownStreamHttpMessageToJson(true));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                Assert.Fail(ex.Message);
            }
        }


    }
}
