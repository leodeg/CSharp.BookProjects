using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegExp
{
	internal class Program
	{
		private static void Main (string[] args)
		{
			RegExPatternRange ();
		}

		private static void UnicodeDecoder ()
		{
			string text = "apple";

			Encoding leUnicode = Encoding.Unicode;
			Encoding beUnicode = Encoding.BigEndianUnicode;

			Encoding utf8Unicode = Encoding.UTF8;
			Encoding utf32Unicode = Encoding.UTF32;

			byte[] leUnicodeBytes = leUnicode.GetBytes (text);
			byte[] beUnicodeBytes = Encoding.Convert (leUnicode, beUnicode, leUnicodeBytes);
			byte[] utf8Bytes = Encoding.Convert (leUnicode, utf8Unicode, leUnicodeBytes);


			var builder = new StringBuilder ();
			Console.WriteLine ("Source {0}", text);

			Console.WriteLine ("Byte Unicode lower first");
			foreach (byte b in leUnicodeBytes)
			{
				builder.Append (b).Append (":");
			}
			Console.WriteLine (builder);

			builder = new StringBuilder ();
			Console.WriteLine ("Byte Unicode upper first");
			foreach (byte b in beUnicodeBytes)
			{
				builder.Append (b).Append (":");
			}
			Console.WriteLine (builder);

			builder = new StringBuilder ();
			Console.WriteLine ("Utf8 Unicode");
			foreach (byte b in utf8Bytes)
			{
				builder.Append (b).Append (":");
			}
			Console.WriteLine (builder);
		}

		private static void CreateString ()
		{
			// Create hello
			string str = "Hello";
			Console.WriteLine (str);
			Console.WriteLine (str.GetHashCode ());

			// Insert new string
			Console.WriteLine ();
			str = str.Insert (2, "Upta");
			Console.WriteLine (str);
			Console.WriteLine (str.GetHashCode ());

			// Create a new string using new keyword
			String str2 = new string ('-', 20);
			Console.WriteLine ();
			Console.WriteLine (str2);
			Console.WriteLine (str2.GetHashCode ());

			// Add integer to the string
			str += str2;
			Console.WriteLine ();
			Console.WriteLine (str);
			Console.WriteLine (str.GetHashCode ());
		}

		private static void StringReferenceEquals ()
		{
			// Таблица интернирования строк

			bool isEqual;
			string string1 = "string1";
			string string2 = "string1";

			Console.WriteLine ("string 1: {0}", string1);
			Console.WriteLine ("string 2: {0}", string2);

			isEqual = ReferenceEquals (string1, string2);
			Console.WriteLine ("Is string1 and string2 equal?: {0}", isEqual);


			Console.WriteLine ("Write some text:");
			string text;

			// isEqual: true
			text = String.Intern (Console.ReadLine ());

			// isEqual: false
			//text = Console.ReadLine (); 

			isEqual = ReferenceEquals (string1, text);
			Console.WriteLine ("Is string1 and a new text equal?: {0}", isEqual);
		}

		private static void RegExpBasic ()
		{
			const string pattern = @"\d";

			var regex = new Regex (pattern);

			while (true)
			{
				string str = Console.ReadKey ().KeyChar.ToString ();

				if (str == " ") break;

				bool success = regex.IsMatch (str);
				Console.WriteLine (success ? " -> true \"{0}\"" : " -> false \"{0}\"", pattern);
			}
		}

		private static void RegExPatterns ()
		{
			string pattern;

			//pattern = @"\d+";
			//pattern = @"^/d+";
			//pattern = @"\d+$";
			//pattern = @"^\d+$";
			pattern = @"^\d*\D+\d+$";

			var regex = new Regex (pattern);

			var arr = new[] { "test", "123", "test123", "123test", "te123st", "4566yyy123" };

			foreach (String element in arr)
			{
				bool success = regex.IsMatch (element);
				Console.WriteLine (success ? $"{element} -> true \"{pattern}\"" : $"{element} -> false \"{pattern}\"");
			}
		}

		private static void RegExPatternsMore ()
		{
			Console.WriteLine (Regex.Replace ("test12312351234sadsa12213",
				@"\d+",
				" "));

			Console.WriteLine (Regex.Replace ("test123aa4x56bb643cc",
				@"\d",
				" "));

			Console.WriteLine (Regex.Replace ("02/05/1982",
				@"(?<month>\d{1,2})\/(?<day>\d{1,2})\/(?<year>\d{2,4})",
				"${day}-${month}-${year}"));

			Console.WriteLine (Regex.Replace ("5 is less then 10",
				@"\d+",
				m => ( int.Parse (m.Value) + 1 ).ToString ()));
		}

		private static void RegExPatternRange ()
		{
			Regex regex;
			string pattern;
			string text;

			pattern = "^[qwerty]+$";
			text = "qwec";
			regex = new Regex (pattern);
			Console.WriteLine ($"{text} == {pattern} : {regex.IsMatch (text)}");

			pattern = "^[qwerty]+$";
			text = "qrwere";
			regex = new Regex (pattern);
			Console.WriteLine ($"{text} == {pattern} : {regex.IsMatch (text)}");


		}
	}
}
