using PastelStore.MVC.ViewModel;
using System;
using System.Collections.Generic;

namespace PastelStore.MVC.Repositorio
{
    public class UsuarioRepositorio
    {
        static List<UsuarioViewModel> listaDeUsuario = new List<UsuarioViewModel>();
        public UsuarioViewModel Inserir(UsuarioViewModel usuario){
            usuario.Id = listaDeUsuario.Count + 1;
            usuario.DataCriacao = DateTime.Now;

            listaDeUsuario.Add(usuario);

            return usuario;
        }

        public List<UsuarioViewModel> Listar(){
            return listaDeUsuario;
        }
        public UsuarioViewModel BuscarUsuario(string email, string senha){
            foreach (var item in listaDeUsuario)
            {
                if (email.Equals(item.Email) && senha.Equals(item.Senha))
                {
                    return item;
                }
            }
            return null;
        }//Fim efetuar login
    }
}