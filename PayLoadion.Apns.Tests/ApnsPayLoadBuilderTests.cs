using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayLoadion.Apns.Factories;
using PayLoadion.Apns.PayLoad;
using PayLoadion.Apns.PayLoadBuilder;
using PayLoadion.Apple.Tests.Models;
using PayLoadion.PayLoadBuilder;
using PayLoadion.Apple.Tests;

namespace PayLoadion.Apple.Tests
{
    [TestClass]
    public class ApnsPayLoadBuilderTests
    {
        [TestMethod]
        public void ShouldTestsforGitHub()
        {
            try
            {
                var apnsPayLoadString = ApnsPayLoadBuilderFactory.CreateApnsPayLoadBuilder()
                                                            .Alert()
                                                            .Title("Hello Payloadion.Apns")
                                                            .Body("Hello Payloadion.Apns Body")
                                                            .AddCustomData("NewsId", "123")
                                                            .BuildPayLoadToString(true);

                Console.WriteLine(apnsPayLoadString);

                Assert.IsNotNull(apnsPayLoadString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void ShouldBuildSimpleApnsPayLoad()
        {
            try
            {

                var apnsPayLoadString = ApnsPayLoadBuilderFactory.CreateApnsPayLoadBuilder().Alert("Simple Message").BuildPayLoadToString(true);

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

                IPayLoadBuilder<IApnsPayLoad> apnsPayLoad = ApnsPayLoadBuilderFactory.CreateApnsPayLoadBuilder()
                                                  .Alert("Hello Payloadion")
                                                  .Badge(1);

                var apnsPayLoadString = await apnsPayLoad.BuildPayLoadToStringAsync(true);

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
                    .Badge(1)
                    .AddCustomData("id", "123")
                    .AddCustomData("id2", 12)
                    .AddCustomData("customDataObject", new CustomDataObject() {Id = "12"})
                    .AddCustomData("load", new {valuex = 1});

                var apnsPayLoadString = apnsPayLoad.BuildPayLoadToString(true);

                Console.WriteLine(apnsPayLoadString);

                Assert.IsNotNull(apnsPayLoadString);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }


        [TestMethod]
        public void ShouldBuildApnsPayLoadWithMultipleCustomDataAtOnce()
        {
            try
            {

                var customData = new Dictionary<string, object> { { "id", "123" }, { "foobarId", 12 } };

                var apnsPayLoad = ApnsPayLoadBuilderFactory.CreateApnsPayLoadBuilder()
                                                                        .Alert("Hello Payloadion")
                                                                        .Badge(1)
                                                                        .AddCustomData(customData);

                var apnsPayLoadString = apnsPayLoad.BuildPayLoadToString(true);

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
                                                  .Badge(1)
                                                  .AddCustomData("id", "123")
                                                  .AddCustomData("id2", 12)
                                                  .AddCustomData("customDataObject", new CustomDataObject() { Id = "12" })
                                                  .AddCustomData("load", new { valuex = 1 });

                var apnsPayLoadString = await apnsPayLoad.BuildPayLoadToStringAsync(true);

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
                                                  .Sound("default")
                                                  .IsContentAvailable(true)
                                                  .Category("Test")
                                                  .AddCustomData("Id", "123")
                                                  .AddCustomData("Id2", 12)
                                                  .AddCustomData("CustomDataObject", new CustomDataObject() { Id = "12" })
                                                  .AddCustomData("Load", new { valuex = 1 });

                var apnsPayLoadString = apnsPayLoad.BuildPayLoadToString(true);

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
                                                  .Badge(1)
                                                  .Sound("aperture.caf")
                                                  .IsContentAvailable(true)
                                                  .Category("Test")
                                                  .AddCustomData("Id", "123")
                                                  .AddCustomData("Id2", 12)
                                                  .AddCustomData("CustomDataObject", new CustomDataObject() { Id = "12" })
                                                  .AddCustomData("Load", new { valuex = 1 });

                var apnsPayLoadString = await apnsPayLoad.BuildPayLoadToStringAsync(true);

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
                                                          .Badge(1)
                                                          .Sound("aperture.caf")
                                                          .IsContentAvailable(true)
                                                          .Category("Test")
                                                          .AddCustomData("Id", "123")
                                                          .AddCustomData("Id2", 12)
                                                          .AddCustomData("CustomDataObject", new CustomDataObject() { Id = "12" })
                                                          .AddCustomData("Load", new { valuex = 1 });

                var apnsPayLoadString = apnsPayLoad.BuildPayLoadToString(true);

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
