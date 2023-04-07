using System.Collections.Generic;
using System.Numerics;

namespace Paths
{
    public static class PathUtils
    {
        public static void Simplify(Queue<Vector3> des, int length, Vector3[] src)
        {
            if (length < 3)
            {
                for (var i = 0; i < length; i++)
                {
                    des.Enqueue(src[i]);
                }

                return;
            }

            var next = src[1];
            var peek = src[0];
            var direction = next - peek;
            des.Enqueue(peek);
            for (var i = 2; i < length; i++)
            {
                var it = src[i];
                var itDelta = it - peek;
                if (Vector3.Dot(itDelta, direction) != 0 &&
                    Vector3.Multiply(itDelta, direction).LengthSquared() != 0) continue;
                direction = next - peek;
                peek = next;
                next = it;
                des.Enqueue(it);
            }
        }
    }
}