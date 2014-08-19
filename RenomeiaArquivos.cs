using System;
using System.IO;

public class RenomeiaArquivos
{
	public static void Main(string[] args)
	{
		// coleta os parâmetros, se houver
		if (args.Length <= 0) {
			// encerra
			Console.WriteLine("Sem parâmetros?!?!?");
			return;
		}
		// 0 é a pasta
		string folder = args[0];
		// valida
		if (!Directory.Exists(folder)) {
			Console.WriteLine("Diretório inexistente");
			return;
		}
		// 1 é a string de procura
		string find = args[1];
		// valida
		if (string.IsNullOrEmpty(find)) {
			Console.WriteLine("A string de procura não pode ser vazia");
			return;
		}
		// 2 é a string de substituição
		string replace = args[2];
		
		// 3, opcional, é se deseja fazer um toLower
		bool toLower;
		try {
			toLower = Convert.ToBoolean(args[3]);
		}
		catch {
			toLower = false;
		}
	
		foreach(string file in Directory.GetFiles(folder)) {
			Console.WriteLine(string.Format("Renomeando arquivo {0}",  Path.GetFileName(file)));
			try {
				string finalFileName = toLower ? Path.GetFileName(file).Replace(find, replace).ToLower() : Path.GetFileName(file).Replace(find, replace);
				string finalPath = Path.Combine(folder, finalFileName);
				File.Move(file, finalPath);
				Console.WriteLine("OK");
			}
			catch (Exception ex) {
				Console.WriteLine(string.Format("{} - {}", "Ops! Não foi possível renomear este arquivo!", ex.ToString()));
			}
		}
	}
}