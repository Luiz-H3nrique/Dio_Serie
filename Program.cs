using System;
using Dio_series.classes;

namespace Dio_series
{
    class Program
    {
        static SerieRepositorio repositorio = new  SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() !="X") 
            {
                switch (opcaoUsuario)
                {
                   
                    case "1":
                        listarSerie();
                        break;
                     case "2":
                        InsereSerie();
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
                     case "c":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar Nossos Serviços. ");
            Console.ReadLine();
        }

        private static void listarSerie()
        {
            Console.WriteLine("Lista série");
            var lista = repositorio.Lista();

            if(lista.Count ==  0)
            {
                Console.WriteLine("Nenhuma série  cadastrada. ");
                return;
            }
            foreach (var Serie in lista)
            {
                var excluido = Serie.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} {2}" , Serie.retonaId(), Serie.retornaTitulo(), (excluido ? " *Excluido* " : ""));
            }
        }

        private static void InsereSerie()
        {
            Console.WriteLine("Inserir Nova série");

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i,Enum.GetName(typeof(Genero),i));
            }
            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da Série : ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de Inicio da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da Série : ");
            String entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),genero: (Genero)entradaGenero, titulo : entradaTitulo , ano : entradaAno , descricao : entradaDescricao);

            repositorio.Insere(novaSerie);
                    
            
        }

        public static void   AtualizarSerie()
        {
            Console.Write("Digite o id da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i , Enum.GetName(typeof(Genero),i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Titulo da Série: ");
            String entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de inicio da série :");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizarSerie = new Serie(id : indiceSerie , genero : (Genero)entradaGenero, titulo: entradaTitulo ,ano: entradaAno , descricao: entradaDescricao);
            
            repositorio.Atualizar(indiceSerie,atualizarSerie);
        }

        public static void ExcluirSerie()
        {
            Console.Write("Digite o id da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Excluir(indiceSerie);
        }

        public static void VisualizarSerie()
        {
            Console.Write("Digite o id Da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorid(indiceSerie);

            Console.WriteLine(serie);
        }

        private static string ObterOpcaoUsuario()
        {
        Console.WriteLine();
        Console.WriteLine("Dio Série a seu Dispor !!!");
        Console.WriteLine("Informe a Opção desejada: ");

        Console.WriteLine("1- Lista Séries");
        Console.WriteLine("2- Inserir Nova série");
        Console.WriteLine("3- Atualizar Série");
        Console.WriteLine("4- Excluir Série");
        Console.WriteLine("5- Visualizar série");
        Console.WriteLine("c- Limpar tela");
        Console.WriteLine("x- Sair");

        String opcaoUsuario  = Console.ReadLine().ToUpper();
        Console.WriteLine();
        return opcaoUsuario;
        }
    }
}

