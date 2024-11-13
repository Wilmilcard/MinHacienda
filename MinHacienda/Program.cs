
using Microsoft.Data.SqlClient;
using MinHacienda.Models;
using System;
using System.Data;
using System.Data.SqlTypes;

class Program
{
    static int opcion = 9999;
    static string nombre = string.Empty;
    static Random ran = new Random();
    static List<Adicional> listadoAdicionales = new List<Adicional>();
    static List<Helado> listadoHelados = new List<Helado>();
    static Factura factura = new Factura();

    static void Main()
    {
        sql();
        CargueHelados();
        CargueAdicionales();
        Mensaje();
        Saludo(nombre);
        Cargando();
        Menu();

        Console.WriteLine($"EJECUCION TERMINADA POR {nombre}");
        Console.ReadLine();
    }

    static void sql()
    {
        try
        {
            string connectionString = "Server=ASW1741\\SQLEXPRESS;Database=min_hacienda;Trusted_Connection=True;";

            using (SqlConnection _con = new SqlConnection(connectionString))
            {
                string path = "C:\\Users\\jleon\\source\\repos\\MinHacienda\\MinHacienda\\Utils\\createDB.sql";
                string query = File.ReadAllText(path);

                using (SqlCommand _cmd = new SqlCommand(query, _con))
                {
                    _con.Open();
                    _cmd.ExecuteNonQuery();
                    _con.Close();
                }
            }
        }
        catch (Exception ex) 
        {
            Console.WriteLine(ex.ToString()); 
        }
    }

    static void Mensaje()
    {
        Console.WriteLine("---------------");
        Console.WriteLine("---------------");
        Console.WriteLine("Saludo Software");
        Console.WriteLine("---------------");
        Console.WriteLine("---------------\n\n");
        nombre = Console.ReadLine();
    }

    static void Cargando()
    {
        Console.WriteLine("CARGANDO");
        for (var i = 0; i <= 10; i++)
        {
            Console.Write("***");
            Thread.Sleep(100);
        }
    }

    static void Menu()
    {
        var press = "\npresione cualquier tecla para continuar...";
        do
        {
            Console.Clear();
            Console.WriteLine("MENU\n" +
            "1. compra helado\n" +
            "2. adicional\n" +
            "3. pago\n" +
            "0. Salir\n");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 0:
                    Console.WriteLine("\n\n #####     ###    ####      ######  #####      ###\r\n##   ##   ## ##    ##         ##     ## ##    ## ##\r\n##       ##   ##   ##         ##     ##  ##  ##   ##\r\n #####   ##   ##   ##         ##     ##  ##  ##   ##\r\n     ##  #######   ##         ##     ##  ##  #######\r\n##   ##  ##   ##   ##  ##     ##     ## ##   ##   ##\r\n #####   ##   ##  #######   ######  #####    ##   ##\r\n\r\n");
                    Console.WriteLine(press);
                    Console.ReadLine();
                    break;
                case 1:
                    Compra();
                    Console.WriteLine(press);
                    Console.ReadLine();
                    break;
                case 2:
                    Adicionales();
                    Console.WriteLine(press);
                    Console.ReadLine();
                    break;
                case 3:
                    Pago();
                    Console.WriteLine(press);
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("**** **************** *****");
                    Console.WriteLine("**** Seleccion errada *****");
                    Console.WriteLine("**** **************** *****");
                    Console.ReadLine();
                    break;
            }


        } while (opcion != 0);

