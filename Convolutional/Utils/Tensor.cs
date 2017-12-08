using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Threading.Tasks;

namespace Convolutional.Utils
{
    public class Tensor<T>
    {
        private double[] _data;
        public TSize _size;

        private double[] Data => _data;
        public TSize Size => Size;

        public Tensor(int x, int y, int z)
        {
            _data = new double[x * y * z];
            _size = new TSize(x, y, z);
        }

        public Tensor(TSize size)
        {
            _data = new double[size.X * size.Y * size.Z];
            _size = size;
        }

        public Tensor(Tensor<T> tensor)
        {
            _data = tensor.Data;
            _size = tensor.Size;
        }
        public void Copy(double[][][] data)
        {
            int z = data.Length;
            int y = data[0].Length;
            int x = data[0][0].Length;

            for (int i = 0; i < x; i++)
                for (int j = 0; j < y; j++)
                    for (int k = 0; k < z; k++)
                        this[i, j, k] = data[k][j][i];
        }

        public static Tensor<T> ToTensor(double[][][] data)
        {

            int z = data.Length;
            int y = data[0].Length;
            int x = data[0][0].Length;
            Tensor<T> tmp = new Tensor<T>(x, y, x);
            tmp.Copy(data);
            return tmp;
        }

        public static Tensor<T> operator +(Tensor<T> obj1, Tensor<T> obj2)
        {
            if (obj1.Data.Length != obj2.Data.Length)
                throw new ArgumentOutOfRangeException("Sizes of tensors are not equals.");
            Tensor<T> tmp = new Tensor<T>(obj1);
            for (int i = 0; i < tmp.Data.Length; i++)
                tmp.Data[i] += obj2.Data[i];
            return tmp;
        }

        public static Tensor<T> operator -(Tensor<T> obj1, Tensor<T> obj2)
        {
            if (obj1.Data.Length != obj2.Data.Length)
                throw new ArgumentOutOfRangeException("Sizes of tensors are not equals.");
            Tensor<T> tmp = new Tensor<T>(obj1);
            for (int i = 0; i < tmp.Data.Length; i++)
                tmp.Data[i] -= obj2.Data[i];
            return tmp;
        }

        public double this[int x, int y, int z]
        {
            get
            {
                if (x < 0 || y < 0 || z < 0)
                    throw new ArgumentOutOfRangeException("Index cannot be less then zero.");
                if (x >= _size.X && y >= _size.Y && z >= _size.Z)
                    throw new ArgumentOutOfRangeException("Index cannot be larger then data size.");

                return _data[z * (_size.X * _size.Y) + y * (_size.X) + x];
            }

            set
            {
                if (x < 0 || y < 0 || z < 0)
                    throw new ArgumentOutOfRangeException("Index cannot be less then zero.");
                if (x >= _size.X && y >= _size.Y && z >= _size.Z)
                    throw new ArgumentOutOfRangeException("Index cannot be larger then data size.");

                _data[z * (_size.X * _size.Y) + y * (_size.X) + x] = value;
            }
        }


    }
}
