using System.Collections.Generic;

namespace Shooting.Motions
{
    public interface IAutoMotion
    {
        float Speed { get; }
        IEnumerable<MotionData> Motions { get; }
    }
}