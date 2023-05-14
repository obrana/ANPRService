using System;
namespace CodeChallenge
{
	public interface IAnalyzer
	{

		int GetNumCarsAnalyzed();
		void AddLicensePlate(string licencePlate);
		Dictionary<string, int> GetCountryCounts();
		void Reset();
		string GetCountry(string licencePlate);
		List<string> GetPlates(string country, int limit, int offset);
		List<string> GetPlatesByCountry(string country);
	}
}

