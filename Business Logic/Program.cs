using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ObligatorioIS2.View;

namespace ObligatorioIS2.Business_Logic
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            CargarListas();
            Application.Run(new MenuPpal());
        }

        private static void CargarListas()
        {
            Sistema.GetInstance().ListaUsuarios = new List<Usuario>
            {
                new Usuario
                {
                    Apellido = "Test",
                    Celular = "099112233",
                    Direccion = "18 de julio 1077",
                    Email = "test@test.com",
                    Nombre = "Test",
                    Password = "Test"
                },
                new Usuario{
                    Apellido = "Mustafa",
                    Celular = "094521455",
                    Direccion = "Mercedes 5544",
                    Email = "test@pruebas.com",
                    Nombre = "Mailen",
                    Password = "123456"
                
                },
                new Usuario{
                    Apellido = "Benitez",
                    Celular = "094521433",
                    Direccion = "Paraguay 4444",
                    Email = "test111@pruebas.com",
                    Nombre = "Patricia",
                    Password = "111111"
                
                }
            };

            Sistema.GetInstance().ListaProductos = new List<Producto>
            {
                new Producto
                {
                    Codigo = "1111",
                    Nombre = "Heladera",
                    Precio = "$12000",
                    Rubro = "Refrigeracion",
                    Tipo = "Linea blanca",
                    Modelo = "MRF-220Cs",
                    Especificacion = "Especificación 1",
                    Descripcion = "Enfriamiento dual. Capacidad 315lts. Color blanco.",
                    PathImagen = "heladera.jpg"
                    
                },
                new Producto
                {
                    Codigo = "2222",
                    Nombre = "Aspiradora",
                    Precio = "$2000",
                    Rubro = "Otros",
                    Tipo = "Pequeños electrodomésticos",
                    Modelo = "Cani-248",
                    Especificacion = "Especificación 2",
                    Descripcion = "Consumo: 1600W. Potencia Regulable. Cable retráctil.",
                    PathImagen = "aspiradora.jpg"
                },
                new Producto
                {
                    Codigo = "3333",
                    Nombre = "Licuadora",
                    Precio = "$800",
                    Rubro = "Otros",
                    Tipo = "Pequeños electrodomésticos",
                    Modelo = "KS-MIX4",
                    Especificacion = "Especificación 3",
                    Descripcion = "Potencia 400 watts. Vaso graduado 600ml. con tapa hermética.",
                    PathImagen = "licuadora.jpg"
                },
                new Producto
                {
                    Codigo = "4444",
                    Nombre = "Microondas",
                    Precio = "$3500",
                    Rubro = "Hornos",
                    Tipo = "Hornos",
                    Modelo = "Express 25",
                    Especificacion = "Especificación 4",
                    Descripcion = "11 niveles de potencia. Capacidad 25lts.Potencia de microondas: 800W.",
                    PathImagen = "microondas.jpg"
                },
                new Producto
                {
                    Codigo = "5555",
                    Nombre = "Lavarropas",
                    Precio = "$6000",
                    Rubro = "Lavarropas",
                    Tipo = "Linea blanca",
                    Modelo = "TWM-55AMS",
                    Especificacion = "Especificación 5",
                    Descripcion = "Capacidad: 5.5kg. Carga superior. Centrifugado de 700 rpm.",
                    PathImagen = "lavarropas.jpg"
                },
                new Producto
                {
                    Codigo = "6666",
                    Nombre = "Secarropas",
                    Precio = "$2000",
                    Rubro = "Secarropas",
                    Tipo = "Linea blanca",
                    Modelo = "Soleil GDZ5.0-61",
                    Especificacion = "Especificación 6",
                    Descripcion = "Tiempo de secado de 20 minutos a 220 minutos. Potencia: 1070W / 700W.",
                    PathImagen = "secarropas.jpg"
                }
            };
        }
    }
}
