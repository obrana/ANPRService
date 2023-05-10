using System.Text.RegularExpressions;

namespace LicensePlateAnalyzer;

public class Analyzer
{

   

    private readonly Dictionary<string, int> _countryCounts = new Dictionary<string, int>();

    private int _numCarsAnalyzed = 0;

    public void AddLicensePlate(string licensePlate)
    {
        string country = GetCountry(licensePlate);



        if (!_countryCounts.ContainsKey(country))
        {
            _countryCounts[country] = 0;
        }
   
        _countryCounts[country]++;
        _numCarsAnalyzed++;
       
    }



    public int GetNumCarsAnalyzed()
    {
        return _numCarsAnalyzed;
    }
    public void Reset()
    {
        _countryCounts.Clear();
        _numCarsAnalyzed = 0;
    }

    public Dictionary<string, int> GetCountryCounts()
    {
        return new Dictionary<string, int>(_countryCounts);
    }



    private string GetCountry(string licensePlate)
    {


        Regex swedishRegex = new Regex(@"^[A-Z]{3}\s[0-9]{3}$");
        Regex danishRegex = new Regex(@"^[A-Z]{2}\s[0-9]{2}\s[0-9]{3}$");

        if (swedishRegex.IsMatch(licensePlate))
        {
            return "Sweden";
        }
        else if (danishRegex.IsMatch(licensePlate))
        {
            return "Denmark";
        }
        else
        {
            return "Unknown";
        }
        }





}

