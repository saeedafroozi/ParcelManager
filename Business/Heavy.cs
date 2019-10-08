using ParcelManager.Domain;


namespace ParcelManager.Business
{
	public class Heavy : RelatedHandler<Parcel>
	{
		public override void Run(Parcel request)
		{
			if (request.Weight > 10)
			{
				request.SetDepartmentName(nameof(Heavy));
				request.SetIsProcessed();
			}
			else
			{
				base.Run(request);
			}
		}
	}
}
