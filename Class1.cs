using System;

public class Terreno
{
          //Función que determina la altura solar en solsticio de invierno
    public static double AlturaSolar(double latitud)
    {
        // Convertimos la latitud de grados a radianes
        double latitudRad = latitud * Math.PI / 180.0;

        // Declinación solar en el solsticio de invierno
        double declinacion = -23.44 * Math.PI / 180.0;

        // Calculamos el ángulo de elevación del sol utilizando la fórmula del coseno
        double alturaSolar = Math.Asin(Math.Sin(latitudRad) * Math.Sin(declinacion) +
                                       Math.Cos(latitudRad) * Math.Cos(declinacion));

        // Convertimos la altura solar de radianes a grados
        alturaSolar = alturaSolar * 180.0 / Math.PI;

        return alturaSolar;
    }
        //Función que calcula la separación mínima de paneles en función del resultado de la función de altura solar
    public static double SeparacionMinimaPaneles(double alturaSolar)
    {
        double latitud = 42.54;

        //El ángulo de la estructura puede ser 15º o 30º
        double anguloEstructura = 30 * Math.PI / 180;

        //Se introduce longitud de panel. La anchura no es relevante para este cálculo
        double longitudPanel = 2.135;

        //Conversión a radianes de la altura solar
        double altSolarRad = AlturaSolar(latitud) * Math.PI / 180;

        //Se define la variable distancia mínima, y se realiza el cálculo aplicando una fórmula
        double distanciaMinima;
        distanciaMinima = longitudPanel * Math.Cos(anguloEstructura) + longitudPanel * (Math.Sin(anguloEstructura) / Math.Tan(altSolarRad));
        return distanciaMinima;

    }
    // Método Test para probar la función
    public static void Test(string[] args)
    {
        // Ejemplo de uso: Calcular la máxima altura solar en el solsticio de invierno para una latitud dada

        double latitud = 42.23282; // Latitud de ejemplo para el caso de Vigo

        //Llamada a función de altura solar
        double alturaMaximaSolar = AlturaSolar(latitud);

        //Llamada a función de separación mínima
        double distanciaPaneles = SeparacionMinimaPaneles(alturaMaximaSolar);

        //Se presenta el resultado en una línea de consola
        Console.WriteLine("La máxima altura solar en el solsticio de invierno para una latitud de " +
                          latitud + " grados es: " + alturaMaximaSolar + " grados. La separación mínima entre paneles es" + distanciaPaneles + "metros");
    }
}

