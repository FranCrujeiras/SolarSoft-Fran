namespace SolarSoft_1._0.Models
{
    public class Panel
    {
        public int ID { get; set; }
        public required double LONGITUDPANEL {  get; set; }
        public required double ANCHOPANEL { get; set; }
        public required int POTENCIA { get; set; }
        public required double VOLTAJE { get; set; }
        public required double LATITUD { get; set; }
        public required double LONGITUD {  get; set; }
        public required double LARGOTERRENO { get; set; }
        public required double ANCHOTERRENO { get; set; }
        public required int ANGULOESTRUCTURA { get; set; }
        public double? separacion { get; set; }
        public int? potenciaTotal { get; set; }
        public int? totalPaneles { get; set; }



      

    }
}
