
namespace ParcelManager.Business
{


	public abstract class RelatedHandler<TRequest> : IRelatedHandler<TRequest>
	{
		private IRelatedHandler<TRequest> _nextHandler;

		public IRelatedHandler<TRequest> SetNext(IRelatedHandler<TRequest> handler)
		{
			_nextHandler = handler;
			return _nextHandler;
		}

		public virtual void Run(TRequest request) => _nextHandler.Run(request);
	}
}
