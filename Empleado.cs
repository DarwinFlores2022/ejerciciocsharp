using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaA
{
    internal class Empleado
    {
        private string nombre;
        private string apellido;
        private string numeroCuenta;
        private double sueldo;
        private double isss;
        private double renta;
        private double afp;
        private double sueldoNeto;
        public Empleado()
        {

        }
        public Empleado(string nombre, string apellido, string numeroCuenta, double sueldo, double isss, double renta, double afp, double sueldoNeto)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.NumeroCuenta = numeroCuenta;
            this.Sueldo = sueldo;
            this.Isss = isss;
            this.Renta = renta;
            this.Afp = afp;
            this.SueldoNeto = sueldoNeto;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string NumeroCuenta { get => numeroCuenta; set => numeroCuenta = value; }
        public double Sueldo { get => sueldo; set => sueldo = value; }
        public double Isss { get => isss; set => isss = value; }
        public double Renta { get => renta; set => renta = value; }
        public double Afp { get => afp; set => afp = value; }
        public double SueldoNeto { get => sueldoNeto; set => sueldoNeto = value; }

        public void RegistrarEmpleado(ref Empleado[] emp, ref int cont)
        {
            char op;
            do
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Title = "REGISTRAR EMPLEADO";
                Console.Clear();
                emp[cont] = new Empleado();
                Console.WriteLine("REGISTRO DE EMPLEADO # " + (cont + 1));
                Console.Write("Nombre: ");
                emp[cont].Nombre = Console.ReadLine();
                Console.Write("Apellido: ");
                emp[cont].Apellido = Console.ReadLine();
                Console.Write("Numero de Cuenta: ");
                emp[cont].NumeroCuenta = Console.ReadLine();

                cont++;

                Console.WriteLine("Empleado Registrado!");

                Console.WriteLine("\nDesea registrar otro Empleado?");
                op = Console.ReadKey().KeyChar;
            } while (op == 'S' || op == 's');

        }



    }

    
}
