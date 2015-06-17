namespace ObligatorioIS2
{
    public class Usuario
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Password { get; set; }
        public string Direccion { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }


        public override string ToString()
        {
            return string.Format("{0}, {1}", Nombre, Apellido);
        }

    }

}
