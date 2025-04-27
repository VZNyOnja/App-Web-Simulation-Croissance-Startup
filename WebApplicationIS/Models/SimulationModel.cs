namespace WebApplicationIS.Models
{
    public class SimulationModel
    {
        public double R { get; set; }
        public double K { get; set; }
        public double N0 { get; set; }

        public List<PointResultat> Resultats { get; set; }
    }

    public class PointResultat
    {
        public double Temps { get; set; }
        public double Nombre { get; set; }
    }
}
