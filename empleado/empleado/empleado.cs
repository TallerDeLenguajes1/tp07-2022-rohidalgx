using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace empleado
{
    public class empleado
    {
        public double resultado;
        public string nombre;
        public string apellido;
        public DateTime fechaNac;
        public char estadoCivil;
        public char genero;
        public DateTime ingresoEmpr;
        public double sueldoBasico;
        public cargo Cargo;
        public enum cargo
        {
            auxiliar,
            administrativo,
            ingeniero,
            especialista,
            investigador,
        }

        public void Antiguedad()
        {
            DateTime FechaActual = DateTime.Now;
            int ano = FechaActual.Year - ingresoEmpr.Year;
            int mes = FechaActual.Month - ingresoEmpr.Month;
            int dia = FechaActual.Day - ingresoEmpr.Day;
            Console.WriteLine("La antiguedad es de : " + ano + " anios " + mes + " meses y " + dia + " dias");

        }

        public void Edad()
        {
            DateTime FechaActual = DateTime.Now;
            int edad = FechaActual.Year - fechaNac.Year;

            Console.WriteLine("Edad : " + edad);
        }

        public void Jubilacion()
        {
            int jubi;
            if (genero == 'M')
            {
                jubi = 65 - DateTime.Now.Year - fechaNac.Year;
            }
            else
            {
                jubi = 60 - DateTime.Now.Year - fechaNac.Year;
            }
            Console.WriteLine("Le faltan " + jubi + " anios para jubilarse");
        }




    }
}
