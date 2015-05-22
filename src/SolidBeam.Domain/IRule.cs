namespace SolidBeam.Domain
{
    public interface IRule
    {
        decimal ComputePremium(IVehicle vehicle);
    }
}