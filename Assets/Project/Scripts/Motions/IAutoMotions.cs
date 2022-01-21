using System.Collections.Generic;
using DG.Tweening;

namespace MagicalShooter.Motions
{
    public interface IAutoMotion
    {
        float Speed { get; }
        IEnumerable<MotionData> Motions { get; }
        Sequence NowMotion { get; set; }
    }
}