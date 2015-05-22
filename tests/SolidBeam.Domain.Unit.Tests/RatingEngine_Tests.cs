using System.Collections.ObjectModel;
using System.Linq;
using NUnit.Framework;
using SolidBeam.Domain.Manufacturers;
using SolidBeam.Domain.Types;
using System.Collections.Generic;

namespace SolidBeam.Domain.Unit.Tests
{
    [TestFixture]
    public class RatingEngine_Tests
    {
        // todo: enum into interfaces
        // todo: inject the rule into engine
        // todo: VehicleType repository
        // todo: VehicleManufacturer repository
        // todo: Vehicle factory

        // todo: RatingEngine has got IVehicleFactory and IRule as dependencies
        // todo: VehicleFactory has got IVehicleTypeRepository and IVehicleManufacturer as dependencies
        // todo: _factory.Make(type, manufacturer) ==> IVehicle
        // todo: _rule.CalculatePremium(vehicle)

        private IRatingEngine _engine;
        private IEnumerable<IType> _types;
        private IEnumerable<IManufacturer> _manufacturers;

        [SetUp]
        public void Given_A_RatingEngine()
        {
            // info: a container can resolve all these dependencies
            _types = new Collection<IType> { new Car(), new Van() };
            _manufacturers = new Collection<IManufacturer> { new Audi(), new Mercedes() };
            
            var vehicleFactory = new VehicleFactory();
            var rule = new BasicRule();

            _engine = new RatingEngine(vehicleFactory, rule);
        }

        // info: not sure if Quote is the right verb to use here
        // see: https://groups.google.com/forum/#!topic/nunit-discuss/TIppykW3V2Y
        // see: http://stackoverflow.com/questions/1165761/decimal-vs-double-which-one-should-i-use-and-when
        [TestCase("Car", "Audi", 1200)]
        [TestCase("Van", "Mercedes", 2000)]
        [TestCase("Car", "Mercedes", 1600)]
        [TestCase("Van", "Audi", 1500)]
        public void It_Should_Be_Able_To_Quote_Based_On_Vehicle_Type_And_Manufacturer(string typeName, string manufacturerName, double expected)
        {
            var type = _types.FirstOrDefault(e => e.GetType().Name == typeName);
            var manufacturer = _manufacturers.FirstOrDefault(e => e.GetType().Name == manufacturerName);

            var premium = _engine.Quote(type, manufacturer);

            Assert.AreEqual((decimal)expected, premium);
        }
    }
}