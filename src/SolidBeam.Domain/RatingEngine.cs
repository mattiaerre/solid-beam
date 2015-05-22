using SolidBeam.Domain.Manufacturers;
using SolidBeam.Domain.Types;

namespace SolidBeam.Domain
{
    public class RatingEngine : IRatingEngine
    {
        private readonly IVehicleFactory _vehicleFactory;
        private readonly IRule _rule;

        public RatingEngine(IVehicleFactory vehicleFactory, IRule rule)
        {
            _vehicleFactory = vehicleFactory;
            _rule = rule;
        }

        public decimal Quote(VehicleType vehicleType, VehicleManufacturer vehicleManufacturer)
        {
            var vehicle = _vehicleFactory.Make(vehicleType, vehicleManufacturer);
            return _rule.ComputePremium(vehicle);
        }
    }
}