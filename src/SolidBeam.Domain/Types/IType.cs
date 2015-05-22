namespace SolidBeam.Domain.Types
{
    public interface IType
    {
        VehicleType Name { get; }
        decimal BasePremium { get; }
    }
}