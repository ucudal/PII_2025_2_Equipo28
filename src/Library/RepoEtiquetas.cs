using System.Collections.Generic;
using System.Reflection.Metadata;

namespace Library
{
    public class RepoEtiquetas
    {
        private List<string> Etiquetas = new List<string>();
        public void AgregarEtiqueta(string etiqueta)
        {
            if (!(Etiquetas.Contains(etiqueta)))
            {
                Etiquetas.Add(etiqueta);
            }
        }

        public bool BuscarEtiqueta(string etiqueta)
        {
            if (Etiquetas.Contains(etiqueta))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}