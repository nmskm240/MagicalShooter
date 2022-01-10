using System.Collections.Generic;
using DG.Tweening;

namespace Shooting.Motions
{
    public interface IAutoMotion
    {
        float Speed { get; }
        IEnumerable<MotionData> Motions { get; }
        Sequence NowMotion { get; set; }
    }
}