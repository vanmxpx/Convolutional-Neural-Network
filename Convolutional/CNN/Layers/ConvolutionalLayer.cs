using Convolutional.Utils;
using System;
using System.Collections.Generic;

namespace Convolutional.CNN.Layers
{
    public class ConvolutionalLayer : Layer
    {
        private List<Tensor<double>>   _filters;
        private List<Tensor<Gradient>> _filterGrads;
        private int _stride; //step
        private int _extendFilter;

        public ConvolutionalLayer(int stride, int extendFilter, int numberFilters, TSize inSize)
        {
            //if (((float)(inSize.X - extendFilter) / stride + 1) !=
            //    ((inSize.X - extendFilter) / stride + 1))
            //    throw new ArgumentException();

            //if (((float)(inSize.Y - extendFilter) / stride + 1) !=
            //    ((inSize.Y - extendFilter) / stride + 1))
            //    throw new ArgumentException();

            _type    = LayersType.Convolutional;
            _gradsIn = new Tensor<double>(inSize);
            _in      = new Tensor<double>(inSize);
            _out     = new Tensor<double>((inSize.X - extendFilter) / stride + 1,
                                      (inSize.Y - extendFilter) / stride + 1,
                                      numberFilters);

            _stride       = stride;
            _extendFilter = extendFilter;

            var rand = new Random();

            for (int a = 0; a < numberFilters; a++)
            {
                Tensor<double>   t  = new Tensor<double>(extendFilter, extendFilter, inSize.Z );    //Create filters
                Tensor<Gradient> tg = new Tensor<Gradient>(extendFilter, extendFilter, inSize.Z);   //And its gradients

                int maxval = extendFilter * extendFilter * inSize.Z;

                for (int i = 0; i < extendFilter; i++)
                    for (int j = 0; j < extendFilter; j++)
                        for (int z = 0; z < inSize.Z; z++)
                            t[i, j, z] = 1.0f / maxval * rand.Next(-32767, 32767) / 32767;          //Seed filters

                _filters.Add(t);
                _filterGrads.Add(tg);
            }
        }
        public override void Activate(Tensor<double> _in)
        {
            this._in = _in;
            /*activation*/
        }

        public override void CalcGrads(Tensor<double> delta)
        {
            throw new NotImplementedException();
        }

        public override void FixWeights()
        {
            throw new NotImplementedException();
        }
    }
}
