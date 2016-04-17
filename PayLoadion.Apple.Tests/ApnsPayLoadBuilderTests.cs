using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayLoadion.Apple.Factories;
using PayLoadion.Apple.PayLoadBuilder;
using PayLoadion.Apple.Tests.Models;
using PayLoadion.Builder;

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

                IApnsPayLoadBuilder apnsPayLoad = ApnsPayLoadBuilderFactory.CreateApnsPayLoadBuilder()
                                                  .AlertMessage("Hello Payloadion")
                                                  .Badge(1);

                var apnsPayLoadString = apnsPayLoad.Build();

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
                                                  .AlertMessage("Hello Payloadion")
                                                  .Badge(1);

                var apnsPayLoadString = await apnsPayLoad.BuildAsync();

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

                IApnsPayLoadBuilder apnsPayLoad = ApnsPayLoadBuilderFactory.CreateApnsPayLoadBuilder()
                                                  .AlertMessage("Hello Payloadion")
                                                  .Badge(1)
                                                  .AddCustomData("id", "123")
                                                  .AddCustomData("id2", 12)
                                                  .AddCustomData("customDataObject", new CustomDataObject() { Id = "12" })
                                                  .AddCustomData("load", new { valuex = 1 });

                var apnsPayLoadString = apnsPayLoad.Build();

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

                IApnsPayLoadBuilder apnsPayLoad = ApnsPayLoadBuilderFactory.CreateApnsPayLoadBuilder()
                                                  .AlertMessage("Hello Payloadion")
                                                  .Badge(1)
                                                  .AddCustomData("id", "123")
                                                  .AddCustomData("id2", 12)
                                                  .AddCustomData("customDataObject", new CustomDataObject() { Id = "12" })
                                                  .AddCustomData("load", new { valuex = 1 });

                var apnsPayLoadString = await apnsPayLoad.BuildAsync();

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

                var alertBuilder = AlertBuilderFactory.CreateAlertBuilder()
                                  .Title("Simple Custom Alert Message")
                                  .Body("Teste")
                                  .LaunchImageFileName("123");

                var alert = alertBuilder.Build();

                IApnsPayLoadBuilder apnsPayLoad = ApnsPayLoadBuilderFactory.CreateApnsPayLoadBuilder()
                                                  .Alert(alert)
                                                  .Badge(1)
                                                  .SoundName("aperture.caf")
                                                  .CategoryName("Test")
                                                  .IsContentAvailable(true)
                                                  .AddCustomData("Id", "123")
                                                  .AddCustomData("Id2", 12)
                                                  .AddCustomData("CustomDataObject", new CustomDataObject() { Id = "12" })
                                                  .AddCustomData("Load", new { valuex = 1 });

                var apnsPayLoadString = apnsPayLoad.Build();

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

                var alertBuilder = AlertBuilderFactory.CreateAlertBuilder()
                                  .Title("Simple Custom Alert Message")
                                  .Body("Teste")
                                  .TitleLocalizableKey("TitleLocKeyTest")
                                  .AddTitleLocalizableArgument("TitleLocKeyTestarg1")
                                  .AddTitleLocalizableArgument("TitleLocKeyTestarg2")
                                  .ActionLocalizableKey("actionLocKeyTest")
                                  .LocalizableKey("LocKeyTest")
                                  .AddLocalizableArgument("LocKeyTestarg1")
                                  .AddLocalizableArgument("LocKeyTestarg2")
                                  .LaunchImageFileName("123");

                var alert = alertBuilder.Build();

                IApnsPayLoadBuilder apnsPayLoad = ApnsPayLoadBuilderFactory.CreateApnsPayLoadBuilder()
                                                  .Alert(alert)
                                                  .Badge(1)
                                                  .SoundName("aperture.caf")
                                                  .IsContentAvailable(true)
                                                  .CategoryName("Test")
                                                  .AddCustomData("Id", "123")
                                                  .AddCustomData("Id2", 12)
                                                  .AddCustomData("CustomDataObject", new CustomDataObject() { Id = "12" })
                                                  .AddCustomData("Load", new { valuex = 1 });

                var apnsPayLoadString = apnsPayLoad.Build();

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
