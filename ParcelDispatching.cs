using ParcelManager.Business;
using ParcelManager.Domain;
using ParcelManager.Dto;
using System.Collections.Generic;

namespace ParcelManager
{
	public class ParcelDispatching
	{



		public ParcelManagerServiceResult<IEnumerable<Parcel>> Start(IEnumerable<Parcel> parcels)
		{
			var result = new List<Parcel>();

			//**** setting up the chain of responsibility pattern to solve to automate the internal handling of parcels coming in
			/* For Adding A New Department To Handle Some New Business Rules  First You Must Define It in Business Folder And Then You Must Put It in Below Chain 
			 * And If You Want This New Department Execute First You Must Put It In The First Of The Chain Like Insurance
			*/
			RelatedHandler<Parcel> insuranceDepartment = new Insurance();//insurance must be in the first of the chain because of its business
			RelatedHandler<Parcel> heavyDepartment = new Heavy();
			RelatedHandler<Parcel> mailDepartment = new Mail();
			RelatedHandler<Parcel> regularDepartment = new Regular();

			insuranceDepartment
					.SetNext(heavyDepartment)
					.SetNext(mailDepartment)
					.SetNext(regularDepartment);



			//iterate over each parcel to process and then return the processed list
			foreach (Parcel parcel in parcels)
			{
				insuranceDepartment.Run(parcel);
			}

			return new ParcelManagerServiceResult<IEnumerable<Parcel>>(result: parcels);
		}
	}
}