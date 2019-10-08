using System.IO;

namespace ParcelManager
{
	public class Serialization : ISerialization
	{
		/// <summary>
		/// a generic Deserializer for xml
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="xmlContent">
		/// it must be the physical path of file
		/// </param>
		/// <returns></returns>
		public T DeserializeXml<T>(string xmlContent) where T : class
		{
			System.Xml.Serialization.XmlSerializer serialize = new System.Xml.Serialization.XmlSerializer(typeof(T));

			using (StringReader sr = new StringReader(xmlContent))
			{
				return (T)serialize.Deserialize(sr);
			}
		}
	}
}
