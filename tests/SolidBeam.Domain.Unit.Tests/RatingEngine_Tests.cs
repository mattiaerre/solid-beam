using NUnit.Framework;
using SolidBeam.Domain.Manufacturers;
using SolidBeam.Domain.Types;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SolidBeam.Domain.Unit.Tests
{
    [TestFixture]
    public class RatingEngine_Tests
    {
        private IRatingEngine _engine;
        private IEnumerable<IType> _types;
        private IEnumerable<IManufacturer> _manufacturers;

        [SetUp]
        public void Given_A_RatingEngine()
        {
            // info: a container can resolve all these dependencies
            _types = new Collection<IType> { new Car(), new Van(), new Supercar() };
            _manufacturers = new Collection<IManufacturer> { new Audi(), new Mercedes(), new Ferrari() };

            var vehicleFactory = new VehicleFactory();
            var rule = new BasicRule();

            _engine = new RatingEngine(vehicleFactory, rule);
        }

        [TestCase("Car", "Audi", 1200)]
        [TestCase("Van", "Mercedes", 2000)]
        [TestCase("Car", "Mercedes", 1600)]
        [TestCase("Van", "Audi", 1500)]
        [TestCase("Supercar", "Ferrari", 5000)]
        [TestCase("Supercar", "Audi", 3000)]
        public void It_Should_Be_Able_To_Quote_Based_On_Vehicle_Type_And_Manufacturer(string typeName, string manufacturerName, double expected)
        {
            var type = _types.FirstOrDefault(e => e.GetType().Name == typeName);
            var manufacturer = _manufacturers.FirstOrDefault(e => e.GetType().Name == manufacturerName);

            var premium = _engine.Quote(type, manufacturer);

            Assert.AreEqual((decimal)expected, premium);
        }
    }
}