using Convolutional.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convolutional.CNN.Layers
{
    public class FullConnectedLayer : Layer
    {
        public override void Activate(Tensor<double> _in)
        {
            throw new NotImplementedException();
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
