using System;

namespace M.Algorithm
{
    public class MAStarx4 : MAStar

    {
        public MAStarx4(int[,] map, int jump, float w) : base(map, 4, jump, w)
        {
        }

        public override int GetEffective(int x, int y)
        {
            var x1 = x + 1;
            var x2 = x - 1;
            var y1 = y + 1;
            var y2 = y - 1;
            var count = 0;

            if (x1 < _width && _map[y, x1] == 0)
            {
                _results[count] = y * _width + x1;
                count++;
            }

            if (x2 >= 0 && _map[y, x2] == 0)
            {
                _results[count] = y * _width + x2;
                count++;
            }

            if (y1 < _height && _map[y1, x] == 0)
            {
                _results[count] = y1 * _width + x;
                count++;
            }

            if (y2 >= 0 && _map[y2, x] == 0)
            {
                _results[count] = y2 * _width + x;
                count++;
            }

            return count;
        }

        public override float ComputeCost(Grid a, Grid b)
        {
            return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
        }

        public override bool ComparePos(Grid a, Grid b)
        {
            return (a.X == b.X && b.X == b.Parent.X) || (a.Y == b.Y && b.Y == b.Parent.Y);
        }
    }
}