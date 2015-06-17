namespace ObligatorioIS2
{
    public class Producto
    {
        public string Nombre { get; set; }
        public string Precio { get; set; }
        public string Codigo { get; set; }
        public string Rubro { get; set; }
        public string Tipo { get; set; }
        public string Modelo { get; set; }
        public string Especificacion { get; set; }
        public string Descripcion { get; set; }
        public string PathImagen { get; set; }

        public override string ToString()
        {
            return string.Format("{0}  {1}", Nombre, Precio);
        }
    }
}
