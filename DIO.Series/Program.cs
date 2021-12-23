using DIO.Series.Classes;
using System;

namespace DIO.Series
{
    internal class Program
    {
        static SerieRepository repository = new SerieRepository();

        static void Main(string[] args)
        {


            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizaSerie();
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
                        throw new ArgumentException("erro");

                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Hello World!");
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar Series");

            var lista = repository.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série encontrada");
            }

            foreach (var serie in lista)
            {
    
                Console.WriteLine("#ID {0}: - {1}  {2} ", serie.retornaId(), serie.retornaTitulo(), serie.VerificaExcluido() ? "Excluido" : String.Empty);
            }
        }


        private static void InserirSerie()
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.Write("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome da Série: ");
            string nomeSerie = Console.ReadLine();

            Console.WriteLine("Digite o Ano de Inicio da Série: ");
            int anoInicio = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descricao da Série: ");
            string descricaoSerie = Console.ReadLine();

            Serie novaSerie = new Serie(id: repository.ProximoId(), genero: (Genero)entradaGenero, titulo: nomeSerie, ano: (int)anoInicio, descricao: descricaoSerie);

            repository.Insere(novaSerie);
        }

        private static void AtualizaSerie()
        {

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.Write("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o Id que deseja atualizar: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Digite o genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome da Série: ");
            string nomeSerie = Console.ReadLine();

            Console.WriteLine("Digite o Ano de Inicio da Série: ");
            int anoInicio = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descricao da Série: ");
            string descricaoSerie = Console.ReadLine();

            Serie serie = new Serie(id: id, genero: (Genero)entradaGenero, titulo: nomeSerie, ano: (int)anoInicio, descricao: descricaoSerie);

            repository.Atualizar(id, serie);
        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o Id que deseja excluir: ");
            int id = int.Parse(Console.ReadLine());

            repository.Excluir(id);
        }

        private static void VisualizarSerie()
        {
            Console.Write("Digite o Id que deseja visualizar: ");
            int id = int.Parse(Console.ReadLine());

            var serie = repository.RetornaPorId(id);

            Console.WriteLine(serie.ToString());
        }


        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Series a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");


            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
