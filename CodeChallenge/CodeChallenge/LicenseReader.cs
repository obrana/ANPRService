using System;
namespace CodeChallenge
{
	public class LicenseReader
	{

		private readonly string _filePath;

		public LicenseReader(string filePath)
		{
			_filePath = filePath;
		}


		public List<string> ReadLicensePlates()
		{
			List<string> licensePlates = new List<string>();

			try
			{
				using (StreamReader reader = new StreamReader(_filePath))
				{
					string line;

					while ((line = reader.ReadLine()) != null)
					{
						licensePlates.Add(line);
					}
				}
			}
			catch(Exception ex)
			{
				Console.WriteLine("Error reading input file: " + ex.Message);
			}

			return licensePlates;

			
		}
		
		
	}
	
}

