using Convolutional.CNN.Layers;
using Convolutional.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convolutional.CNN
{
    public class ConvolutionalNeuralNetwork
    {
        private readonly List<Layer> _layers = new List<Layer>();
        public ConvolutionalNeuralNetwork()
        {
            _layers.Add(new ConvolutionalLayer(0,0,0, new TSize()));
            _layers.Add(new ReLULayer());
            _layers.Add(new PoolLayer());
            _layers.Add(new FullConnectedLayer());
        }

        public double Train(Tensor<double> data, Tensor<double> expected)
        {
            //activate cnn
            _layers[0].Activate(data);
            for(int i = 1; i < _layers.Count; i++)
                _layers[i].Activate(_layers[i-1].Out);

            //calc delta rrrors
            Tensor<double> delta = _layers.Last().Out - expected;

            //calc grad (back prapagation of error)
            _layers[_layers.Count - 1].CalcGrads(delta);
            for(int i = _layers.Count-2; i >= 0; i--)
                _layers[i].CalcGrads(_layers[i+1].GradsIn);
            return 0;
        }
    }
}
