namespace SolarSoft_1._0.Models
{
    public class Terreno
    {
        public int Id { get; set; }
        public required int ModeloPanel { get; set; }
        public required double Latitud { get; set; }
        public required double Longitud { get; set; }
        public required double LargoTerreno { get; set; }
        public required double AnchoTerreno { get; set; }
        public int AnguloEstructura { get; set; }
        public required int Azimuth { get; set; }
        public bool InstalacionEstructura { get; set; }
        public double? Separacion { get; set; }
        public double? PotenciaTotal { get; set; }
        public int? TotalPaneles { get; set; }
        public int? Arboles { get; set; }
        public double? Emisiones { get; set; }

    }
}
