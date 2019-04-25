using System;
using Senaizinho_2_Tarde.enums;

namespace Senaizinho_2_Tarde
{
    class Program
    {
        static void Main (string[] args) {
            int limiteAlunos = 3;
            int limiteSalas = 2;

            Aluno[] alunos = new Aluno[limiteAlunos];
            Sala[] salas = new Sala[limiteSalas];

            int alunosCadastrados = 0;
            int salasCadastradas = 0;

            bool querSair = false;
            do {
                Console.Clear ();
                #region MENU
                System.Console.WriteLine ("===================================");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                System.Console.WriteLine ("        *** SENAIzinho ***         ");
                Console.ResetColor ();
                System.Console.WriteLine ("         Seja bem-vindo(a)         ");
                System.Console.WriteLine ("===================================");
                System.Console.WriteLine ("|| Digite sua opção:             ||");
                System.Console.WriteLine ("||  1 - Cadastrar Aluno          ||");
                System.Console.WriteLine ("||  2 - Cadastrar Sala           ||");
                System.Console.WriteLine ("||  3 - Alocar Aluno             ||");
                System.Console.WriteLine ("||  4 - Remover Aluno            ||");
                System.Console.WriteLine ("||  5 - Listar Salas             ||");
                System.Console.WriteLine ("||  6 - Listar Alunos            ||");
                System.Console.WriteLine ("||  0 - Sair                     ||");
                System.Console.WriteLine ("===================================");
                #endregion

                System.Console.Write ("Código: ");
                int codigo = int.Parse (Console.ReadLine ());
                string mensagem = "";

                switch (codigo) {
                    #region CADASTRAR_ALUNO
                    case 1:
                    if (limiteAlunos != alunosCadastrados) {

                        Aluno aluno = new Aluno ();

                        System.Console.WriteLine ("Digite o nome do aluno");
                        aluno.Nome = Console.ReadLine ();

                        System.Console.WriteLine ("Digite a data de nascimento (dd/mm/aaaa)");
                        aluno.DataNascimento = DateTime.Parse (Console.ReadLine ());

                        System.Console.WriteLine ("Digite o nome do curso");
                        aluno.Curso = Console.ReadLine ();

                        alunos[alunosCadastrados] = aluno;

                        alunosCadastrados++;

                        MostrarMensagem($"Cadastro de {aluno.GetType().Name} feito com sucesso!", TipoMensagemEnum.SUCESSO);
                    } else {
                        MostrarMensagem($"Total de alunos foi excedido!", TipoMensagemEnum.ALERTA);
                    }

                        break;
                    #endregion
                    #region CADASTRAR_SALA
                    case 2:
                    if (limiteSalas != salasCadastradas) 
                    {
                        System.Console.WriteLine ("Digite o número da sala");
                        int numeroSalaCadastrar = int.Parse (Console.ReadLine ());
 
                        System.Console.WriteLine ("Digite a capacidade total");
                        int CapacidadeTotalCadastrar = int.Parse (Console.ReadLine ());


                        Sala sala = new Sala(numeroSalaCadastrar, CapacidadeTotalCadastrar);

                        salas[salasCadastradas] = sala;

                        salasCadastradas++;

                        MostrarMensagem($"Cadastro de {sala.GetType().Name} feito com sucesso!", TipoMensagemEnum.SUCESSO);
                    } else {
                        MostrarMensagem($"Número de salas foi excedido!", TipoMensagemEnum.ALERTA);
                    }

                        break;
                    #endregion
                    #region ALOCAR_ALUNO
                    case 3:
                        ValidarAlocarOuRemover(alunosCadastrados, salasCadastradas);

                        System.Console.WriteLine ("Digite o nome do aluno");
                        string nomeAluno = Console.ReadLine ();
                        Aluno alunoRecuperado = ProcurarAlunoPorNome(nomeAluno, alunos);
                        

                        if (alunoRecuperado == null) {
                            MostrarMensagem($"Aluno {nomeAluno} não encontrado!", TipoMensagemEnum.ALERTA);
                            continue;
                        }

                        // Recupera o numero da sala
                        System.Console.WriteLine ("Digite o número da sala");
                        int numeroSala = int.Parse (Console.ReadLine ());

                        // Busca pela Sala correta
                        Sala salaRecuperada = ProcurarSalaPorNumero(numeroSala, salas);

                        if (salaRecuperada == null) {
                            MostrarMensagem($"Sala {numeroSala} não encontrada!", TipoMensagemEnum.ALERTA);
                            continue;
                        }

                        if(salaRecuperada.AlocarAluno (alunoRecuperado, out mensagem)){
                            MostrarMensagem(mensagem, TipoMensagemEnum.SUCESSO);
                        } else {
                            MostrarMensagem(mensagem, TipoMensagemEnum.ERRO);
                        }

                        salaRecuperada.AlocarAluno (alunoRecuperado, out mensagem);

                        break;
                    #endregion
                    #region REMOVER_ALUNO
                    case 4:
                        ValidarAlocarOuRemover(alunosCadastrados, salasCadastradas);

                        System.Console.WriteLine ("Digite o nome do aluno");
                        string nomeAlunoRemover = Console.ReadLine ();

                        Aluno alunoRemover = ProcurarAlunoPorNome(nomeAlunoRemover, alunos);

                        if (alunoRemover == null) {
                            MostrarMensagem($"Aluno {nomeAlunoRemover} não encontrado!", TipoMensagemEnum.ALERTA);
                            continue;
                        }

                        // Recupera o numero da sala
                        System.Console.WriteLine ("Digite o número da sala");
                        int numeroSalaRemover = int.Parse (Console.ReadLine ());

                        // Busca pela Sala correta
                        Sala salaRemover = ProcurarSalaPorNumero(numeroSalaRemover, salas);
                        

                        if (salaRemover == null) {
                            MostrarMensagem($"Sala {numeroSalaRemover} não encontrada!", TipoMensagemEnum.ALERTA);
                            continue;
                        }
                        
                        if (salaRemover.RemoverAluno (alunoRemover.Nome, out mensagem)) {
                            MostrarMensagem(mensagem, TipoMensagemEnum.SUCESSO);
                        } else {
                            MostrarMensagem(mensagem, TipoMensagemEnum.ERRO);
                        }
                        
                        break;
                    #endregion
                    #region LISTAR_SALAS
                    case 5:
                        foreach (var item in salas) {
                            if (item != null) {
                                System.Console.WriteLine ("-----------------------------------------------------");
                                System.Console.WriteLine ($"Número da sala: {item.NumeroSala}");
                                System.Console.WriteLine ($"Vagas disponíveis: {item.CapacidadeAtual}");
                                System.Console.WriteLine ($"Alunos: {item.ExibirAlunos()}");
                                System.Console.WriteLine ("-----------------------------------------------------");
                            }
                        }

                        System.Console.WriteLine ("Aperte ENTER para voltar ao menu principal");
                        Console.ReadLine ();
                        break;
                    #endregion
                    #region LISTAR_ALUNOS
                    case 6:
                        foreach (var item in alunos) {
                            if (item != null) {
                                System.Console.WriteLine ("-----------------------------------------------------");
                                System.Console.WriteLine ($"Nome do aluno: {item.Nome}");
                                System.Console.WriteLine ($"Curso: {item.Curso}");
                                System.Console.WriteLine ("-----------------------------------------------------");
                            }
                        }
                        System.Console.WriteLine ("Aperte ENTER para voltar ao menu principal");
                        Console.ReadLine ();

                        break;
                    #endregion

                }

            } while (!querSair);
        }
    
