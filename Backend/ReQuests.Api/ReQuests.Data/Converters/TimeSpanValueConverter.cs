using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Linq.Expressions;

namespace ReQuests.Data.Converters;

public class TimeSpanValueConverter : ValueConverter<TimeSpan, string>
{
	public TimeSpanValueConverter()
		: base( v => System.Xml.XmlConvert.ToString( v ),
			v => System.Xml.XmlConvert.ToTimeSpan( v ) )
	{
	}
	public static TimeSpanValueConverter Instance { get; } = new TimeSpanValueConverter();
}
