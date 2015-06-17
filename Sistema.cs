using System.Collections.Generic;

namespace ObligatorioIS2
{
    public class Sistema
    {
        private static readonly Sistema Instance = new Sistema();

        public List<Producto> ListaProductos { get; set; }
        public List<Usuario> ListaUsuarios { get; set; }

        private Sistema() { }

        public static Sistema GetInstance()
        {
            return Instance;
        }

    }
}
