namespace SolidBeam.Domain
{
    public interface IRatingEngine
    {
        decimal Quote(VehicleType vehicleType, VehicleManufacturer vehicleManufacturer);
    }
}