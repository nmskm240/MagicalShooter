namespace MagicalShooter.Characters
{
    public interface IDamageable
    {
        bool CanHit { get; }
        void TakeDamage(int power);
    }
}