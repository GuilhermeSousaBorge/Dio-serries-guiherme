using System;
using System.Collections.Generic;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = obterOpcaoUsuaio();

            while( opcaoUsuario.ToUpper() != "X"){
                switch(opcaoUsuario){
                    case "1":
                        ListarSerie();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = obterOpcaoUsuaio();
            }
        }

        private static void ListarSerie(){
            var lista = repositorio.Lista();
            Console.WriteLine("Listando Series...");
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma serie encontrada");
                return;
            }
            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                Console.WriteLine($"#ID {serie.retornaId()} - {serie.retornaTitulo()} {(excluido ? "*Excluido*" : "")}");
            }
        }

        private static void InserirSerie(){
            Console.WriteLine("Inserir nova serie");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}",i,Enum.GetName(typeof(Genero),i));
            }
            Console.WriteLine("Escolha o genero entre as opçoes acima");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Titulo da serie");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de lancamento da serie");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descricao da serie");
            string entradaDescricao = Console.ReadLine();

            Series novaSerie = new Series(id: repositorio.ProximoId(),
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            descricao: entradaDescricao,
                                            ano: entradaAno);
            repositorio.Insere(novaSerie);
        }


        public static void AtualizarSerie(){
            ListarSerie();
            Console.WriteLine("");
            Console.WriteLine("Digite o id da serie que deseja alterar:");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}",i,Enum.GetName(typeof(Genero),i));
            }
            Console.WriteLine("Escolha o genero entre as opçoes acima");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Titulo da serie");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de lancamento da serie");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descricao da serie");
            string entradaDescricao = Console.ReadLine();

            Series atualizaSerie = new Series(id: indiceSerie,
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            descricao: entradaDescricao,
                                            ano: entradaAno);
            repositorio.Atualiza(indiceSerie, atualizaSerie);
        
        }

        public static void ExcluirSerie(){
            ListarSerie();
            Console.WriteLine("");
            Console.WriteLine("Digite o id da serie que deseja excluir:");
            int indiceSerie = int.Parse(Console.ReadLine());
            repositorio.Exclui(indiceSerie);
        }

        public static void VisualizarSerie(){
            ListarSerie();
            Console.WriteLine("");
            Console.WriteLine("Digite o id da serie que deseja excluir:");
            int indiceSerie = int.Parse(Console.ReadLine());
            var serie = repositorio.RetornaPorId(indiceSerie);
            Console.WriteLine(serie);
        }
        public static string obterOpcaoUsuaio(){
            Console.WriteLine();
            Console.WriteLine("-----xX Informe a opçao desejada Xx-----");
            Console.WriteLine("1- Listar Series");
            Console.WriteLine("2- Inserir nova serie");
            Console.WriteLine("3- Atualizar serie");
            Console.WriteLine("4- Excluir serie");
            Console.WriteLine("5- Visualizar serie");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine("");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
