using System.Drawing;
using System.Reflection;

namespace ObligatorioIS2.Helpers
{
    public static class Helpers
    {
        public static Image GetPathImagen(string pathImagen)
        {
            var imgStream = Assembly.GetExecutingAssembly()
                .GetManifestResourceStream(string.Format("ObligatorioIS2.images.{0}", pathImagen));
            using (imgStream)
            {
                return imgStream == null ? null : new Bitmap(imgStream);
            }
        }
    }
}
