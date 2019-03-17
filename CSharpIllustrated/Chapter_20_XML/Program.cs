using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Chapter_20_XML
{
	class Program
	{
		static void Main (string[] args)
		{
			UseXmlAndLinq ();
		}

		static void CreatingSavingLoadingXML ()
		{
			XDocument employee = new XDocument
				(new XElement ("Employees",
					new XElement ("Name", "Bob Smith"),
					new XElement ("Name", "Sally Jones")
					)
				);

			employee.Save ("EmployeesFile.xml");
			XDocument employees_2 = XDocument.Load ("EmployeesFile.xml");
			Console.WriteLine (employees_2);

		}

		static void CreatingAnXmlTree ()
		{
			XDocument employeeDocument = new XDocument
				(
					new XElement ("Employees",
						new XElement ("Employee",
							new XElement ("Name", "Bob Smith"),
							new XElement ("PhoneNumber", "408-55-1000")
						),
						new XElement ("Employee",
							new XElement ("Name", "Sally Jones"),
							new XElement ("PhoneNumber", "415-55-2000"),
							new XElement ("PhoneNumber", "415-55-2001")
						)
					)
				);

			XElement root = employeeDocument.Element ("Employees");
			IEnumerable<XElement> employees = root.Elements ();

			foreach (XElement element in employees)
			{
				XElement empNameNode = element.Element ("Name");
				Console.WriteLine (empNameNode.Value);

				IEnumerable<XElement> empPhones = element.Elements ("PhoneNumber");
				foreach (XElement phone in empPhones)
				{
					Console.WriteLine ($"\t{phone.Value}");
				}
			}
		}

		static void AddNodes ()
		{
			XDocument xd = new XDocument (new XElement ("root", new XElement ("first")));

			Console.WriteLine ("Original tree");
			Console.WriteLine (xd); Console.WriteLine ();

			XElement rt = xd.Element ("root");

			rt.Add (new XElement ("second"));
			rt.Add (new XElement ("third"),
				new XComment ("Important Comment"),
				new XElement ("fourth"));

			Console.WriteLine ("Modified tree");
			Console.WriteLine (xd);

		}

		static void XmlAttributes ()
		{
			XDocument xd = new XDocument (
					new XElement ("root",
						new XAttribute ("color", "red"),
						new XAttribute ("size", "large"),
						new XElement ("first"),
						new XElement ("second")));

			Console.WriteLine (xd);
		}

		static void AdditionalInstuctions ()
		{
			XDocument xd = new XDocument (
				new XDeclaration ("1.0", "utf-8", "yes"),
				new XComment ("Comment"),
				new XProcessingInstruction ("xml-stylesheet", @"href=""stories.css"" type=""text/css"""),
				new XElement ("root",
					new XElement ("first"),
					new XElement ("second")
				)
			);

			Console.WriteLine (xd);
		}

		static void CreateAnXmlTree ()
		{
			XDocument xd = new XDocument (
				new XElement ("Elements",
					new XElement ("first",
						new XAttribute ("color", "red"),
						new XAttribute ("size", "small")),
					new XElement ("second",
						new XAttribute ("color", "green"),
						new XAttribute ("size", "blue")),
					new XElement ("third",
						new XAttribute ("color", "blue"),
						new XAttribute ("size", "large"))));

			Console.WriteLine (xd);
			xd.Save ("SimpleElementsCollection.xml");
		}

		static void UseXmlAndLinq ()
		{
			XDocument xd = XDocument.Load ("SimpleElementsCollection.xml");
			XElement root = xd.Element ("Elements");

			var name_fiveChar = from e in root.Elements ()
								where e.Name.ToString ().Length == 5
								select e;

			var name_fiveChar_anon = from e in root.Elements ()
									 select new { e.Name, color = e.Attribute ("color") };

			foreach (XElement element in name_fiveChar)
			{
				Console.WriteLine (element.Name.ToString());
			}

			foreach (XElement element in name_fiveChar)
			{
				Console.WriteLine ("Name: {0}, color: {1}, size: {2}", element.Name, element.Attribute("color"), element.Attribute("size"));
			}

			foreach (var element in name_fiveChar_anon)
			{
				Console.WriteLine ("{0}, color: {1}", element.Name, element.color.Value);
			}
		}
	}
}
