using SolidBeam.Domain.Manufacturers;
using SolidBeam.Domain.Types;

namespace SolidBeam.Domain
{
    public class Vehicle : IVehicle
    {
        public IType Type { get; private set; }
        public IManufacturer Manufacturer { get; private set; }

        public Vehicle(IType type, IManufacturer manufacturer)
        {
            Manufacturer = manufacturer;
            Type = type;
        }
    }
}