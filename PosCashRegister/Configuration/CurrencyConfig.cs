using System.Text.Json;
namespace PosCashRegister.Configuration
{
    public class CurrencyConfig
    {
        // Dictionary to store all the currency configuration
        private readonly Dictionary<string, List<decimal>> _currencies;

        public CurrencyConfig(string filePath)
        {
            // Validate file path and check if it exists
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentException("File path cannot be null or empty.");
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"The file '{filePath}' does not exist.");
            // Load the currency configuration from the file
            string json = File.ReadAllText(filePath);
            _currencies = JsonSerializer.Deserialize<Dictionary<string, List<decimal>>>(json) 
                          ?? new Dictionary<string, List<decimal>>();
        }
        public List<decimal> GetDenominations(string countryCode)
        {
            // Valdidate country code and check if it exists
            if (string.IsNullOrEmpty(countryCode))
                throw new ArgumentException("Country code cannot be null or empty.");
            if (!_currencies.ContainsKey(countryCode))
                throw new KeyNotFoundException($"No denominations found for country code '{countryCode}'.");
            // Get the denominations for the country
            var denominations = _currencies[countryCode];
            // Sort in descending order
            denominations.Sort((a, b) => b.CompareTo(a));
            return denominations;
        }
        public List<string> GetAvailableCountries()
        {
            // Get as a list of country available codes
            return _currencies.Keys.ToList();
        }
    }
}