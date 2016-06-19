using System.IO;
using System.Linq;

namespace MachineLearning.Core
{
    public class DataReader
    {
        public static Observation[] ReadObservations(string path)
        {
            return File.ReadAllLines(path)
                .Skip(1)
                .Select(ObservationFactory)
                .ToArray();
        }

        private static Observation ObservationFactory(string line)
        {
            string[] values = line.Split(',');
            string label = values[0];
            int[] pixels = values.Skip(1)
                .Select(int.Parse)
                .ToArray();
            return new Observation(label,pixels);
        }
    }
}