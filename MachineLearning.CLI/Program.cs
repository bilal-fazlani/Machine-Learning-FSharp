using System;
using MachineLearning.Core;
using MachineLearning.Core.Evaluation;

namespace MachineLearning.CLI
{
    public class Program
    {
        public static void Main()
        {
            Observation[] observations = 
                DataReader.ReadObservations("trainingsample.csv");

            ManhattenDistance distance = new ManhattenDistance();

            BasicClassifier classifier = new BasicClassifier(distance);

            classifier.Train(observations);

            Observation[] validationSet =
                DataReader.ReadObservations("validationsample.csv");

            double score = Evaluator.Correct(validationSet, classifier);

            Console.WriteLine($"Correct percent: {score:P2}");

            Console.ReadLine();
        }
    }
}
