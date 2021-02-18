using System;

namespace Jr.Filmes
{
    class Program
    {
        static FilmeRepositorio repositorio = new FilmeRepositorio();

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarFilme();
                        break;
                    case "2":
                        InserirFilme();
                        break;
                    case "3":
                        //AtualizarFilme();
                        break;
                    case "4":
                        //ExcluirFilme();
                        break;
                    case "5":
                        //VisualizarFilme();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine(); 
        }

         private static void ListarFilme()
        {
            Console.WriteLine("Listar Filmes");

            var lista = repositorio.Lista();

            if (lista.Count == 0) {
                Console.WriteLine("Nenhum filme cadastrado");
            }

            foreach (var filme in lista) 
            {
                Console.WriteLine("ID: {0}: - {1}", filme.RetornaId(), filme.retornaTitulo());
            }
            Console.WriteLine();
        }

        private static void InserirFilme() {
            Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine();
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Digite o Título do Filme: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Lançamento do Filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição do Filme: ");
            string entradaDescricao = Console.ReadLine();

            Filme novoFilme = new Filme(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao:entradaDescricao);
            repositorio.Insere(novoFilme);
        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("JR Filmes Versão v0.1");
            Console.WriteLine("Digite a opção desejada: ");
            Console.WriteLine();

            Console.WriteLine("1. Listar Filmes");
            Console.WriteLine("2. Inserir novo Filme");
            Console.WriteLine("3. Atualizar Filme");
            Console.WriteLine("4. Excluir Filme");
            Console.WriteLine("5. Visualizar Filme");
            Console.WriteLine("C. Limpar Tela");
            Console.WriteLine("X. Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