        static void MostrarMensagem(string mensagem, TipoMensagemEnum tipoMensagem) 
        {
            switch(tipoMensagem) {
                case TipoMensagemEnum.SUCESSO:
                    Console.ForegroundColor = ConsoleColor.Green;
                break;
                case TipoMensagemEnum.ERRO:
                    Console.ForegroundColor = ConsoleColor.Red;
                break;
                case TipoMensagemEnum.ALERTA:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                break;
                case TipoMensagemEnum.DESTAQUE:
                    Console.ForegroundColor = ConsoleColor.Blue;
                break;
            }

            System.Console.WriteLine (mensagem);
            Console.ResetColor ();

            System.Console.WriteLine ("Aperte ENTER para voltar ao menu");
            Console.ReadLine ();
        }

        static bool ValidarAlocarOuRemover(int alunosCadastrados, int salasCadastradas) 
        {
            if (alunosCadastrados == 0) {
                MostrarMensagem("Nenhum aluno cadastrado!", TipoMensagemEnum.ALERTA);
                return false;
            } else if (salasCadastradas == 0) {
                MostrarMensagem("Nenhuma sala cadastrada!", TipoMensagemEnum.ALERTA);
                return false;
            }

            return true;
        }

        static Aluno ProcurarAlunoPorNome(string nomeAluno, Aluno[] alunos)
        {
            foreach (Aluno item in alunos) {
                if (item != null && nomeAluno.Equals (item.Nome)) {
                    return item;
                    
                }
            }

            return null;
        }

        static Sala ProcurarSalaPorNumero(int numeroSala, Sala[] salas)
        {
            foreach (Sala item in salas) {
                if (item != null && numeroSala.Equals (item.NumeroSala)) {
                    return item;
                }
            }
            return null;
        }
    
    
    }
}