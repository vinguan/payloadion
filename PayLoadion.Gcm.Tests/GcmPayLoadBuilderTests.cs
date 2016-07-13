using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayLoadion.Gcm.Factories;
using PayLoadion.Gcm.GcmDownStreamHttpMessage.Message.Enums;

namespace PayLoadion.Gcm.Tests
{
    [TestClass]
    public class GcmPayLoadBuilderTests
    {
        [TestMethod]
        public void ShouldTestsforGitHub()
        {
            try
            {
                var gcmDownStreamHttpMessage = GcmDownStreamHttpMessageBuilderFactory.CreateGcmDownStreamHttpMessageBuilder()
                                                                                     .AddDeviceId("GcmDeviceUniqueId1")
                                                                                     .AddDeviceId("GcmDeviceUniqueId2")
                                                                                     .AddDeviceId("GcmDeviceUniqueId3")
                                                                                     .Priority(GcmPriorityEnum.Normal)
                                                                                     .TimeToLiveUntil(DateTimeOffset.Now.AddMonths(1))
                                                                                     .IsDryRun(true)
                                                                                     .PayLoad()
                                                                                     .Notification()
                                                                                     .Title("Hello Payloadion.GCM")
                                                                                     .Icon("DefaultIcon")
                                                                                     .AddCustomData("NewsId", 11)
                                                                                     .BuildGcmDownStreamHttpMessageToJson(true);
                Console.WriteLine(gcmDownStreamHttpMessage);

                Assert.IsNotNull(gcmDownStreamHttpMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void ShouldBuildSimpleGcmPayLoad()
        {
            try
            {
                var gcmPayLoadString = GcmPayLoadBuilderFactory.CreateGcmPayLoadBuilder().Notification()
                                       .Title("Message")
                                       .Icon("defaulticon")
                                       .Body("124")
                                       .BodyLocalizableKey("123")
                                       .AddBodyLocalizableArgument("124")
                                       .TitleLocalizableKey("123")
                                       .AddTitleLocalizableArgument("123")
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
        public void ShouldBuildSimpleGcmDownStreamMessage()
        {
            try
            {
                var gcmmessage = GcmDownStreamHttpMessageBuilderFactory.CreateGcmDownStreamHttpMessageBuilder()
                                .ToDevice("123")
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

        [TestMethod]
        public void ShouldBuildSimpleGcmDownStreamMessageToMultipleTargets()
        {
            try
            {
                var gcmmessage = GcmDownStreamHttpMessageBuilderFactory.CreateGcmDownStreamHttpMessageBuilder()
                                .AddDeviceId("123")
                                .AddDeviceId("125")
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
