using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TesteWebAPI.Models;

namespace TesteWebAPI.Controllers
{
    public class UsuarioController : ApiController
    {
        private static List<Usuario> usuarios = new List<Usuario>();

        [Authorize(Roles = "Admin, Supervisor")]
        public List<Usuario> Get()
        {
            return usuarios;
        }

        public void Post(string nome, string login, string senha, string role)
        {
            if(!string.IsNullOrEmpty(nome))
            usuarios.Add(new Usuario {nome = nome, login = login, senha = senha, role = role });
        }

        public void Delete(string nome)
        {
            usuarios.RemoveAt(usuarios.IndexOf(usuarios.First(x => x.nome.Equals(nome))));
        }
    }
}
