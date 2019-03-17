using System;
using System.IO;

namespace IOExamples
{
	internal class Program
	{
		private static void Main (string[] args)
		{
			CreateDirectory ();
		}

		private static void GetDirectory ()
		{
			var directory = new DirectoryInfo (@"C:\Windows\assembly");

			if (directory.Exists)
			{

				Console.WriteLine ("Name: {0}", directory.Name);
				Console.WriteLine ("Parent: {0}", directory.Parent);
				Console.WriteLine ("Full name: {0}", directory.FullName);
				Console.WriteLine ("Attributes: {0}", directory.Attributes);
				Console.WriteLine ("Creation Time: {0}", directory.CreationTime);
				Console.WriteLine ("Last write time: {0}", directory.LastWriteTime);
				Console.WriteLine ("Last access time: {0}", directory.LastAccessTime);

				FileInfo[] files = directory.GetFiles ();
				TextTool.PrintText ($"\nThe directory '{directory.FullName}' have: {files.Length} files", ConsoleColor.Yellow);

				foreach (FileInfo file in files)
				{
					Console.WriteLine ();
					Console.WriteLine ("Name: {0}", file.Name);
					Console.WriteLine ("Length: {0}", file.Length);
					Console.WriteLine ("Full name: {0}", file.FullName);
					Console.WriteLine ("Creation Time: {0}", file.CreationTime);
					Console.WriteLine ("Last write time: {0}", file.LastWriteTime);
					Console.WriteLine ("Last access time: {0}", file.LastAccessTime);
				}
			}
			else
			{
				Console.WriteLine ("Directory is not exist");
			}
		}

		private static void CreateDirectory ()
		{
			const string path = @"E:\ProgrammingCode\CSharp\AdvancedCSharp\TESTDIR";

			var directory = new DirectoryInfo (path);

			if (!directory.Exists)
			{
				Console.WriteLine ("Directory doesn't exists");
				directory.Create ();
			}

			if (directory.Exists)
			{
				try
				{
					CreateGameDirectory (ref directory, path);
				}
				catch (Exception ex)
				{

					Console.WriteLine (ex.Message);
				}
			}
		}

		static void CreateGameDirectory (ref DirectoryInfo directory, string path)
		{
			Console.WriteLine ("Directory exists");
			directory.CreateSubdirectory ("Assets");

			directory.CreateSubdirectory (@"Assets\Scripts");
			CreateFile (path + @"\Assets\Scripts", "Menu.cs");
			CreateFile (path + @"\Assets\Scripts", "CharacterInfo.cs");
			CreateFile (path + @"\Assets\Scripts", "BaseCharacter.cs");
			CreateFile (path + @"\Assets\Scripts", "CharacterController.cs");
			CreateFile (path + @"\Assets\Scripts", "EnemyController.cs");

			directory.CreateSubdirectory (@"Assets\Scenes");
			directory.CreateSubdirectory (@"Assets\Prefabs");
			directory.CreateSubdirectory (@"Assets\Animation");
			directory.CreateSubdirectory (@"Assets\Models");

			directory.CreateSubdirectory (@"Assets\Art");
			directory.CreateSubdirectory (@"Assets\Art\Texture");
			directory.CreateSubdirectory (@"Assets\Art\Image");
			directory.CreateSubdirectory (@"Assets\Art\SpriteSheets");
			directory.CreateSubdirectory (@"Assets\Art\Materials");

			directory.CreateSubdirectory ("Release");
			directory.CreateSubdirectory (@"Release\Data");
			directory.CreateSubdirectory (@"Release\Bin");

			directory.CreateSubdirectory ("Debug");
			directory.CreateSubdirectory (@"Debug\Data");
			directory.CreateSubdirectory (@"Debug\Bin");
		}

		private static void GetFileInfo (string path, string name)
		{
			string filePath = Path.Combine (path, name);
			GetFileInfo (filePath);
		}

		private static void GetFileInfo (string fullPath)
		{
			FileInfo file = new FileInfo (fullPath);
			FileStream fs = file.Open (FileMode.Open, FileAccess.Read, FileShare.None);

			Console.WriteLine ();
			Console.WriteLine ("Name: {0}", file.Name);
			Console.WriteLine ("Length: {0}", file.Length);
			Console.WriteLine ("Full name: {0}", file.FullName);
			Console.WriteLine ("Creation Time: {0}", file.CreationTime);
			Console.WriteLine ("Last write time: {0}", file.LastWriteTime);
			Console.WriteLine ("Last access time: {0}", file.LastAccessTime);

			fs.Close ();
		}

		private static void CreateFile (string path, string name)
		{
			string filePath = Path.Combine (path, name);

			if (!File.Exists (filePath))
			{
				try
				{
					FileStream fs = File.Create (filePath);
					fs.Close ();
				}
				catch (System.Exception ex)
				{
					Console.WriteLine (ex.Message);
				}
			}
			else
			{
				Console.WriteLine ("File \"{0}\" already exists.", filePath);
			}
		}

		private static void DeleteFile (string path, string name)
		{
			string filePath = Path.Combine (path, name);

			if (File.Exists (filePath))
			{
				try
				{
					File.Delete (filePath);
				}
				catch (System.Exception ex)
				{
					Console.WriteLine (ex.Message);
				}
			}
			else
			{
				Console.WriteLine ("File \"{0}\" is not exists.", filePath);
				throw new DirectoryNotFoundException ($"File \"{filePath}\" is not found");
			}
		}

		private static void DeleteDirectory (string path)
		{
			var directory = new DirectoryInfo (path);

			try
			{
				Console.WriteLine ("Delete 'Release' folder");
				directory.Delete (true);
			}
			catch (System.Exception ex)
			{
				Console.WriteLine (ex.Message);
			}
		}
	}
}
