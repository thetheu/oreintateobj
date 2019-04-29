using System;
using Senaizinho_2_Tarde.enums;

namespace Senaizinho_2_Tarde {
    class Program {
    enum MenuEnum : uint {
    CADASTRAR_ALUNO = 1,
    CADASTRAR_SALA,
    LISTAR_ALUNOS,
    LISTAR_SALAS,
    ALOCAR_ALUNO,
    REMOVER_ALUNO
        }
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
                //HEADER

                string[] itensMenu = Enum.GetNames(typeof(MenuEnum));
                string barraMenu = "===================================";
                System.Console.WriteLine(barraMenu);
                Console.BackgroundColor = ConsoleColor.DarkRed;
                System.Console.WriteLine ("        *** SENAIzinho ***         ");
                Console.ResetColor ();
                System.Console.WriteLine ("         Seja bem-vindo(a)         ");
                System.Console.WriteLine (barraMenu);
                System.Console.WriteLine ("|| Digite sua opção:             ||");
                //BODY
                for (int i = 0; i < itensMenu.Length; i++) {
                    string espacosFim = "";
                    string bordaLinha = "||";
                    string paragrafoInicio = "   ";
                    string separadorOpcao = " - ";

                    string nomeTratado = itensMenu[i].Replace ("_", " ").ToLower ();
                    nomeTratado = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase (nomeTratado);
                    int espacoDezena = i / 10;

                    string numeroOpcao = (i + 1).ToString ();

                    if (espacoDezena < 1) {
                        paragrafoInicio = paragrafoInicio + " ";
                    }

                    int qntdeEspacos = barraMenu.Length - (bordaLinha.Length * 2) - paragrafoInicio.Length - numeroOpcao.Length - separadorOpcao.Length - nomeTratado.Length;

                    for (int j = 0; j < qntdeEspacos; j++) {
                        espacosFim += " ";
                    }

                    System.Console.WriteLine ($"{bordaLinha}{paragrafoInicio}{numeroOpcao}{separadorOpcao}{nomeTratado}{espacosFim}{bordaLinha}");
                }
                //FOOTER
                System.Console.WriteLine ("||  0 - Sair                     ||");
                System.Console.WriteLine (barraMenu);
                #endregion

                System.Console.Write ("Código: ");
                MenuEnum codigo = (MenuEnum) Enum.Parse(typeof(MenuEnum), Console.ReadLine());
                string mensagem = "";

