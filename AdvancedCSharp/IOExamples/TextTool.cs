using System;

namespace IOExamples
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
