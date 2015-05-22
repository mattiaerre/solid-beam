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

        [SetUp]
        public void Given_A_RatingEngine()
        {
            // info: a container can resolve all these dependencies
            var types = new List<IType> { new Car(), new Van() };
            var manufacturers = new List<IManufacturer> { new Audi(), new Mercedes() };
            var vehicleFactory = new VehicleFactory(types, manufacturers);
            var rule = new BasicRule();

            _engine = new RatingEngine(vehicleFactory, rule);
        }

        // info: not sure if Quote is the right verb to use here
        // see: https://groups.google.com/forum/#!topic/nunit-discuss/TIppykW3V2Y
        // see: http://stackoverflow.com/questions/1165761/decimal-vs-double-which-one-should-i-use-and-when
        [TestCase(VehicleType.Car, VehicleManufacturer.Audi, 1200)]
        [TestCase(VehicleType.Van, VehicleManufacturer.Mercedes, 2000)]
        [TestCase(VehicleType.Car, VehicleManufacturer.Mercedes, 1600)]
        [TestCase(VehicleType.Van, VehicleManufacturer.Audi, 1500)]
        public void It_Should_Be_Able_To_Quote_Based_On_Vehicle_Type_And_Manufacturer(VehicleType vehicleType, VehicleManufacturer vehicleManufacturer, double expected)
        {
            var premium = _engine.Quote(vehicleType, vehicleManufacturer);

            Assert.AreEqual((decimal)expected, premium);
        }
    }
}