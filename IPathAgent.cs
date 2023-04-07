using System.Collections.Generic;
using System.Numerics;

namespace Paths
{
    public interface IPathAgent
    {
        Queue<Vector3> Points { set; }
    }
}