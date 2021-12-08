using System.Text.Json;
using System.Text.Json.Serialization;

namespace ReQuests.Domain.Converters;

internal class TimeSpanJsonConverter : JsonConverter<TimeSpan>
{
	public override TimeSpan Read( ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options )
	{
		if ( typeToConvert != typeof( TimeSpan ) )
		{
			throw new ArgumentException( "can only parse System.TimeSpan", nameof( typeToConvert ) );
		}

		var value = reader.GetString() ?? throw new NullReferenceException();
		return System.Xml.XmlConvert.ToTimeSpan( value );
	}

	public override void Write( Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options )
	{
		var encoded = System.Xml.XmlConvert.ToString( value );
		writer.WriteStringValue( encoded );
	}
}
