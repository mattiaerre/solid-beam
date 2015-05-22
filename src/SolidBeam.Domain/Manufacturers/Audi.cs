namespace SolidBeam.Domain.Manufacturers
{
    public class Audi : IManufacturer
    {
        public VehicleManufacturer Name
        {
            get { return VehicleManufacturer.Audi; }
        }
        public double Factor
        {
            get { return 1.5; }
        }
    }
}