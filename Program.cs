using System;
using System.IO;
namespace MyApp // Note: actual namespace depends on the project name.
{
  internal class Program
  {
    static void Main(string[] args)
    {
      Menu();
    }
    static void Menu()
    {
      Console.WriteLine("0 - Sair;");
      Console.WriteLine("1 - Digite o conteudo;");
      Console.WriteLine("2 - Visualisar o conteudo;");
      short option = short.Parse(Console.ReadLine()!);
      switch (option)
      {
        case 0: System.Environment.Exit(0); break;
        case 1: Digite(); break;
        case 2: Visualisar(); break;
        default: Menu(); break;
      }
    }
    static void Visualisar()
    {
      Console.Clear();
      Console.WriteLine("Qual o caminho do arquivo?");
      string path = Console.ReadLine();

      using (var file = new StreamReader(path))
      {
        string text = file.ReadToEnd();
        Console.WriteLine(text);
      }
      Console.WriteLine("");
      Console.ReadLine();
      Menu();
    }
    static void Digite()
    {
      Console.Clear();
      Console.WriteLine("Digite abaixo o texto - (Esc pra sair)");
      Console.WriteLine("-------------------------------------");
      string text = "";
      do
      {
        text += Console.ReadLine();
        text += Environment.NewLine;
      }
      while (Console.ReadKey().Key != ConsoleKey.Escape);
      Caminho(text);
    }
    static void Caminho(string text)
    {
      Console.Clear();
      Console.WriteLine("Qual o caminho que deseja ser salvo? (Ex.C:|Users|Administrator|Desktop|Nome_arquivo.txt)");
      Console.WriteLine("-------------------------------------");
      var path = Console.ReadLine();
      using (var file = new StreamWriter(path))
      {
        file.Write(text);
      }
      Console.WriteLine($"Arquivo {path} salvo com sucesso");
      Console.ReadLine();
      Menu();
    }
  }
}
