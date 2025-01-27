using System.Text.Json;
namespace PosCashRegister.Configuration
{
    public class CurrencyConfig
    {
        // A private dictionary to store all the currency configurations.
        // The key is a country code (string), and the value is a list of decimal values representing denominations.
        private Dictionary<string, List<decimal>> _currencies;

        // Constructor that initializes the dictionary to store currency configurations.
        public CurrencyConfig()
        {
            // Initialize the dictionary when the CurrencyConfig object is created.
            _currencies = new Dictionary<string, List<decimal>>();
        }

        // Asynchronously loads the currency configuration from a file.
        // The file is expected to be in JSON format.
        public async Task LoadConfigurationAsync(string filePath)
        {
            // Validate that the file path is not null or empty.
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("File path cannot be null or empty.");

            // Check if the file exists at the given path.
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"The file '{filePath}' does not exist.");

            // Asynchronously read the content of the file.
            var fileContent = await File.ReadAllTextAsync(filePath);

            // Deserialize the file content into a Dictionary<string, List<decimal>>.
            // If the content is invalid or can't be deserialized, throw an exception.
            _currencies = JsonSerializer.Deserialize<Dictionary<string, List<decimal>>>(fileContent) ??
                          throw new InvalidOperationException("Failed to load currency configuration.");
        }

        // Retrieves the denominations for a given country code.
        // The denominations are sorted in descending order.
        public List<decimal> GetDenominations(string countryCode)
        {
            // Validate that the country code is not null or empty.
            if (string.IsNullOrEmpty(countryCode))
                throw new ArgumentException("Country code cannot be null or empty.");

            // Check if the country code exists in the dictionary.
            if (!_currencies.ContainsKey(countryCode))
                throw new KeyNotFoundException($"No denominations found for country code '{countryCode}'.");

            // Retrieve the denominations for the specified country code.
            var denominations = _currencies[countryCode];

            // Sort the denominations in descending order.
            denominations.Sort((a, b) => b.CompareTo(a));

            // Return the sorted list of denominations.
            return denominations;
        }

        // Retrieves a list of all available country codes that have currency configurations.
        public List<string> GetAvailableCountries()
        {
            // Return the keys of the dictionary as a list of country codes.
            return _currencies.Keys.ToList();
        }
    }
}