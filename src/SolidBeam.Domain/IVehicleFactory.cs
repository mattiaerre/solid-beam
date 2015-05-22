using SolidBeam.Domain.Manufacturers;
using SolidBeam.Domain.Types;

namespace SolidBeam.Domain
{
    public interface IVehicleFactory
    {
        IVehicle Make(IType type, IManufacturer manufacturer);
    }
}