                switch (codigo) {
                        #region CADASTRAR_ALUNO
                    case MenuEnum.CADASTRAR_ALUNO:
                        if (limiteAlunos != alunosCadastrados) {

                            Aluno aluno = new Aluno ();

                            System.Console.WriteLine ("Digite o nome do aluno");
                            aluno.Nome = Console.ReadLine ();

                            System.Console.WriteLine ("Digite a data de nascimento (dd/mm/aaaa)");
                            aluno.DataNascimento = DateTime.Parse (Console.ReadLine ());

                            aluno.Curso = ExibirMenuCurso ();

                            alunos[alunosCadastrados] = aluno;

                            alunosCadastrados++;

                            MostrarMensagem ($"Cadastro de {aluno.GetType().Name} feito com sucesso!", TipoMensagemEnum.SUCESSO);
                        } else {
                            MostrarMensagem ($"Total de alunos foi excedido!", TipoMensagemEnum.ALERTA);
                        }

                        break;
                        #endregion
                        #region CADASTRAR_SALA
                    case MenuEnum.CADASTRAR_SALA:
                        if (limiteSalas != salasCadastradas) {
                            System.Console.WriteLine ("Digite o número da sala");
                            int numeroSalaCadastrar = int.Parse (Console.ReadLine ());

                            System.Console.WriteLine ("Digite a capacidade total");
                            int CapacidadeTotalCadastrar = int.Parse (Console.ReadLine ());

                            Sala sala = new Sala (numeroSalaCadastrar, CapacidadeTotalCadastrar);

                            salas[salasCadastradas] = sala;

                            salasCadastradas++;

                            MostrarMensagem ($"Cadastro de {sala.GetType().Name} feito com sucesso!", TipoMensagemEnum.SUCESSO);
                        } else {
                            MostrarMensagem ($"Número de salas foi excedido!", TipoMensagemEnum.ALERTA);
                        }

                        break;
                        #endregion
                        #region ALOCAR_ALUNO
                    case MenuEnum.ALOCAR_ALUNO:
                        ValidarAlocarOuRemover (alunosCadastrados, salasCadastradas);

                        System.Console.WriteLine ("Digite o nome do aluno");
                        string nomeAluno = Console.ReadLine ();
                        Aluno alunoRecuperado = ProcurarAlunoPorNome (nomeAluno, alunos);

                        if (alunoRecuperado == null) {
                            MostrarMensagem ($"Aluno {nomeAluno} não encontrado!", TipoMensagemEnum.ALERTA);
                            continue;
                        }

                        // Recupera o numero da sala
                        System.Console.WriteLine ("Digite o número da sala");
                        int numeroSala = int.Parse (Console.ReadLine ());

                        // Busca pela Sala correta
                        Sala salaRecuperada = ProcurarSalaPorNumero (numeroSala, salas);

                        if (salaRecuperada == null) {
                            MostrarMensagem ($"Sala {numeroSala} não encontrada!", TipoMensagemEnum.ALERTA);
                            continue;
                        }

                        if (salaRecuperada.AlocarAluno (alunoRecuperado, out mensagem)) {
                            MostrarMensagem (mensagem, TipoMensagemEnum.SUCESSO);
                        } else {
                            MostrarMensagem (mensagem, TipoMensagemEnum.ERRO);
                        }

                        salaRecuperada.AlocarAluno (alunoRecuperado, out mensagem);

                        break;
                        #endregion
                        #region REMOVER_ALUNO
                    case MenuEnum.REMOVER_ALUNO:
                        ValidarAlocarOuRemover (alunosCadastrados, salasCadastradas);

                        System.Console.WriteLine ("Digite o nome do aluno");
                        string nomeAlunoRemover = Console.ReadLine ();

                        Aluno alunoRemover = ProcurarAlunoPorNome (nomeAlunoRemover, alunos);

                        if (alunoRemover == null) {
                            MostrarMensagem ($"Aluno {nomeAlunoRemover} não encontrado!", TipoMensagemEnum.ALERTA);
                            continue;
                        }

                        // Recupera o numero da sala
                        System.Console.WriteLine ("Digite o número da sala");
                        int numeroSalaRemover = int.Parse (Console.ReadLine ());

                        // Busca pela Sala correta
                        Sala salaRemover = ProcurarSalaPorNumero (numeroSalaRemover, salas);

                        if (salaRemover == null) {
                            MostrarMensagem ($"Sala {numeroSalaRemover} não encontrada!", TipoMensagemEnum.ALERTA);
                            continue;
                        }

                        if (salaRemover.RemoverAluno (alunoRemover.Nome, out mensagem)) {
                            MostrarMensagem (mensagem, TipoMensagemEnum.SUCESSO);
                        } else {
                            MostrarMensagem (mensagem, TipoMensagemEnum.ERRO);
                        }

                        break;
                        #endregion
                        #region LISTAR_SALAS
                    case MenuEnum.LISTAR_SALAS:
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
                    case MenuEnum.LISTAR_ALUNOS:
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

        static void MostrarMensagem (string mensagem, TipoMensagemEnum tipoMensagem) {
            switch (tipoMensagem) {
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

        static bool ValidarAlocarOuRemover (int alunosCadastrados, int salasCadastradas) {
            if (alunosCadastrados == 0) {
                MostrarMensagem ("Nenhum aluno cadastrado!", TipoMensagemEnum.ALERTA);
                return false;
            } else if (salasCadastradas == 0) {
                MostrarMensagem ("Nenhuma sala cadastrada!", TipoMensagemEnum.ALERTA);
                return false;
            }

            return true;
        }

        static Aluno ProcurarAlunoPorNome (string nomeAluno, Aluno[] alunos) {
            foreach (Aluno item in alunos) {
                if (item != null && nomeAluno.Equals (item.Nome)) {
                    return item;

                }
            }

            return null;
        }

        static Sala ProcurarSalaPorNumero (int numeroSala, Sala[] salas) {
            foreach (Sala item in salas) {
                if (item != null && numeroSala.Equals (item.NumeroSala)) {
                    return item;
                }
            }
            return null;
        }

        static string ExibirMenuCurso () {
            string curso = "";
            bool cursoNaoEscolhido = true;
            do {
                Console.WriteLine ("===================================");
                Console.WriteLine ("|| Digite o código do curso:     ||");
                Console.WriteLine ("||  1 - Desenvolvimento          ||");
                Console.WriteLine ("||  2 - Redes                    ||");
                Console.WriteLine ("===================================");
                Console.WriteLine ("Código");

                int codigoCurso = int.Parse (Console.ReadLine ());
                switch (codigoCurso) {
                    case 1:
                        curso = "Desenvolvimento";
                        cursoNaoEscolhido = false;
                        break;
                    case 2:
                        curso = "Redes";
                        cursoNaoEscolhido = false;
                        break;
                    default:
                        MostrarMensagem ("Esse código não existe", TipoMensagemEnum.ERRO);
                        break;
                }

            } while (cursoNaoEscolhido);
            return curso;
        }
    }
}