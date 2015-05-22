using SolidBeam.Domain.Manufacturers;
using SolidBeam.Domain.Types;

namespace SolidBeam.Domain
{
    public class VehicleFactory : IVehicleFactory
    {
        public IVehicle Make(IType type, IManufacturer manufacturer)
        {
            return new Vehicle(type, manufacturer);
        }
    }
}