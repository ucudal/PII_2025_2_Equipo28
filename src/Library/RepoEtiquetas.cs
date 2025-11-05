using System.Collections.Generic;
using System.Reflection.Metadata;

namespace Library
{
    public class RepoEtiquetas
    {
        //Por si acaso hay que usarlo, lo comento.
        // private Dictionary<string, List<Cliente>> Etiquetas = new Dictionary<string, List<Cliente>>();
        //
        // public void AgregarEtiqueta(string etiqueta)
        // {
        //     if (!(Etiquetas.ContainsKey(etiqueta)))
        //     {
        //         Etiquetas.Add(etiqueta,new List<Cliente>());
        //     }
        // }
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