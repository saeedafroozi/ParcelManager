namespace ParcelManager.Business
{
	public interface IRelatedHandler<TRequest>
	{
		IRelatedHandler<TRequest> SetNext(IRelatedHandler<TRequest> handler);

		void Run(TRequest request);
	}
}
