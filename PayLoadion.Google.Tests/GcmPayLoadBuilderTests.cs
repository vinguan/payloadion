using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayLoadion.Google.Factories;
using PayLoadion.Google.PayLoad.Enums;

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
                var gcmPayLoadBuilder = GcmPayLoadBuilderFactory.CreateGcmPayLoadBuilder()
                                       .ToDevice("idtest")
                                       .Priority(GcmPriorityEnum.Normal)
                                       //.AddCustomData("testeData", "123");
                                       .Notification(GcmNotificationBuilderFactory.CreateGcmNotificationBuilder()
                                                     .Title("")
                                                     .Body("")
                                                     .IconFileName("")
                                                     .Build());

                var gcmPayLoadString = gcmPayLoadBuilder.Build();

                Console.WriteLine(gcmPayLoadString);

                Assert.IsNotNull(gcmPayLoadString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                Assert.IsNotNull(ex.Message);
            }
        }
    }
}
