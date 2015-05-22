namespace SolidBeam.Domain.Manufacturers
{
    public class Mercedes : IManufacturer
    {
        public VehicleManufacturer Name
        {
            get { return VehicleManufacturer.Mercedes; }
        }
        public double Factor
        {
            get { return 2.0; }
        }
    }
}