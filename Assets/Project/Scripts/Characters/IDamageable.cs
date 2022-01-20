namespace Shooting.Characters
{
    public interface IDamageable
    {
        bool CanHit { get; }
        void TakeDamage(int power);
    }
}