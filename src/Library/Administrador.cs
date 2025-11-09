using System;
using System.Collections.Generic;

namespace Library
{
    // SRP: Su responsabilidad única sería “administrar la creación y gestión de usuarios, vendedores y administradores”,
    // no manejar datos de otras cosas fuera de eso.
    //Expert: La clase es la experta en crear y agregar objetos relacionados, porque tiene acceso a toda
    //la información necesaria para instanciarlos y registrarlos en las listas.
    public class Administrador : Usuario
    {
        public List<Usuario> UsuariosSuspendidos = new List<Usuario>();

        public Administrador(string id, string nombre) : base(id, nombre)
        {
            this.ID = id;
            this.Nombre = nombre;
        }
    }
}
