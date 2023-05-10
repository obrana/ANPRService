using CodeChallenge;
using LicensePlateAnalyzer;

class Program
{
    static void Main(string[] args)
    {
        const string filePath = "/Users/ombikramrana/Desktop/plates.txt";

        LicenseReader reader = new LicenseReader(filePath);
      

        Analyzer analyzer = new Analyzer();

        foreach (string plateNumber in reader.ReadLicensePlates())
        {
            analyzer.AddLicensePlate(plateNumber);
            
        }
 

        var countryCounts = analyzer.GetCountryCounts();

        foreach (var country in countryCounts)
        {
            Console.WriteLine($"{country.Key}: {country.Value}");
        }
        Console.WriteLine();

        int numCarsAnalyzed = analyzer.GetNumCarsAnalyzed();

        Console.WriteLine($"Number of Cars analyzed since last reset: {numCarsAnalyzed}");




        Console.ReadLine();

    }
}
