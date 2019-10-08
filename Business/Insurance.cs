using ParcelManager.Domain;

namespace ParcelManager.Business
{
	public class Insurance : RelatedHandler<Parcel>
	{
		public override void Run(Parcel request)
		{
			if (request.Value > 1000)
			{
				request.SetIsSignOff();
				base.Run(request);
			}
			else
			{
				base.Run(request);
			}
		}
	}
}