namespace SolidBeam.Web
{
    public interface IFactory<out T>
    {
        T Make();
    }
}