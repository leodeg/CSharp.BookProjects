using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateEventGame
{
	static class TextTool
	{
		public static void PrintText (string text, ConsoleColor color)
		{
			Console.ForegroundColor = color;
			Console.WriteLine (text);
			Console.ForegroundColor = ConsoleColor.White;
		}
	}
}
