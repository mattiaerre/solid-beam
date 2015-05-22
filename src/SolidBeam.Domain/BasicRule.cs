namespace SolidBeam.Domain
{
    public class BasicRule : IRule
    {
        public decimal ComputePremium(IVehicle vehicle)
        {
            return vehicle.Type.BasePremium * (decimal)vehicle.Manufacturer.Factor;
        }
    }
}