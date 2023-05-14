using System;
using System.Text.RegularExpressions;

namespace CodeChallenge
{
	public class Analyzer: IAnalyzer
	{
        private readonly Dictionary<string, int> _countryCounts = new Dictionary<string, int>();
        private List<LicensePlate> _licensePlates = new List<LicensePlate>();

        private int _numCarsAnalyzed = 0;

        public void AddLicensePlate(string licensePlate)
        {
            string country = GetCountry(licensePlate);
            if(!_countryCounts.ContainsKey(country))
            {
                _countryCounts[country] = 0;
            }
            _countryCounts[country]++;
            _numCarsAnalyzed++;
            _licensePlates.Add(new LicensePlate { Country = country, Number = licensePlate });
        }

        public string GetCountry(string licensePlate)
      => Regex.IsMatch(licensePlate, @"^[A-Z]{3}\s[0-9]{3}$") ? "Sweden" :
        Regex.IsMatch(licensePlate, @"^[A-Z]{2}\s[0-9]{2}\s[0-9]{3}$") ? "Denmark" :
        "Unknown";

        public Dictionary<string, int> GetCountryCounts()
        {
            return new Dictionary<string, int>(_countryCounts);
        }

        public int GetNumCarsAnalyzed()
        {
            return _numCarsAnalyzed;
        }

        public List<string> GetPlates(string country, int limit, int offset)
        {
            return _licensePlates
         .Where(plate => plate.Country == country)
         .Select(plate => plate.Number ?? "")
         .Skip(offset)
         .Take(limit)
         .ToList();
        }

        public List<string> GetPlatesByCountry(string country)
        {
            return _licensePlates
          .Where(plate => plate.Country == country)
          .Select(plate => plate.Number ?? "")
          .Distinct()
          .ToList();
        }

        public void Reset()
        {
            _countryCounts.Clear();
            _numCarsAnalyzed = 0;
            _licensePlates.Clear();
        }
    }
}

