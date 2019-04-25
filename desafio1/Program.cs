using System;
using desafio1;

namespace DesafioPizzaria
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("PiTsuka");
            int resposta = 0;
            do
            {
                Console.WriteLine("Selecione uma opção");
                Console.WriteLine("1 - Cadastrar Novo Usuário");
                Console.WriteLine("2 - Efetuar Login");
                Console.WriteLine("3 - Listar Usuários");
                Console.WriteLine("9 - Sair");
                resposta = int.Parse(Console.ReadLine());

                switch (resposta)
                {
                    case 1:
                        //Cadastrar usuário
                        Usuario.Inserir();
                        break;

                    case 2:
                        //Login
                        Usuario.EfetuarLogin();
                        int resposta1 = 0;
                        do
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("Menu de Produtos");
                            Console.WriteLine("Selecione uma opção:");
                            Console.ResetColor();
                            Console.WriteLine("1 - Cadastrar Produto");
                            Console.WriteLine("2 - Listar Produtos");
                            Console.WriteLine("3 - Buscar Por ID");
                            Console.WriteLine("0 - Sair");
                            resposta1 = int.Parse(Console.ReadLine());

                            switch (resposta1)
                            {
                                case 1:
                                    Produto.CadastrarProduto();

                                    break;
                                case 2:
                                    Produto.ListarProdutos();

                                    break;
                                case 3:
                                    Produto.BuscarID();

                                    break;
                                default:
                                    Console.WriteLine("Escolha outra opção");
                                    break;
                            }

                        } while (resposta1 != 0);
                        break;
                    case 3:
                        //Listar usuário
                        Usuario.ListarUsuario();

                        break;

                    case 9:
                        //sair
                        break;
                    default:
                        Console.WriteLine("Valor Inválido!");
                        break;
                }

            } while (resposta != 9);
        }
    }
}