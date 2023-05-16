/*
 Se ingresan las temperaturas en grados kelvin (En esta escala, el punto de fusión del agua se da a
los 273K y el de ebullición, a los 373K) de cada día de la semana (7 días) tomada a las 12m con un
termómetro digital capaz de leer temperaturas en entre los rangos de 100k a 500k, para n
cantidad de semanas (El usuario indicará cuantas son), determinar e informar: 

a. Promedio de temperatura semanal
b. La temperatura más fría y la más cálida leída en cada semana
c. El porcentaje de las temperaturas arriba del punto de ebullición (temperatura mayor que 375k)

 */

using System.Xml.Serialization;

class Program
{
    //Constantes
    const int fusion = 273;
    const int ebullicion = 373;
    const int rangoMin = 100;
    const int rangoMax = 500;
    static void Main(string[] args)
    {

        //Variables
        int sem = 0;
        double tempMax = -10000;
        double tempMin = 10000;
        double temp;
        int arribaEbullicion = 0;
        double sumaTemp = 0;

        //Entrada de datos 
        Console.WriteLine("Ingrese la cantidad de semanas que desea introducir:");
        sem = Int32.Parse(Console.ReadLine());

        //Bucle para recorrer las semanas
        for (int x = 1; x <= sem; x++)
        {
            Console.WriteLine($"{x}° Semana");

            //Bucle para recorrer los dias
            for (int dia = 1; dia <= 7; dia++)
            {
                //Entrada de datos
                Console.WriteLine($"Ingrese la temperatura del {dia}° día de la semana en Kelvin:");
                temp = double.Parse(Console.ReadLine());

                //Sumar las temperaturas
                sumaTemp += temp;
                 
                //Proceso
                if (temp < rangoMin || temp > rangoMax)
                {
                    Console.WriteLine("Temperatura inválida. Intente nuevamente.");
                    dia--;
                    continue;
                }

                if (temp < tempMin) tempMin = temp;
                

                if (temp > tempMax) tempMax = temp;
                

                if (temp > ebullicion) arribaEbullicion++;
                
            }
        }
        //Impresion de los datos y llamado a los metodos
        CalcularPromedioSemanal(sem, sumaTemp);
        Console.WriteLine($"Temperatura más baja: {tempMin} K");
        Console.WriteLine($"Temperatura más alta: {tempMax} K");
        MostrarPorcentajeEbullicion(sem, arribaEbullicion);
    }

    static void CalcularPromedioSemanal(int sem, double sumaTemp)
    {
        //proceso para sacar el promedio 
        double promedio = sumaTemp / (sem * 7);

        //Condicionales e impresion de los datos
        if (sem <= 1) Console.WriteLine($"La temperatura promedio de la semana es de: {promedio} K");
        
        else Console.WriteLine($"La temperatura promedio de las {sem} semanas es de: {promedio} K");
        
    }

   
    static void MostrarPorcentajeEbullicion(int sem, int arribaEbullicion)
    {
        //proceso para sacar el porcentaje
        double porcentaje = (arribaEbullicion / (sem * 7.0)) * 100;

        //Impresion de los datos
        Console.WriteLine($"El {porcentaje}% fueron temperaturas por encima del punto de ebullición que son un total de {arribaEbullicion} dias.");
    }
}
    

