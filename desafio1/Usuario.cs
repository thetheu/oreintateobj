using System;

namespace DesafioPizzaria
{
    public class Usuario
    {

        static Usuario[] ArrayDeUsuarios = new Usuario[1000];
        static int contador = 0;
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataCriacao { get; set; }

        public static void Inserir()
        {
            string nome;
            string email;
            string senha;

            Console.WriteLine("Digite o nome do usuário");
            nome = Console.ReadLine();
            //validação de email
            do
            {

                Console.WriteLine("Digite o Email");
                email = Console.ReadLine();
                if (!email.Contains("@") || !email.Contains("."))
                {
                    Console.WriteLine("Email inválido");
                }
            } while (!email.Contains("@") || !email.Contains("."));
            //validação de senha
            do
            {
                Console.WriteLine("Digite a senha:");
                senha = Console.ReadLine();

                if (senha.Length < 6)
                {
                    Console.WriteLine("Senha Inválida");
                }

            } while (senha.Length < 6);
            //Efetuar o registro

            Usuario user = new Usuario();
            user.Id = contador + 1;
            user.Nome = nome;
            user.Email = email;
            user.Senha = senha;
            user.DataCriacao = DateTime.Now;

            ArrayDeUsuarios[contador] = user;

            contador++;
        }//fim iserir

        public static void EfetuarLogin()
        {
            string email;
            string senha;
            bool logado = true;
            do {

                Console.WriteLine($"Digite o email");
                email = Console.ReadLine();
                Console.WriteLine("Digite a senha");
                senha = Console.ReadLine();

                foreach (var item in ArrayDeUsuarios)
                {
                if(item == null){
                    break;
                }
                    if (email.Equals(item.Email) && senha.Equals(item.Senha))
                    {
                        Console.WriteLine("Bem vindo a Matrix");
                        return;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Email ou senha Inválida");
                        Console.ResetColor();
                        logado = false;
                    }
                }

            }
            while (true);
            {

            }


        }
        public static void ListarUsuario()
        {
            foreach (var item in ArrayDeUsuarios)
            {
                if (item != null)
                {
                    Console.WriteLine($"ID: {item.Id} nome: {item.Nome}");
                }
            }
        }
    }
}