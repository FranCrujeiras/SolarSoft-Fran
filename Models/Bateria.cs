namespace SolarSoft_1._0.Models
{
    public class Bateria
    {
        public int Id { get; set; }
        //Nombre del modelo de batería
        public required string ModeloBateria { get; set; }
        //Capacidad de la batería en kWh
        public required double Capacidad {  get; set; }
        //Potencia de salida de la batería en kW
        public required double PotenciaSalida { get; set; }
        //Número de módulos apilados en el sistema
        public required int Modulos { get; set; }
        //Voltaje nominal de la batería en Voltios
        public required int VoltajeNominal {  get; set; }

    }
}
