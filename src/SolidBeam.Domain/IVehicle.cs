using SolidBeam.Domain.Manufacturers;
using SolidBeam.Domain.Types;

namespace SolidBeam.Domain
{
    public interface IVehicle
    {
        IType Type { get; }
        IManufacturer Manufacturer { get; }
    }
}