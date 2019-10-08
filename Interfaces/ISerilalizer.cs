namespace ParcelManager
{
	public interface ISerialization
	{
		T DeserializeXml<T>(string xmlContent) where T : class;
	}
}
