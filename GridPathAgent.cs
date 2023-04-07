using System;
using System.Collections.Generic;
using System.Numerics;

namespace Paths
{
    public class GridPathAgent : IPathAgent
    {
        private Queue<Vector3> _points;

        public Queue<Vector3> Points
        {
            set => _points = value;
        }

        private static float Step(float delta, float destination, float destinationDelta, ref float position)
        {
            if (destinationDelta < delta)
            {
                position = destination;
                return destinationDelta;
            }

            position += delta;
            return delta;
        }

        public bool Step(float delta, ref Vector3 position)
        {
            while (delta > 0 && _points.TryPeek(out var point))
            {
                var pointDelta = point - position;
                if (Math.Abs(pointDelta.X) > 0)
                {
                    delta -= Step(delta, point.X, pointDelta.X, ref position.X);
                    continue;
                }
                if (Math.Abs(pointDelta.Z) > 0)
                {
                    delta -= Step(delta, point.Z, pointDelta.Z, ref position.Z);
                    continue;
                }
            }

            return false;
        }
    }
}