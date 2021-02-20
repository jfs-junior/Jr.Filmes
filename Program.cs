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
                        AtualizarFilme();
                        break;
                    case "4":
                        ExcluirFilme();
                        break;
                    case "5":
                        VisualizarFilme();
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

        private static void ExcluirFilme() 
        {
            Console.Write("Digite o id da série: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            bool loop = false;

            do 
            {
                Console.Write("Tem certeza que deseja excluir o Filme? (S/N): ");
                string entradaConfirmacao = Console.ReadLine();

                if (entradaConfirmacao.ToLower() == "s" || entradaConfirmacao.ToLower() == "n") 
                {
                    loop = false;
                } else {
                    loop = true;
                }
            } while (loop);

            repositorio.Exclui(indiceFilme);
        }

        private static void VisualizarFilme() {
            Console.Write("Digite o id do Filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            var filme = repositorio.RetornaPorId(indiceFilme);

            Console.WriteLine(filme);
        }
        private static void AtualizarFilme()
        {
            Console.WriteLine("Digite o id da série:");
            int indiceFilme = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título do Filme: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de lançamento do Filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição do Filme: ");
            string entradaDescricao = Console.ReadLine();

            Filme atualizaFilme = new Filme (id: indiceFilme,
                                            genero: (Genero) entradaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao);

            repositorio.Atualizar(indiceFilme, atualizaFilme);
        }

         private static void ListarFilme()
        {
            Console.WriteLine("Listar Filmes");

            var lista = repositorio.Lista();
            int numeroExcluidos = 0;

            foreach (var filme in lista) 
            {
                if (filme.retornaExcluido()) {
                    numeroExcluidos++;
                }
            }

            if (lista.Count == 0) {
                Console.WriteLine("Nenhum filme cadastrado");
            } else if (lista.Count == numeroExcluidos) {
                Console.WriteLine("Nenhum filme encontrado");
            }

            foreach (var filme in lista) 
            {
                if(!filme.retornaExcluido()) 
                {
                    Console.WriteLine("ID: {0}: - {1}", filme.RetornaId(), filme.retornaTitulo());
                }
            }
            
            Console.WriteLine();
        }

        private static void InserirFilme() {
            Console.WriteLine("Inserir um novo Filme");

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
