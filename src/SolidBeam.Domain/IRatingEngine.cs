using SolidBeam.Domain.Manufacturers;
using SolidBeam.Domain.Types;

namespace SolidBeam.Domain
{
    public interface IRatingEngine
    {
        decimal Quote(VehicleType vehicleType, VehicleManufacturer vehicleManufacturer);
    }
}