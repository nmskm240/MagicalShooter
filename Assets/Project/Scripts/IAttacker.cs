namespace Shooting 
{
    public interface IAttacker
    {
        int Power { get; }

        void OnAttacked();
    }
}