using ParcelManager.Domain;
using ParcelManager.Dto;
using ParcelManager.Interfaces;
using System;
using System.IO;
using System.Reflection;

namespace ParcelManager
{
	public class XmlFile : IXmlFile
	{
		public ParcelManagerServiceResult<string> ReadFileAsText(string filePath)
		{
			if (filePath == null)
				return new ParcelManagerServiceResult<string>(error: ErrorType.PathIsNull);
			else if (String.IsNullOrEmpty(filePath))
				return new ParcelManagerServiceResult<string>(error: ErrorType.PathIsEmpty);
			else if (filePath.Length > 248)
				return new ParcelManagerServiceResult<string>(error: ErrorType.PathLengthIsTooLong);
			else if (!File.Exists(filePath))
				return new ParcelManagerServiceResult<string>(error: ErrorType.FileDoseNotExist);
			else
				return new ParcelManagerServiceResult<string>(result: File.ReadAllText(filePath));
		}
		public ParcelManagerServiceResult<string> GetFullPath(string fileName)
		{
			if (fileName == null)
				return new ParcelManagerServiceResult<string>(error: ErrorType.FileNameIsNull);
			else if (String.IsNullOrEmpty(fileName))
				return new ParcelManagerServiceResult<string>(error: ErrorType.FileNameIsEmpty);
			else
				return new ParcelManagerServiceResult<string>(result: Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), fileName));
		}
	}
}
