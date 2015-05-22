using System.Collections.Generic;
using System.Linq;
using SolidBeam.Domain.Manufacturers;
using SolidBeam.Domain.Types;

namespace SolidBeam.Domain
{
    public class VehicleFactory : IVehicleFactory
    {
        private readonly IEnumerable<IType> _types;
        private readonly IEnumerable<IManufacturer> _manufacturers;

        public VehicleFactory(IEnumerable<IType> types, IEnumerable<IManufacturer> manufacturers)
        {
            _types = types;
            _manufacturers = manufacturers;
        }

        public IVehicle Make(VehicleType vehicleType, VehicleManufacturer vehicleManufacturer)
        {
            var type = _types.FirstOrDefault(e => e.Name == vehicleType);
            var manufacturer = _manufacturers.FirstOrDefault(e => e.Name == vehicleManufacturer);
            return new Vehicle(type, manufacturer);
        }
    }
}