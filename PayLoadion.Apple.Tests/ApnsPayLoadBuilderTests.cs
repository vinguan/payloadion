using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayLoadion.Apple.Factories;
using PayLoadion.Apple.PayLoad;
using PayLoadion.Apple.PayLoadBuilder;
using PayLoadion.Apple.Tests.Models;
using PayLoadion.PayLoadBuilder;

namespace PayLoadion.Apple.Tests
{
    [TestClass]
    public class ApnsPayLoadBuilderTests
    {
        [TestMethod]
        public void ShouldBuildSimpleApnsPayLoad()
        {
            try
            {

                IPayLoadBuilder<IApnsPayLoad> apnsPayLoad = ApnsPayLoadBuilderFactory.CreateApnsPayLoadBuilder()
                                                            .Alert("Hello Payloadion")
                                                            .BadgeCount(1);

                var apnsPayLoadString = apnsPayLoad.BuildPayLoadToString();

                Console.WriteLine(apnsPayLoadString);

                Assert.IsNotNull(apnsPayLoadString);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        public async Task ShouldBuildSimpleApnsPayLoadAsync()
        {
            try
            {

                IApnsPayLoadBuilder apnsPayLoad = ApnsPayLoadBuilderFactory.CreateApnsPayLoadBuilder()
                                                  .Alert("Hello Payloadion")
                                                  .BadgeCount(1);

                var apnsPayLoadString = await apnsPayLoad.BuildPayLoadToStringAsync();

                Console.WriteLine(apnsPayLoadString);

                Assert.IsNotNull(apnsPayLoadString);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        public void ShouldBuildApnsPayLoadWithCustomData()
        {
            try
            {

                var apnsPayLoad = ApnsPayLoadBuilderFactory.CreateApnsPayLoadBuilder()
                                                  .Alert("Hello Payloadion")
                                                  .BadgeCount(1)
                                                  .AddCustomData("id", "123")
                                                  .AddCustomData("id2", 12)
                                                  .AddCustomData("customDataObject", new CustomDataObject() { Id = "12" })
                                                  .AddCustomData("load", new { valuex = 1 });

                var apnsPayLoadString = apnsPayLoad.BuildPayLoadToString();

                Console.WriteLine(apnsPayLoadString);

                Assert.IsNotNull(apnsPayLoadString);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        public async Task ShouldBuildApnsPayLoadWithCustomDataAsync()
        {
            try
            {

                var apnsPayLoad = ApnsPayLoadBuilderFactory.CreateApnsPayLoadBuilder()
                                                  .Alert("Hello Payloadion")
                                                  .BadgeCount(1)
                                                  .AddCustomData("id", "123")
                                                  .AddCustomData("id2", 12)
                                                  .AddCustomData("customDataObject", new CustomDataObject() { Id = "12" })
                                                  .AddCustomData("load", new { valuex = 1 });

                var apnsPayLoadString = await apnsPayLoad.BuildPayLoadToStringAsync();

                Console.WriteLine(apnsPayLoadString);

                Assert.IsNotNull(apnsPayLoadString);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        public void ShouldBuildApnsPayLoadWithCustomAlert()
        {
            try
            {
                var apnsPayLoad = ApnsPayLoadBuilderFactory.CreateApnsPayLoadBuilder()
                                                  .Alert()
                                                  .Title("Simple Custom Alert Message")
                                                  .Body("Teste")
                                                  .LaunchImageFileName("sampleimage")
                                                  .BadgeCount(1)
                                                  .SoundName("aperture.caf")
                                                  .IsContentAvailable(true)
                                                  .CategoryIdentifier("Test")
                                                  .AddCustomData("Id", "123")
                                                  .AddCustomData("Id2", 12)
                                                  .AddCustomData("CustomDataObject", new CustomDataObject() { Id = "12" })
                                                  .AddCustomData("Load", new { valuex = 1 });

                var apnsPayLoadString = apnsPayLoad.BuildPayLoadToString();

                Console.WriteLine(apnsPayLoadString);

                Assert.IsNotNull(apnsPayLoadString);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        public async Task ShouldBuildApnsPayLoadWithCustomAlertAsync()
        {
            try
            {
                var apnsPayLoad = ApnsPayLoadBuilderFactory.CreateApnsPayLoadBuilder()
                                                  .Alert()
                                                  .Title("Simple Custom Alert Message")
                                                  .Body("Teste")
                                                  .LaunchImageFileName("sampleimage")
                                                  .BadgeCount(1)
                                                  .SoundName("aperture.caf")
                                                  .IsContentAvailable(true)
                                                  .CategoryIdentifier("Test")
                                                  .AddCustomData("Id", "123")
                                                  .AddCustomData("Id2", 12)
                                                  .AddCustomData("CustomDataObject", new CustomDataObject() { Id = "12" })
                                                  .AddCustomData("Load", new { valuex = 1 });

                var apnsPayLoadString = await apnsPayLoad.BuildPayLoadToStringAsync();

                Console.WriteLine(apnsPayLoadString);

                Assert.IsNotNull(apnsPayLoadString);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        public void ShouldBuildCompleteApnsPayload()
        {
            try
            { 

                var apnsPayLoad = ApnsPayLoadBuilderFactory.CreateApnsPayLoadBuilder()
                                                          .Alert()
                                                          .Title("Simple Custom Alert Message")
                                                          .Body("Teste")
                                                          .TitleLocalizableKey("TitleLocKeyTest")
                                                          .AddTitleLocalizableArgument("TitleLocKeyTestarg1")
                                                          .AddTitleLocalizableArgument("TitleLocKeyTestarg2")
                                                          .LocalizableKey("LocKeyTest")
                                                          .AddLocalizableArgument("LocKeyTestarg1")
                                                          .AddLocalizableArgument("LocKeyTestarg2")
                                                          .ActionLocalizableKey("actionLocKeyTest")
                                                          .LaunchImageFileName("sampleimage")
                                                          .BadgeCount(1)
                                                          .SoundName("aperture.caf")
                                                          .IsContentAvailable(true)
                                                          .CategoryIdentifier("Test")
                                                          .AddCustomData("Id", "123")
                                                          .AddCustomData("Id2", 12)
                                                          .AddCustomData("CustomDataObject", new CustomDataObject() { Id = "12" })
                                                          .AddCustomData("Load", new { valuex = 1 });

                var apnsPayLoadString = apnsPayLoad.BuildPayLoadToString();

                Console.WriteLine(apnsPayLoadString);

                Assert.IsNotNull(apnsPayLoadString);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }

    }
}
