using ParcelManager.Domain;
using ParcelManager.Dto;
using ParcelManager.Interfaces;
using System.Collections.Generic;

namespace ParcelManager
{
	public class ParcelConstructor : IParcelConstructor
	{
		private readonly ISerialization serialization;
		private readonly IXmlFile file;

		//injecting the serializer Interface and file Interface here to get rid of creating instance
		public ParcelConstructor(ISerialization serialization, IXmlFile file)
		{
			this.serialization = serialization;
			this.file = file;
		}
		public ParcelManagerServiceResult<IEnumerable<Parcel>> Create(string fileName)
		{

			try
			{
				//getting the physical path of xml file
				ParcelManagerServiceResult<string> fullPathResult = file.GetFullPath(fileName);

				if (!fullPathResult.Success)
					return new ParcelManagerServiceResult<IEnumerable<Parcel>>(error:fullPathResult.Error);


				//reading the content of xml as string 
				ParcelManagerServiceResult<string> fileContentReaderResult = file.ReadFileAsText(fullPathResult.Result);

				if (!fileContentReaderResult.Success)
					return new ParcelManagerServiceResult<IEnumerable<Parcel>>(error: fullPathResult.Error);


				// Deserialize Content to Container Object
				Container container = serialization.DeserializeXml<Container>(fileContentReaderResult.Result);
				return new ParcelManagerServiceResult<IEnumerable<Parcel>>(result: container.Parcels);

			}
			catch (System.Exception exception)
			{
				return new ParcelManagerServiceResult<IEnumerable<Parcel>>(error: ErrorType.ErrorIsUnkownPleaseContactAdmin, message: exception.Message);
			}
		}
	}
}
