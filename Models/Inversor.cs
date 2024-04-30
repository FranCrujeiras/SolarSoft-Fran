namespace SolarSoft_1._0.Models
{
    public class Inversor
    {
        //Recuerda añadir un int para los ID!!
        public int Id { get; set; } 
        //Nombre del modelo de inversor
        public required string ModeloInversor { get; set; }
        //Porcentaje de eficiencia según norma europea
        public required double EficienciaEuropea { get; set; }
        //Potencia máxima de entrada al inversor
        public required double PotenciaEntrada { get; set; }
        //Voltaje mínimo por string necesario para operar el inversor
        public required int VoltajeMinimoMPPT { get; set; }
        //Voltaje máximo por string para operar el inversor
        public required int VoltajeMaximoMPPT { get; set; }
        //Potencia de salida del inversor
        public required double PotenciaSalida { get; set; }
        //Número de Strings que admite el inversor
        public required int NumeroMPPT { get; set; }
    }
}
