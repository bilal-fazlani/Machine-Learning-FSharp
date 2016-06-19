using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace MachineLearning.Core.Evaluation
{
    public class Evaluator
    {
        public static double Correct(IEnumerable<Observation> validationSet,
            IClassifier classifierToTest)
        {
            return validationSet.Select(o => Score(o, classifierToTest))
                .Average();
        }

        private static double Score(Observation observation, IClassifier classifier)
        {
            string predicted = classifier.Predict(observation.Pixels);
            string actual = observation.Label;

            return predicted == actual ? 1.0 : 0.0;
        }
    }
}