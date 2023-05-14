using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge
{
    class NumberPlatesController
    {
        public readonly IAnalyzer _analyzer;
        public NumberPlatesController(IAnalyzer analyzer)
        {
            _analyzer = analyzer;
        }
        public void StartAnalyzer()
        {
            const string filePath = "/Users/ombikramrana/Desktop/plates.txt";

            LicenseReader reader = new LicenseReader(filePath);

            foreach (string plateNumber in reader.ReadLicensePlates())
            {
                _analyzer.AddLicensePlate(plateNumber);

            }


            var countryCounts = _analyzer.GetCountryCounts();

            foreach (var country in countryCounts)
            {
                Console.WriteLine($"{country.Key}: {country.Value}");
            }
            Console.WriteLine();

            int numCarsAnalyzed = _analyzer.GetNumCarsAnalyzed();

            Console.WriteLine($"Number of Cars analyzed since last reset: {numCarsAnalyzed}");


            Console.WriteLine("Do you want to reset the state the analyzer?(Yes/No)");
            var inputFromUser = Console.ReadLine();
            if (inputFromUser is not null && inputFromUser.ToLower() == "yes")
            {
                _analyzer.Reset();
                StartAnalyzer();
            }
            Console.WriteLine("Which country number plates you want to see?(Denmark/Sweden)");
            var countryInput = Console.ReadLine();
            if (countryInput != null)
            {
                int counter = 1;
                if (countryInput.ToLower() == "denmark")
                {
                    List<string> plates = _analyzer.GetPlates("Denmark", 100, 0);

                    if (plates.Count == 100)
                    {
                        plates.AddRange(_analyzer.GetPlates("Denmark", 100, counter * 100));
                    }

                    Console.WriteLine($"  Plates: {string.Join(", ", plates)}");
                    counter = 1;
                }
                else if (countryInput.ToLower() == "sweden")
                {
                    List<string> plates = _analyzer.GetPlates("Sweden", 100, 0);

                    if (plates.Count == 100)
                    {
                        plates.AddRange(_analyzer.GetPlates("Sweden", 100, counter * 100));
                    }

                    Console.WriteLine($"  Plates: {string.Join(", ", plates)}");
                    counter = 1;
                }
            }

            Console.WriteLine("Do you want to write Swedish plates ?(Yes/No)");
            var countryWriteInput = Console.ReadLine();
            if (countryWriteInput != null)
            {
                if (countryWriteInput.ToLower() == "yes")
                {
                    List<string> plates = _analyzer.GetPlatesByCountry("Sweden");

                    string docPath = "/Users/ombikramrana/Desktop/TextFile";

                    // Write the string array to a new file named "WriteLines.txt".
                    using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "Swedeshplates.txt")))
                    {
                        foreach (string plate in plates)
                            outputFile.WriteLine(plate);
                    }
                }

            }
        }
    }
}
