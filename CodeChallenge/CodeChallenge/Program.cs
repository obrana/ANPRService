using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using CodeChallenge;

class Program
{

    static void Main(string[] args)
    {
        IAnalyzer analyzer = new Analyzer();
        NumberPlatesController controller = new NumberPlatesController(analyzer);
        controller.StartAnalyzer();



    }
}
