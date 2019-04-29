using System;
using PastelStore.MVC.ViewModel;
using PastelStore.MVC.Utils;
using PastelStore.MVC.ViewController;

namespace PastelStore.MVC
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcaoDeslogado = 0;
            do
            {
                // Menu Deslogado
                MenuUtil.MenuDeslogado();
                opcaoDeslogado = int.Parse(Console.ReadLine());

                switch (opcaoDeslogado)
                {
                    case 1:
                    //Cadastrar usuário
                    UsuarioViewController.CadastrarUsuario();
                    break;
                    case 2:
                    //Efetuar Login
                    UsuarioViewModel usuarioRetornado = UsuarioViewController.EfetuarLogin();
                    if (usuarioRetornado != null){
                    Console.WriteLine($"Bem vindo {usuarioRetornado.Nome}");
                    //Coloar o menu Logado
                    }
                    break;
                    case 3:
                    //Listar usuários Cadastrados
                    UsuarioViewController.ListarUsuario();
                    break;
                    case 0:
                    //Sair
                    break;
                    default:
                    Console.WriteLine("Opção Inválida");
                    break;
                }
            } while (opcaoDeslogado != 0);
        }
    }
}