using System;
using System.IO;
namespace TextEditor
{
    class Program
    {
        static void Main()
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Opções: ");
            Console.WriteLine("1 - Abrir Arquivo ");
            Console.WriteLine("2 - Criar novo arquivo");
            Console.WriteLine("0 - Sair");
            Console.Write("> ");
            short option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 0: Console.Clear(); Environment.Exit(0); break;
                case 1: Console.Clear(); Open(); break;
                case 2: Console.Clear(); Edit(); break;
                default: Console.Clear(); Menu(); break;
            }
        }
        static void Open()
        {
            Console.Clear();
            Console.WriteLine("Caminho do arquivo: ");
            Console.Write("> ");
            string path = Console.ReadLine();

            using (var file = new StreamReader(path))
            {
                string text = file.ReadToEnd();
                Console.WriteLine(text);
            }

            Console.WriteLine("");
            Console.WriteLine("Presione qualquer tecla para sair");
            Console.ReadLine();
            Menu();
        }
        static void Edit()
        {
            Console.WriteLine("Digite seu texto: (ESC para sair)");
            Console.WriteLine("-----------------");

            string text = "";

            do
            {
                text += Console.ReadLine();
                text += Environment.NewLine;
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);
            Salvar(text);
        }
        static void Salvar(string text)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("Qual caminho salvar?");
            Console.Write("> ");
            var path = Console.ReadLine();

            using (var file = new StreamWriter(path)) file.Write(text);

            System.Console.WriteLine($"O arquivo {path} foi salvo com sucesso");
            Console.ReadLine();

            Menu();
        }
    }
}