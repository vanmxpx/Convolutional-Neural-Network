using Convolutional.Utils;

namespace Convolutional.CNN.Layers
{
    public abstract class Layer
    {
        protected LayersType _type;
        protected Tensor<double> _gradsIn;
        protected Tensor<double> _in;
	    protected Tensor<double> _out;

        public LayersType Type => _type;
        public Tensor<double> Out =>_out;
        public Tensor<double> GradsIn => _gradsIn;

        public abstract void CalcGrads(Tensor<double> delta);
        public abstract void FixWeights();
        public abstract void Activate(Tensor<double> _in);
    }
}
