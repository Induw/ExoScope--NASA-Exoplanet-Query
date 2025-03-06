using ExoplanetQueryApp.Models;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
namespace ExoplanetQueryApp.Services
{
    public class ExoplanetService
    {
        private readonly List<Exoplanet> _exoplanets;

        public ExoplanetService() {
            _exoplanets = LoadExoplanetData();
    }

        private List<Exoplanet> LoadExoplanetData()
        {

        }
}
