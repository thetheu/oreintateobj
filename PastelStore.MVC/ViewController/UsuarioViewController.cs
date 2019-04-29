using System;
using System.Collections.Generic;
using PastelStore.MVC.Repositorio;
using PastelStore.MVC.Utils;
using PastelStore.MVC.ViewModel;

namespace PastelStore.MVC.ViewController
{
    public class UsuarioViewController
    {
        //Instanciar o repositorio
        static UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio();
        public static void CadastrarUsuario()
        {
            string nome, email, senha, confirmaSenha;

            do{
                Console.WriteLine("Digite o nome do usuário");
                nome = Console.ReadLine();

                if (string.IsNullOrEmpty(nome)){
                    Console.WriteLine("Nome inválido");
                }

            } while (string.IsNullOrEmpty(nome));


            do{
                Console.WriteLine("Digite seu E-mail");
                email = Console.ReadLine();

                if (!ValidacoesUtil.ValidadorDeEmail(email))
                {
                    Console.WriteLine("Email inválido");
                }
            } while (!ValidacoesUtil.ValidadorDeEmail(email));

            do
            {
                Console.WriteLine("Digite a senha");
                senha = Console.ReadLine();

                Console.WriteLine("Redigite a senha");
                confirmaSenha = Console.ReadLine();

                if(!ValidacoesUtil.ValidadorDeSenha(senha, confirmaSenha)){
                    Console.WriteLine("Senha inválida");
                }
            } while (!ValidacoesUtil.ValidadorDeSenha(senha, confirmaSenha));

            UsuarioViewModel usuarioViewModel = new UsuarioViewModel();
            usuarioViewModel.Nome = nome;
            usuarioViewModel.Email = email;
            usuarioViewModel.Senha = senha;


            usuarioRepositorio.Inserir(usuarioViewModel);

            Console.WriteLine("Usuário Cadastrado com sucesso");
        }//Fim cadastro do usuário


        public static void ListarUsuario(){
        List<UsuarioViewModel> ListarUsuario = usuarioRepositorio.Listar();

        foreach (var item in ListarUsuario)
        {
            Console.WriteLine($"Id: {item.Id}");
            Console.WriteLine($"Nome: {item.Nome}");
            Console.WriteLine($"Senha {item.Senha}");
            Console.WriteLine($"Data de Criação {item.DataCriacao}");
        } 
       }//Fim Listar Usuario

       public static UsuarioViewModel EfetuarLogin(){
           string email, senha;
            do
            {
                Console.WriteLine("Digite o email");
                email = Console.ReadLine();
                
                if(!ValidacoesUtil.ValidadorDeEmail(email)){
                    Console.WriteLine("Email Inválido");
                }
            } while (!ValidacoesUtil.ValidadorDeEmail(email));

            Console.WriteLine("Digite sua Senha:");
            senha = Console.ReadLine();

            UsuarioViewModel usuarioRetornado = usuarioRepositorio.BuscarUsuario(email,senha);

            if (usuarioRetornado != null)
            {
                return usuarioRetornado;
            }else{
                Console.WriteLine($"Usuário ou Senha inválida");
                return null;
            }

       }//Fim efetuar login
    }
}