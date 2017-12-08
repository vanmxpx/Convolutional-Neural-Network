using Convolutional.CNN;
using Convolutional.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convolutional
{
    class Program
    {
        static void Main(string[] args)
        {
            ConvolutionalNeuralNetwork cnn = new ConvolutionalNeuralNetwork();
            List<Case> cases = new List<Case>();

            //train
            int epoches = 10000;
            double amse = 0;
            int st      = 0;
            for (int i = 0; i < epoches; i++)
            {
                foreach(var c in cases)
                {
                    double xerr = cnn.Train(c.Data, c.Out);
                    amse += xerr;
                    st++;
                }
                if (i % 500 == 0)
                    Console.WriteLine($"epoche = {i + 1}, global error = {amse/st}");
            }

            //test
        }
    }
}
