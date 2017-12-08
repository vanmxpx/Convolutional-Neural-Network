using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convolutional.Utils
{
    public struct TSize
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Z { get; private set; }

        public TSize(int x, int y, int z) { X = x; Y = y; Z = z; }

        public TSize(TSize size) : this(size.X, size.Y, size.Z) { }
    }
}
