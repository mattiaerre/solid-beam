using NUnit.Framework;
using SolidBeam.Domain.Manufacturers;
using SolidBeam.Domain.Types;

namespace SolidBeam.Domain.Unit.Tests
{
    [TestFixture]
    public class Vehicle_Tests
    {
        private IVehicle _vehicle;

        [SetUp]
        public void Given_A_Vehicle()
        {
            _vehicle = new Vehicle(new Car(), new Audi());
        }

        [Test]
        public void It_Should_Have_A_Type_And_A_Manufacturer()
        {
            Assert.AreEqual(typeof(Car), _vehicle.Type.GetType());
            Assert.AreEqual(typeof(Audi), _vehicle.Manufacturer.GetType());
        }
    }
}