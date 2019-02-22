using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteWebAPI.Models
{
    public class Usuario
    {
        public string nome { get; set; }
        public string login { get; set; }
        public string senha { get; set; }
        public string role { get; set; }



        public Usuario Get(string login, string senha)
        {
            List<Usuario> usuarios = new List<Usuario> {
                new Usuario() { nome = "rodrigo", login = "rodrigo@email.com", senha = "1234", role = "supervisor" },
                new Usuario() { nome = "Souza", login = "souza", senha = "1234", role = "gerente" }
            };
            

            return usuarios.Find(x => x.login.Equals(login) && x.senha.Equals(senha));
        }


    }
}