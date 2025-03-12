using ExoplanetQueryApp.Models;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
namespace ExoplanetQueryApp.Services
{
    public class ExoplanetService
    {
        private readonly List<Exoplanet> _exoplanets;

        public ExoplanetService()
        {
            _exoplanets = LoadExoplanetData();
        }

        private List<Exoplanet> LoadExoplanetData()
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            var csvPath = Path.Combine(basePath, "Data", "ExoplanetData.csv");

            if (!File.Exists(csvPath))
            {
                throw new FileNotFoundException($"CSV file not found at: {csvPath}");
            }
            using var reader = new StreamReader(csvPath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            while (csv.Read())
            {
                if (!csv.GetField(0).StartsWith("#"))
                {
                    csv.ReadHeader(); 
                    break;
                }
            }
            csv.Context.RegisterClassMap<ExoplanetMap>();
            return csv.GetRecords<Exoplanet>().ToList();
        }

        public IEnumerable<Exoplanet> QueryExoplanets(
        string planetName, string hostName, string discoveryMethod, int? discoveryYear, string? discoveryFacility,
        double? orbitalPeriod, double? planetRadius, double? planetMass, double? distance)
        {
            var query = _exoplanets.AsQueryable();

            if (!string.IsNullOrEmpty(planetName))
                query = query.Where(e => e.PlanetName.Contains(planetName, StringComparison.OrdinalIgnoreCase));
            if (!string.IsNullOrEmpty(hostName))
                query = query.Where(e => e.HostName.Contains(hostName, StringComparison.OrdinalIgnoreCase));
            if (!string.IsNullOrEmpty(discoveryMethod))
                query = query.Where(e => e.DiscoveryMethod.Contains(discoveryMethod, StringComparison.OrdinalIgnoreCase));
            if (!string.IsNullOrEmpty(discoveryFacility))
                query = query.Where(e => e.DiscoveryFacility.Contains(discoveryFacility, StringComparison.OrdinalIgnoreCase));

            if (discoveryYear.HasValue) query = query.Where(e => e.DiscoveryYear == discoveryYear.Value);
            if (orbitalPeriod.HasValue) query = query.Where(e => e.OrbitalPeriod == orbitalPeriod.Value);
            if (planetRadius.HasValue) query = query.Where(e => e.PlanetRadius == planetRadius.Value);
            if (planetMass.HasValue) query = query.Where(e => e.PlanetMass == planetMass.Value);
            if (distance.HasValue) query = query.Where(e => e.Distance == distance.Value);

            return query.ToList();
        }
    }

    public class ExoplanetMap : ClassMap<Exoplanet>
    {
        public ExoplanetMap()
        {
            Map(m => m.PlanetName).Name("pl_name");
            Map(m => m.HostName).Name("hostname");
            Map(m => m.DiscoveryMethod).Name("discoverymethod");
            Map(m => m.DiscoveryFacility).Name("disc_facility");
            Map(m => m.DiscoveryYear).Name("disc_year").TypeConverterOption.NullValues("");
            Map(m => m.OrbitalPeriod).Name("pl_orbper").TypeConverterOption.NullValues("");
            Map(m => m.PlanetRadius).Name("pl_rade").TypeConverterOption.NullValues("");
            Map(m => m.PlanetMass).Name("pl_masse").TypeConverterOption.NullValues("");
            Map(m => m.Distance).Name("sy_dist").TypeConverterOption.NullValues("");
        }
    }
}

