using System.Text.Json;
using System.Text.Json.Serialization;

namespace ReQuests.Domain.Converters;

internal class TimeSpanDaysCountJsonConverter : JsonConverter<TimeSpan>
{
	public override TimeSpan Read( ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options )
	{
		if ( typeToConvert != typeof( TimeSpan ) )
		{
			throw new ArgumentException( "can only parse System.TimeSpan", nameof( typeToConvert ) );
		}

		var value = reader.GetInt32();
		return TimeSpan.FromDays( value );
	}

	public override void Write( Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options )
	{
		var encoded = value.Days;
		writer.WriteNumberValue( encoded );
	}
}
