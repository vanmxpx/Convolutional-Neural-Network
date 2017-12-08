namespace Convolutional.Utils
{
    public struct Case
    { 
        public Tensor<double> Data { get; private set; }
        public Tensor<double> Out  { get; private set; }

        public Case(string pathToPNG)
        {
            Data = new Tensor<double>(0,0,0);
            Out = new Tensor<double>(0, 0, 0);
        }
    }
}
