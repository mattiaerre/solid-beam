namespace SolidBeam.Domain.Types
{
    public class Car : IType
    {
        public VehicleType Name
        {
            get { return VehicleType.Car; }
        }
        public decimal BasePremium
        {
            get { return 800m; }
        }
    }
}