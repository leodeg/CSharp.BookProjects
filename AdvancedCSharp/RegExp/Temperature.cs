using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegExp
{
	internal class Temperature : IFormattable
	{
		private decimal temperature;

		public Temperature (decimal temperature)
		{
			if (temperature < -273.15m)
			{
				throw new ArgumentOutOfRangeException (String.Format ("{0} is less than absolute zero.", temperature));
			}

			this.temperature = temperature;
		}

		public decimal Celsius
		{
			get { return temperature; }
		}

		public decimal Fahrenheit
		{
			get { return temperature * 9 / 5 + 32; }
		}

		public decimal Kelvin
		{
			get { return temperature + 273.15m; }
		}

		public string ToString ()
		{
			return this.ToString ("G", CultureInfo.CurrentCulture);
		}

		public string ToString (string format)
		{
			return this.ToString (format, CultureInfo.CurrentCulture);
		}

		public string ToString (string format, IFormatProvider formatProvider)
		{
			if (String.IsNullOrEmpty (format))
			{
				format = "G";
			}

			if (formatProvider == null)
			{
				formatProvider = CultureInfo.CurrentCulture;
			}

			switch (format.ToUpperInvariant ())
			{
				case "G":
				case "C":
					return temperature.ToString ("F2", formatProvider) + " C";

				case "F":
					return Fahrenheit.ToString ("F2", formatProvider) + " F";

				case "K":
					return Kelvin.ToString ("F2", formatProvider) + " F";

				default:
					throw new FormatException (String.Format ("The {0} format string is not supported", format));
			}
		}
	}
}
