using CleanCode.DuplicatedCode;
using NUnit.Framework;
using System;

namespace CleanCode.UnitTests.DuplicatedCode.Tests
{
    [TestFixture]
    class TimeTests
    {
        [Test]
        public void ParseTime_NotNullOrEmpty_ReturnTime()
        {
            //Arrange
            var timeClassObject = new Time(10, 20);
            var expected = new Time(10, 20);

            //Act
            var result = timeClassObject.ParseTime(new AdmisionInformation("10:20"));

            //Arrange
            Assert.AreEqual(result.Hours, expected.Hours);
            Assert.AreEqual(result.Minutes, expected.Minutes);
        }

        [Test]
        public void ParseTime_IsNull_ReturnObjectTime()
        {
            //Arrange
            var timeClassObject = new Time(10, 20);
            var admisionInformation = new AdmisionInformation(null);

            //Act - Assert
            Assert.That(() => timeClassObject.ParseTime(admisionInformation), Throws.InstanceOf<ArgumentNullException>());
        }

    }
}