        //Console.ForegroundColor = ConsoleColor.White;
    }

    static void Saludo(string _nombre)
    {
        Console.WriteLine($"Hola {_nombre}");
    }

    #region Compra
    static void Compra()
    {
        var cerrar = false;
        do
        {
            Console.Clear();
            Console.WriteLine("Escoja un sabor (valor por bola)");
            foreach (var helado in listadoHelados)
                Console.WriteLine($"{helado.Id} - {helado.Sabor}");
            Console.WriteLine($"0 - Finalizar Pedido \n");
            var rpta = Console.ReadLine();

            var heladoSeleccionado = new Helado();
            if (rpta != "0")
            {
                heladoSeleccionado = listadoHelados.Where(x => x.Id == Int32.Parse(rpta)).First();
                factura.DetalleHelados.Add(heladoSeleccionado);
            }

            cerrar = rpta.ToUpper().Equals("0");
        } while (!cerrar);
    }

    #endregion

    #region Adicionales
    static void Adicionales()
    {
        var cerrar = false;
        do
        {
            Console.Clear();
            Console.WriteLine("Escoja un adicional");
            foreach (var adicional in listadoAdicionales)
                Console.WriteLine($"{adicional.Id} - {adicional.Nombre}");
            Console.WriteLine($"0 - Finalizar Pedido \n");
            var rpta = Console.ReadLine();

            var adicionalSeleccionado = new Adicional();
            if (rpta != "0")
            {
                adicionalSeleccionado = listadoAdicionales.Where(x => x.Id == Int32.Parse(rpta)).First();
                factura.DetalleAdicionales.Add(adicionalSeleccionado);
            }

            cerrar = rpta.ToUpper().Equals("0");
        } while (!cerrar);
    }
    #endregion

    #region Pago
    static void Pago()
    {
        var count = 1;
        Console.Clear();
        StringWriter stringWriter = new StringWriter();
        TextWriter originalConsoleOut = Console.Out;
        Console.SetOut(stringWriter);

        FacturaEncabezado();
        Console.WriteLine();
        Console.WriteLine($"# | CODIGO | PRODUCTO | VALOR");
        foreach (var d in factura.DetalleHelados)
            Console.WriteLine($"{count++} |  {d.Id}  | {d.Sabor.Substring(0, 4)} | ${d.Valor}");
        Console.WriteLine("\nADICIONALES:");
        foreach (var a in factura.DetalleAdicionales)
            Console.WriteLine($"{count++} |  {a.Id}  | {a.Nombre.Substring(0, 4)} | ${a.Valor}");
        Console.WriteLine();

        var total = factura.DetalleHelados.Sum(x => x.Valor) + factura.DetalleAdicionales.Sum(x => x.Valor);
        FacturaPieDePagina(total);

        string salidaCapturada = stringWriter.ToString();
        Console.SetOut(originalConsoleOut);
        CrearFactura(nombre, salidaCapturada);
    }

    static void FacturaEncabezado()
    {
        Console.WriteLine("-------------------");
        Console.WriteLine($"{DateTime.Now.ToString("d/M/yyyy hh:mm:ss")}");
        Console.WriteLine("-------------------");
        Console.WriteLine("FACTURA DE VENTA");
        Console.WriteLine("HELADERIA ICE");
        Console.WriteLine("-------------------");
        Console.WriteLine($"Cliente: {nombre}");
        Console.WriteLine("-------------------");
        Console.WriteLine("-------------------");
        Console.WriteLine($"Items:");
    }

    static void FacturaPieDePagina(int _total)
    {
        var iva = _total * 0.19;
        var subtotal = _total - iva;

        Console.WriteLine("-------------------");
        Console.WriteLine("-------------------");
        Console.WriteLine($"IVA ${iva}");
        Console.WriteLine($"SUBTOTAL ${subtotal}");
        Console.WriteLine($"TOTAL ${_total}");
        Console.WriteLine("-------------------");
        Console.WriteLine("-------------------");
    }

    static void CrearFactura(string _nombre, string _content)
    {

        string path = @$"C:\Users\jleon\Desktop\factura_{_nombre}.txt";
        if (!File.Exists(path))
        {
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine(_content);
            }
        }
    }
    #endregion

    static void CargueHelados()
    {
        var id = 1;
        var sabores = new string[] { "Fresa", "mora", "melocoton", "guanabana", "piña" };
        foreach (string s in sabores)
        {
            var addHelado = new Helado(id++, s, ran.Next(1000, 5000), ran.Next(50, 300));
            addHelado.Creado = DateTime.Now;
            addHelado.CreadoPor = "Juan";
            listadoHelados.Add(addHelado);
        }

        factura.DetalleHelados = new List<Helado>();
    }

    static void CargueAdicionales()
    {
        var characters = new List<char> { 'a', 'b', 'c', 'd', '1', '6', '9', '4' };
        var id = 1;
        var adicionales = new string[] { "Salsa Chocolate", "Gomitas", "chips" };

        var code = "";
        for (int i = 0; i < 4; i++)
            code += characters[ran.Next(0, characters.Count)];

        foreach (string a in adicionales)
        {
            var addAdicional = new Adicional()
            {
                Id = id++,
                Code = code,
                Nombre = a,
                Valor = ran.Next(0, 1) == 1 ? 500 : 1000
            };
            listadoAdicionales.Add(addAdicional);
        }
        factura.DetalleAdicionales = new List<Adicional>();
    }
}

