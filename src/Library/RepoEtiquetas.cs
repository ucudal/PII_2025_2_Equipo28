using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace Library
{
    /// <summary>
    /// - Expert: porque es responsable de gestionar la lista de etiquetas.
    /// - SRP: tiene una única responsabilidad: gestionar etiquetas en el sistema.
    /// - Alta Cohesión: todos sus métodos y atributos pertenecen al propósito de gestionar etiquetas.
    /// </summary>
    public class RepoEtiquetas
    {
        private List<string> etiquetas = new List<string>();

        private IEnumerable<string> Etiquetas
        {
            get { return etiquetas; }
        }
        
        /// <summary>
        /// Agrega una etiqueta a la lista de etiquetas
        /// </summary>
        /// <param name="etiqueta">Etiqueta a agregar</param>
        public void AgregarEtiqueta(string etiqueta)
        {
            if (string.IsNullOrWhiteSpace(etiqueta))
            {
                throw new ArgumentNullException("La etiqueta no puede ser null o vacia.");
            }

            if (etiquetas.Contains(etiqueta))
            {
                throw new ArgumentException($"La etiqueta {etiqueta} ya existe.");
            }
            
            etiquetas.Add(etiqueta);
        }

        /// <summary>
        /// Busca una etiqueta en la lista de etiquetas
        /// </summary>
        /// <param name="etiqueta">Etiqueta a buscar</param>
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

        /// <summary>
        /// Elimina todoas las etiquetas del repo de etiquetas
        /// </summary>
        public void EliminarDatos()
        {
            this.etiquetas.Clear();
        }
    }
}