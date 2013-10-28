using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FurnaceRefactored.Business.Tests
{
    /// <summary>
    /// Summary description for ThermostatTests
    /// </summary>
    /// 
    [TestClass]
    public class ThermostatTests
    {
        #region Initialization
        ThermometerServiceMock thermometerMock;
        FurnaceServiceMock furnaceMock;

        Thermostat thermostat;

        // min/max temp params
        int minTemp = 65;
        int maxTemp = 68;
        int temp;

        //// Use TestInitialize to run code before running each test 
        [TestInitialize]
        public void TestInitialize()
        {
            // create mocks 
            thermometerMock = new ThermometerServiceMock();
            furnaceMock = new FurnaceServiceMock();

            // create the instance to be tested
            thermostat = new Thermostat();
        }
        #endregion

        [TestMethod]
        public void TestThermostat_BelowMin_FurnanceOff()
        {
            // Temperature < min, furnace off
            thermometerMock.TempOverride = minTemp - 1;
            furnaceMock.IsOnOverride = false;
            temp = thermostat.Regulate(minTemp, maxTemp, thermometerMock, furnaceMock);

            Assert.AreEqual(true, furnaceMock.IsOn); // verify the furnace was turned on
        }

        [TestMethod]
        public void TestThermostat_BelowMin_FurnaceOn()
        {
            // Temperature < min, furnace on
            thermometerMock.TempOverride = minTemp - 1;
            furnaceMock.IsOnOverride = true;
            temp = thermostat.Regulate(minTemp, maxTemp, thermometerMock, furnaceMock);

            Assert.AreEqual(true, furnaceMock.IsOn); // verify the furnace remains on
        }

        [TestMethod]
        public void TestThermostat_EqualMin_FurnaceOff()
        {
            // Temperature == min, furnace off
            thermometerMock.TempOverride = minTemp;
            furnaceMock.IsOnOverride = false;
            temp = thermostat.Regulate(minTemp, maxTemp, thermometerMock, furnaceMock);

            Assert.AreEqual(false, furnaceMock.IsOn); // verify the furnace remains off
        }

        [TestMethod]
        public void TestThermostat_EqualMin_FurnaceOn()
        {
            // Temperature == min, furnace on
            thermometerMock.TempOverride = minTemp;
            furnaceMock.IsOnOverride = true;
            temp = thermostat.Regulate(minTemp, maxTemp, thermometerMock, furnaceMock);

            Assert.AreEqual(true, furnaceMock.IsOn); // verify the furnace remains on
        }

        [TestMethod]
        public void TestThermostat_BelowMax_FurnaceOff()
        {
            // Temperature < max, furnace off
            thermometerMock.TempOverride = maxTemp - 1;
            furnaceMock.IsOnOverride = false;
            temp = thermostat.Regulate(minTemp, maxTemp, thermometerMock, furnaceMock);

            Assert.AreEqual(false, furnaceMock.IsOn); // verify the furnace remains off
        }

        [TestMethod]
        public void TestThermostat_BelowMax_FurnaceOn()
        {
            // Temperature < max, furnace off
            thermometerMock.TempOverride = maxTemp - 1;
            furnaceMock.IsOnOverride = true;
            temp = thermostat.Regulate(minTemp, maxTemp, thermometerMock, furnaceMock);

            Assert.AreEqual(true, furnaceMock.IsOn); // verify the furnace remains on
        }

        [TestMethod]
        public void TestThermostat_EqualMax_FurnaceOff()
        {
            // Temperature == max, furnace off
            thermometerMock.TempOverride = maxTemp;
            furnaceMock.IsOnOverride = false;
            temp = thermostat.Regulate(minTemp, maxTemp, thermometerMock, furnaceMock);

            Assert.AreEqual(false, furnaceMock.IsOn); // verify the furnace remains off
        }

        [TestMethod]
        public void TestThermostat_EqualMax_FurnaceOn()
        {
            // Temperature == max, furnace on
            thermometerMock.TempOverride = maxTemp;
            furnaceMock.IsOnOverride = true; // <== Bug here, should be "true"
            temp = thermostat.Regulate(minTemp, maxTemp, thermometerMock, furnaceMock);

            Assert.AreEqual(true, furnaceMock.IsOn); // verify the furnace remains on
        }

        [TestMethod]
        public void TestThermostat_AboveMax_FurnaceOff()
        {
            // Temperature > max, furnace off
            thermometerMock.TempOverride = maxTemp + 1;
            furnaceMock.IsOnOverride = false; 
            temp = thermostat.Regulate(minTemp, maxTemp, thermometerMock, furnaceMock);

            Assert.AreEqual(false, furnaceMock.IsOn); // verify the furnace remains off
        }

        [TestMethod]
        public void TestThermostat_AboveMax_FurnaceOn()
        {
            // Temperature > max, furnace on
            thermometerMock.TempOverride = maxTemp + 1;
            furnaceMock.IsOnOverride = true;
            temp = thermostat.Regulate(minTemp, maxTemp, thermometerMock, furnaceMock);

            Assert.AreEqual(false, furnaceMock.IsOn); // verify the furnace turns off
        }

    }
}
