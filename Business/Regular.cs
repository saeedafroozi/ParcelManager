using ParcelManager.Domain;

namespace ParcelManager.Business
{
	public class Regular : RelatedHandler<Parcel>
	{
		public override void Run(Parcel request)
		{
			if (request.Weight <= 10)
			{
				request.SetDepartmentName(nameof(Regular));
				request.SetIsProcessed();
			}
			else
			{
				base.Run(request);
			}
		}
	}
}
