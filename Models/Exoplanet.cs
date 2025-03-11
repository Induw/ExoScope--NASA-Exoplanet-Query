namespace ExoplanetQueryApp.Models
{
    public class Exoplanet
    {
        public string PlanetName { get; set; }       // pl_name
        public string HostName { get; set; }         // hostname
        public string DiscoveryMethod { get; set; }  // discoverymethod
        public string DiscoveryFacility { get; set; }
        public int? DiscoveryYear { get; set; }      // disc_year
        public double? OrbitalPeriod { get; set; }   // pl_orbper
        public double? PlanetRadius { get; set; }    // pl_rade
        public double? PlanetMass { get; set; }      // pl_masse
        public double? Distance { get; set; }        // sy_dist
    }
}
