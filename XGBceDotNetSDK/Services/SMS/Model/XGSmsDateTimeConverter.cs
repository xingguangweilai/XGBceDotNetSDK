using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace XGBceDotNetSDK.Services.SMS.Model
{
	/// <summary>
	/// 短信时间戳与DateTime日期转换类
	/// </summary>
	public class XGSmsDateTimeConverter:DateTimeConverterBase
    {
		internal static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

		/// <summary>
		/// Writes the JSON representation of the object.
		/// </summary>
		/// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter" /> to write to.</param>
		/// <param name="value">The value.</param>
		/// <param name="serializer">The calling serializer.</param>
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
			long ticks;
			if(value is DateTime)
            {
				var delta = ((DateTime) value)-UnixEpoch;
				if(delta.TotalMilliseconds<0)
					throw new ArgumentException("日期长度错误：" + value);
				ticks = (long)delta.TotalMilliseconds;
			}
            else
            {
				throw new ArgumentException("日期格式错误：" + value.GetType());
			}
			writer.WriteValue(ticks);
        }

		/// <summary>
		/// Reads the JSON representation of the object.
		/// </summary>
		/// <param name="reader">The <see cref="T:Newtonsoft.Json.JsonReader" /> to read from.</param>
		/// <param name="objectType">Type of the object.</param>
		/// <param name="existingValue">The existing property value of the JSON that is being converted.</param>
		/// <param name="serializer">The calling serializer.</param>
		/// <returns>The object value.</returns>
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.Integer)
            {
				throw new ArgumentException("日期格式错误："+reader.TokenType);
            }
			var ticks = (long)reader.Value;
			DateTime? date = UnixEpoch.AddMilliseconds(ticks);
			return date;
        }
	}
}
