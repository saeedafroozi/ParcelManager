using ParcelManager.Domain;

namespace ParcelManager.Business
{
	public class Mail : RelatedHandler<Parcel>
	{
		public override void Run(Parcel request)
		{
			if (request.Weight <= 1)
			{
				request.SetDepartmentName(nameof(Mail));
				request.SetIsProcessed();
			}
			else
			{
				base.Run(request);
			}
		}
	}
}