using System.Collections.Generic;

namespace MachineLearning.Core
{
    public class BasicClassifier : IClassifier
    {
        private readonly IDistance _distance;

        public BasicClassifier(IDistance distance)
        {
            _distance = distance;
        }

        private IEnumerable<Observation> _trainingSet;

        public void Train(IEnumerable<Observation> trainingSet)
        {
            _trainingSet = trainingSet;
        }

        public string Predict(int[] pixels)
        {
            Observation currentBest = null;
            double shortestDistanceYet = double.MaxValue;

            foreach (var observation in _trainingSet)
            {
                double currentDistance = _distance.Between(observation.Pixels, pixels);

                if (currentDistance < shortestDistanceYet)
                {
                    currentBest = observation;
                    shortestDistanceYet = currentDistance;
                }
            }

            return currentBest.Label;
        }
    }
}