namespace SolidBeam.Domain
{
    public class RatingEngine : IRatingEngine
    {
        public decimal Quote(VehicleType vehicleType, VehicleManufacturer vehicleManufacturer)
        {
            // todo: inject as dictionary
            var basePremium = 0m;
            if (vehicleType == VehicleType.Car)
                basePremium = 800m;
            if (vehicleType == VehicleType.Van)
                basePremium = 1000m;

            // todo: inject as dictionary
            var factor = 0.0;
            if (vehicleManufacturer == VehicleManufacturer.Audi)
                factor = 1.5;
            if (vehicleManufacturer == VehicleManufacturer.Mercedes)
                factor = 2.0;

            // todo: inject as rule
            return basePremium * (decimal)factor;
        }
    }
}