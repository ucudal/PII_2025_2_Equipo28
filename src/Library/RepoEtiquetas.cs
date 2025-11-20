using System.Collections.Generic;
using System.Reflection.Metadata;

namespace Library
{
    public class RepoEtiquetas
    {
        private List<string> etiquetas = new List<string>();

        public IEnumerable<string> Etiquetas
        {
            get { return etiquetas; }
        }
        
        public void AgregarEtiqueta(string etiqueta)
        {
            if (!(etiquetas.Contains(etiqueta)))
            {
                etiquetas.Add(etiqueta);
            }
        }

        public bool BuscarEtiqueta(string etiqueta)
        {
            if (etiquetas.Contains(etiqueta))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void EliminarDatos()
        {
            this.etiquetas.Clear();
        }
    }
}