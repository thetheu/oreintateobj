using System;

namespace desafio1
{
    public class Produto
    {
        static Produto[] ArrayDeProdutos = new Produto[50];
        static int contador = 0;
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Preco { get; set; }
        public string Categoria { get; set; }
        public DateTime DataCriacao { get; set; }

        public static void CadastrarProduto()
        {

            int id;
            string nome;
            string descricao;
            int preco;
            string categoria;
            DateTime DataCriacao;

            Console.WriteLine("Defina uma nome para este produto");
            nome = Console.ReadLine();

            Console.WriteLine("Descreva seu produto");
            descricao = Console.ReadLine();

            Console.WriteLine("Estabeleça um preço para o produto");
            preco = int.Parse(Console.ReadLine());

            Console.WriteLine("Determine a categoria do seu produto");
            categoria = Console.ReadLine();

            Produto tipo = new Produto();
            tipo.Id = contador + 1;
            tipo.Nome = nome;
            tipo.Descricao = descricao;
            tipo.Categoria = categoria;
            tipo.DataCriacao = DateTime.Now;
            tipo.Preco = preco;

            ArrayDeProdutos[contador] = tipo;

            contador++;
        }

        public static void ListarProdutos()
        {
            foreach (var item in ArrayDeProdutos)
            {
                if (item != null)
                {
                    Console.WriteLine($"ID: {item.Id}");
                    Console.WriteLine($"nome: {item.Nome}");
                    Console.WriteLine($"{item.Preco}");
                }

            }
        }

        public static void BuscarID()
        {
            int IDprocurado = 0;
            Console.WriteLine("Digite o ID do produto");
            IDprocurado = int.Parse(Console.ReadLine());
            
            foreach (var item in ArrayDeProdutos){
                if (item == null){
                    break;
                }
                if (IDprocurado == item.Id)
                {
                    Console.WriteLine($"{item.Id}");
                    Console.WriteLine($"{item.Nome}");
                    Console.WriteLine($"{item.Descricao}");
                    Console.WriteLine($"{item.Categoria}");
                    Console.WriteLine($"{item.DataCriacao}");
                }
            } 
            
            
        }
    }
}