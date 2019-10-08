using ParcelManager.Domain;
using ParcelManager.Dto;
using System.Collections.Generic;

namespace ParcelManager.Interfaces
{
	public interface IParcelConstructor
	{
		 ParcelManagerServiceResult<IEnumerable<Parcel>> Create(string fileName);
	}
}
