using tv_series_registration_app;
class Program
{
    static SerieRepository repository = new SerieRepository();
    static void Main(string[] args)
    {
        string userOption = GetUserOption();

        while (userOption.ToUpper() != "X")
        {
            switch (userOption)
            {
                case "1":
                    ListSeries();
                    break;
                case "2":
                    InsertSerie();
                    break;
                case "3":
                    UpdateSerie();
                    break;
                case "4":
                    DeleteSerie();
                    break;
                case "5":
                    ViewSerie();
                    break;
                case "C":
                    Console.Clear();
                    break;

                default:
                    throw new ArgumentOutOfRangeException("Opção inválida.");
            }

            userOption = GetUserOption();
        }

        Console.WriteLine("Obrigado por usar nossos serviços.");
        Console.ReadLine();
    }

    private static void DeleteSerie()
    {
        Console.Write("Digite o id da série: ");
        int serieIndex = int.Parse(Console.ReadLine());

        repository.DeleteSerie(serieIndex);
    }

    private static void ViewSerie()
    {
        Console.Write("Digite o id da série: ");
        int serieIndex = int.Parse(Console.ReadLine());

        var serie = repository.ReturnById(serieIndex);

        Console.WriteLine(serie);
    }

    private static void UpdateSerie()
    {
        Console.Write("Digite o id da série: ");
        int serieIndex = int.Parse(Console.ReadLine());

        foreach (int i in Enum.GetValues(typeof(Genre)))
        {
            Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
        }
        Console.Write("Digite o gênero entre as opções acima: ");
        int entryGenre = int.Parse(Console.ReadLine());

        Console.Write("Digite o Título da Série: ");
        string entryTittle = Console.ReadLine();

        Console.Write("Digite o Ano de Início da Série: ");
        int entryYear = int.Parse(Console.ReadLine());

        Console.Write("Digite a Descrição da Série: ");
        string entryDescription = Console.ReadLine();

        Serie updateSerie = new Serie(id: serieIndex,
                                    genre: (Genre)entryGenre,
                                    tittle: entryTittle,
                                    year: entryYear,
                                    description: entryDescription);

        repository.UpdateSerie(serieIndex, updateSerie);
    }
    private static void ListSeries()
    {
        Console.WriteLine("Listar Séries");

        var list = repository.ListSeries();
        if (list.Count == 0)
        {
            Console.WriteLine("Nenhuma série cadastrada.");
            return;
        }

        foreach (var serie in list)
        {
            var deleted = serie.returnDeleted();
            Console.WriteLine("#ID {0}: - {1} {2}", serie.returnId(), serie.returnTittle(), (deleted ? "*Excluída*" : ""));
        }
    }

    private static void InsertSerie()
    {
        Console.WriteLine("Inserir nova série");

        foreach (int i in Enum.GetValues(typeof(Genre)))
        {
            Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
        }
        Console.Write("Digite o gênero entre as opções acima: ");
        int entryGenre = int.Parse(Console.ReadLine());

        Console.Write("Digite o Título da Série: ");
        string entryTittle = Console.ReadLine();

        Console.Write("Digite o Ano de Início da Série: ");
        int entryYear = int.Parse(Console.ReadLine());

        Console.Write("Digite a Descrição da Série: ");
        string entryDescription = Console.ReadLine();

        Serie newSerie = new Serie(id: repository.NextId(),
                                    genre: (Genre)entryGenre,
                                    tittle: entryTittle,
                                    year: entryYear,
                                    description: entryDescription);

        repository.InsertSerie(newSerie);
    }

    private static string GetUserOption()
    {
        Console.WriteLine();
        Console.WriteLine("Mirous TV Shows");
        Console.WriteLine("Informe a opção desejada:");
        Console.WriteLine("1- Listar Séries");
        Console.WriteLine("2- Inserir Nova Série");
        Console.WriteLine("3- Atualizar Série");
        Console.WriteLine("4- Excluir Série");
        Console.WriteLine("5- Visualizar Série");
        Console.WriteLine("C- Limpar Tela");
        Console.WriteLine("X- Sair");
        Console.WriteLine();

        string userOption = Console.ReadLine().ToUpper();
        Console.WriteLine(); return userOption;
    }
}

