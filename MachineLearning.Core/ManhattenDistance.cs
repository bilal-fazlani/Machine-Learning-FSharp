using System;

namespace MachineLearning.Core
{
    public class ManhattenDistance : IDistance
    {
        public double Between(int[] pixels1, int[] pixels2)
        {
            if(pixels1.Length != pixels2.Length)
                throw new Exception("image sizes are not same");

            double distance = 0;

            int length = pixels1.Length;
            for (int i = 0; i < length; i++)
            {
                distance += Math.Abs(pixels1[i] - pixels2[i]);
            }
            return distance;
        }
    }
}