namespace SolidBeam.Domain.Types
{
    public class Van : IType
    {
        public VehicleType Name
        {
            get { return VehicleType.Van; }
        }
        public decimal BasePremium
        {
            get { return 1000m; }
        }
    }
}