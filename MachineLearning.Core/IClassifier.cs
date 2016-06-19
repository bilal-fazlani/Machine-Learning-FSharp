using System.Collections.Generic;

namespace MachineLearning.Core
{
    public interface IClassifier
    {
        void Train(IEnumerable<Observation> trainingSet);
        string Predict(int[] pixels);
    }
}