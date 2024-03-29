﻿namespace SolarSoft_1._0.Models
{
    public class Terreno
    {
        public int Id { get; set; }
        public required string ModeloPanel { get; set; }
        public required int Potencia { get; set; }
        public required double Voltaje { get; set; }
        public required double Latitud { get; set; }
        public required double Longitud { get; set; }
        public required double LargoTerreno { get; set; }
        public required double AnchoTerreno { get; set; }
        public required int AnguloEstructura { get; set; }
        public double? Separacion { get; set; }
        public int? PotenciaTotal { get; set; }
        public int? TotalPaneles { get; set; }
    }
}
