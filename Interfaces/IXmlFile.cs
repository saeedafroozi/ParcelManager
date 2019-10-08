using ParcelManager.Dto;

namespace ParcelManager.Interfaces
{
	public interface IXmlFile
	{
		ParcelManagerServiceResult<string> ReadFileAsText(string path);
		ParcelManagerServiceResult<string> GetFullPath(string name);
	}
}
