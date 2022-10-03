using System;
using System.Threading;

namespace PruebaA
{
    internal class Program
    {
        static int tableWidth = 73;
        static void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));



        }
        static void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";
            foreach (string column in columns)

            {
                row += Aligncenter(column, width) + "|";
            }

            Console.WriteLine(row);

        }

        static string Aligncenter(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }

            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }


        }

        static void Main(string[] args)
        {
            const int cant = 50;
            int cont = 0;
            Empleado[] emp = new Empleado[cant];

            Login(ref emp, ref cont);
           

        }//Fin main

        static void Login(ref Empleado[] emp, ref int cont)
        {
            bool opcion = false;
            string palabra;
            char resp;
            Usuario user = new Usuario();

            ConsoleKeyInfo key;

            do
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Title = "INICIAR SESIÓN";
                Console.Clear();
                user.UserName = "";
                user.Clave = "";
                if (user.Intentos >= 3)
                {
                    Console.WriteLine("INTENTOS BLOQUEADOS PARA INICIAR SESIÓN");
                    Console.WriteLine("Desea desbloquear el programa. S/N ");
                    resp = Console.ReadKey().KeyChar;

                    if (resp.Equals('S') || resp.Equals('s'))
                    {
                        Console.Write("\nESCRIBE LA PALABRA SECRETA: ");
                        palabra = Console.ReadLine();
                        palabra = palabra.ToUpper();
                        if (palabra.Equals("DARWINFLORES"))
                        {
                            user.Intentos = 0;
                            Console.WriteLine("\nTienes tres intentos para iniciar sesión.");
                            Thread.Sleep(2000);
                        }
                        else
                        {
                            Console.WriteLine("\nRespuesta incorrecta, intentalo nuevamente.");
                            Thread.Sleep(2000);
                        }

                    }
                    else
                    {
                        Console.WriteLine("\nError al digitar la opción.");
                        Thread.Sleep(2000);
                    }

                }
                else
                {
                    Console.WriteLine("INICIAR SESIÓN");
                    Console.Write("USUARIO: ");
                    user.UserName = Console.ReadLine().ToUpper();
                    Console.Write("CLAVE: ");
                    do
                    {
                        key = Console.ReadKey(true);

                        if (key.Key != ConsoleKey.Backspace)
                        {
                            user.Clave += key.KeyChar;
                            Console.Write("*");
                        }
                        else
                        {
                            if (key.Key == ConsoleKey.Backspace && user.Clave.Length > 0)
                            {
                                user.Clave = user.Clave.Remove(user.Clave.Length - 1);
                                Console.Write("\b \b");
                            }
                        }

                    } while (key.Key != ConsoleKey.Enter);
                    user.Clave = user.Clave.Trim();
                    if (user.IniciarSession())
                    {
                        user.Intentos = 0;
                        opcion = true;

                    }
                    else
                    {
                        Console.WriteLine("\n¡Usuario y/o Clave Incorrecta!");
                        Console.WriteLine("\n¡Estimado! usuario, lleva " + user.Intentos + " intentos");
                        Thread.Sleep(3000);

                        opcion = false;
                    }
                }



            } while (!opcion);

            if (opcion)
            {
                MenuPrincipal(ref emp, ref cont);
            }
        }
        static void MenuPrincipal(ref Empleado[] emp, ref int cont)
        {
            char opcion;

            do
            {

                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Title = "MENU PRINCIPAL";
                Console.Clear();
                Console.WriteLine("MENU PRINCIPAL");
                Console.WriteLine("1. IMC");
                Console.WriteLine("2. ESTRUCTURAS CICLICAS Y ARREGLOS");
                Console.WriteLine("3. REGISTRAR EMPLEADO");
                Console.WriteLine("4. TRANSFERIR SUELDO");
                Console.WriteLine("5. VER EMPLEADOS");
                Console.WriteLine("6. CERRRAR SESIÓN");
                opcion = Console.ReadKey().KeyChar;

                switch (opcion)
                {
                    case '1':
                        Imc();
                        break;

                    case '2':
                        EstructurasCiclicas();

                        break;

                    case '3':
                        PrintLine();
                        Empleado empp = new Empleado();
                        empp.RegistrarEmpleado(ref emp, ref cont);
                        break;
                    case '4':
                        TransferirSueldo(ref emp, ref cont);
                        break;

                    case '5':
                        VerEmpleado(ref emp, ref cont);
                        break;
                    case '6':

                        PrintLine();
                        Console.WriteLine("\n Cerrando Sesión");
                        Thread.Sleep(2000);


                        break;
                    default:
                        Console.WriteLine("\n Opción Incorrecta");
                        Thread.Sleep(2000);
                        break;
                }
            } while (opcion != '6');
            Login(ref emp, ref cont);

        }//Fin Menu Principal

        static void Imc()
        {
            string nombre, teclado;
            double imc, peso, estatura;
            string mensajeImc;
            bool validar = false;
            char resp;
            do
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Title = "CALCULAR IMC";
                Console.Clear();

                Console.WriteLine("CALCULANDO IMC DE UNA PERSONA");
                Console.WriteLine("Digita el nombre: ");
                nombre = Console.ReadLine().ToUpper();

                //Validando Peso
                do
                {
                    Console.Write("PESO (Kg): ");
                    teclado = Console.ReadLine();
                    validar = double.TryParse(teclado, out double result);
                    Mensaje(validar);
                } while (!validar);
                peso = double.Parse(teclado);
                //Validando Altura
                teclado = "";
                do
                {
                    Console.Write("ALTURA (M): ");
                    teclado = Console.ReadLine();
                    validar = double.TryParse(teclado, out double result);
                    Mensaje(validar);
                } while (!validar);
                estatura = double.Parse(teclado);

                imc = peso / (estatura * estatura);
                mensajeImc = "";

                if (imc < 18)
                {
                    mensajeImc = "PESO BAJO";
                }
                else if (imc >= 18 && imc < 24.9)
                {
                    mensajeImc = "NORMAL";
                }
                else if (imc >= 25 && imc < 26.9)
                {
                    mensajeImc = "SOBREPESO";
                }
                else
                {
                    mensajeImc = "OBESIDAD";
                    mensajeImc += "\n\t\t ";
                    if (imc >= 27 && imc < 29.9)
                    {
                        mensajeImc += "Obesidad Grado I";
                    }
                    else if (imc >= 30 && imc < 39.9)
                    {
                        mensajeImc += "Obesidad Grado II";
                    }
                    else
                    {
                        mensajeImc += "Obesidad Grado III";
                    }
                }

                Console.WriteLine("\n*************************************");
                Console.WriteLine("NOMBRE: " + nombre);
                Console.WriteLine("La persona tiene un IMC: " + imc.ToString("#.##"));
                Console.WriteLine("CLASIFICACIÓN: " + mensajeImc);

                Console.Write("Desea continuar: s/n ");
                resp = Console.ReadKey().KeyChar;
            } while (resp.Equals('S') || resp.Equals('s'));


        }//Fin IMC

        static void Mensaje(bool validar)
        {
            if (!validar)
            {
                Console.WriteLine("\nDigite un valor válido para este campo.");
            }
        }//Fin mensaje validación

        static void EstructurasCiclicas()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Title = "ESTRUCUTRAS CICLICAS Y ARREGLOS";
            Console.Clear();
            const int cant = 5;
            string[] nombres = {"FERNANDO","MARITZA","WILLIAN","ORLANDO","BETHANY"};
            double[] num = new double[cant];

            Random r = new Random();

            for (int i = 0; i < cant; i++)
            {
                num[i] = r.Next(-100, 200);
            }

            Console.WriteLine("NOMBRES DE PERSONAS");
            foreach (var item in nombres)
            {
                Console.Write(item+",");
            }
            Console.WriteLine("");
            PrintLine();
            Array.Sort(nombres);
            Console.WriteLine("NOMBRES DE PERSONAS - A-Z");
            foreach (var item in nombres)
            {
                Console.Write(item + ",");
            }
            Console.WriteLine("");
            PrintLine();

            Console.WriteLine("NOMBRES DE PERSONAS - Z-A");
            int k = nombres.Length-1;
            while (k>=0)
            {
                Console.Write(nombres[k] + ",");
                k --;
            }
            Console.WriteLine("");
            PrintLine();

            Console.WriteLine("NUMEROS GENERADOS ALEATORIAMENTE");
            for (int i = 0; i < cant; i++)
            {
                Console.Write(num[i] + ", |");
            }
            Console.WriteLine("");
            PrintLine();
            Array.Sort(num);
            Console.WriteLine("\nNUMEROS GENERADOS ALEATORIAMENTE - ASCENDENTE");
            for (int i = 0; i < cant; i++)
            {
                Console.Write(num[i] + ", |");
            }
            Console.WriteLine("");
            PrintLine();
            int j= cant - 1;
            Console.WriteLine("\nNUMEROS GENERADOS ALEATORIAMENTE - DESCENDENTE");
            while (j >= 0)
            {
                Console.Write(num[j] + ", |");
                j--;
            } 
            Console.WriteLine("");
            PrintLine();
            Console.ReadKey();


        }

        static void VerEmpleado(ref Empleado[] emp, ref int cont)
        {
            char op;
            int ide;
            bool estado = false,validar=false;
            string teclado;

            do
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Title = "EMPLEDAOS";
                Console.Clear();

                PrintLine();
                Console.WriteLine("\t\t\tLISTADO DE EMPLEADOS");
                PrintLine();
                PrintRow("N°", "NOMBRE", "APELLIDO", "N° CUENTA", "SUELDO", "ISSS", "RENT", "AFP", "SN");
                if (cont > 0)
                {
                    for (int i = 0; i < cont; i++)
                    {
                        PrintLine();
                        PrintRow((i + 1).ToString(), emp[i].Nombre, emp[i].Apellido, emp[i].NumeroCuenta,
                            "$ " + emp[i].Sueldo.ToString(), "$ " + emp[i].Isss.ToString(), "$ " + emp[i].Renta.ToString(),
                            "$ " + emp[i].Afp.ToString(), "$ " + emp[i].SueldoNeto.ToString());
                    }
                }

                PrintLine();

                Console.WriteLine("¿Qué deseas hacer?");
                Console.WriteLine("1. Ver detalle Empleado");
                Console.WriteLine("2. SALIR");
                op = Console.ReadKey().KeyChar;
                Console.WriteLine("\n");
                switch (op)
                {
                    case '1':
                        
                        do
                        {
                            PrintLine();
                            Console.Write("N°: ");
                            teclado = Console.ReadLine();
                            validar = int.TryParse(teclado, out int num);
                            Mensaje(validar);
                        } while (!validar);
                        ide = int.Parse(teclado) - 1;
                        estado = false;
                        for (int i = 0; i < cont; i++)
                        {
                            if (i==ide)
                            {
                                ide = i;
                                estado = true;
                                break;
                            }

                        }
                        if (!estado)
                        {
                            Console.WriteLine("\nEl número de Empleado no existe!");
                            Console.WriteLine("Intentalo nuevamente!");
                            Thread.Sleep(1000);
                        }
                        else
                        {
                            
                            PrintLine();
                            Console.WriteLine("Nombre Empleado: " + emp[ide].Nombre + " " + emp[ide].Apellido+"\t N° Cuenta: "+ emp[ide].NumeroCuenta);
                            Console.WriteLine("Sueldo: $ "+ emp[ide].Sueldo.ToString("#.##"));
                            Console.WriteLine("ISSS: $ " + emp[ide].Isss.ToString("#.##"));
                            Console.WriteLine("Renta: $ " + emp[ide].Renta.ToString("#.##"));
                            Console.WriteLine("Afp: $ " + emp[ide].Afp.ToString("#.##"));
                            Console.WriteLine("Sueldo Neto: $ " + emp[ide].SueldoNeto.ToString("#.##"));
                           
                            Console.WriteLine("Presiona una tecla para continuar.");
                            Console.ReadKey();
                        }
                        break;
                    default:
                        Console.WriteLine("Opción Incorrecta!");
                        break;
                }
            } while (op!='2');


            }
        static void TransferirSueldo(ref Empleado[] emp, ref int cont)
        {
            string _numeroCuenta, teclado = "";
            bool estado = false, validar = false;
            char op;
            int ide = 0;

            do
            {

                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Title = "TRANSFERIR SUELDO A EMPLEDAOS";
                Console.Clear();

                PrintLine();
                Console.WriteLine("\t\t\tTRANSFERIR SUELDO A EMPLEADOS");
                PrintLine();
                PrintRow("N°", "NOMBRE", "APELLIDO", "N° DE CUENTA", "SUELDO");
                if (cont > 0)
                {
                    for (int i = 0; i < cont; i++)
                    {
                        PrintLine();
                        PrintRow((i + 1).ToString(), emp[i].Nombre, emp[i].Apellido, emp[i].NumeroCuenta, "$ " + emp[i].Sueldo.ToString("#.##"));
                    }
                }
                else
                {
                    Console.WriteLine("\t\t\tNo se encontraron registros");

                }
                PrintLine();

                Console.WriteLine("¿Qué deseas hacer?");
                Console.WriteLine("1. Transferir sueldo");
                Console.WriteLine("2. SALIR");
                op = Console.ReadKey().KeyChar;
                Console.WriteLine("\n");
                switch (op)
                {
                    case '1':
                        PrintLine();
                        Console.Write("Ingrese el número de cuenta: ");
                        _numeroCuenta = Console.ReadLine();

                        estado = false;
                        for (int i = 0; i < cont; i++)
                        {
                            if (emp[i].NumeroCuenta.Equals(_numeroCuenta))
                            {
                                ide = i;
                                estado = true;
                                break;
                            }

                        }
                        if (!estado)
                        {
                            Console.WriteLine("\nEl número de cuenta no existe!");
                            Console.WriteLine("Intentalo nuevamente!");
                            Thread.Sleep(1000);
                        }else
                        {
                            PrintLine();
                            Console.WriteLine("Nombre Empleado: " + emp[ide].Nombre + " " + emp[ide].Apellido);
                            do
                            {
                                Console.Write("Sueldo: $ ");
                                teclado = Console.ReadLine();
                                validar = double.TryParse(teclado, out double sueld);
                                Mensaje(validar);
                            } while (!validar);

                            emp[ide].Sueldo = double.Parse(teclado);
                            emp[ide].Isss = double.Parse(teclado) * 0.09;
                            emp[ide].Renta = double.Parse(teclado) * 0.1;
                            emp[ide].Afp = double.Parse(teclado) * 0.07;
                            emp[ide].SueldoNeto = emp[ide].Sueldo - (emp[ide].Isss + emp[ide].Renta + emp[ide].Afp);
                            Console.WriteLine("Sueldo transferido!");
                            Thread.Sleep(2000);
                        }
                        break;

                    default:
                        Console.WriteLine("Opción Incorrecta!");
                        break;
                }





            } while (op != '2' || op != '2');
        }
    }
}
