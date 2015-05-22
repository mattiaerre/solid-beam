namespace SolidBeam.Domain.Manufacturers
{
    public interface IManufacturer
    {
        VehicleManufacturer Name { get; }
        double Factor { get; }
    }
}