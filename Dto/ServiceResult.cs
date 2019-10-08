namespace ParcelManager.Dto
{
	public abstract class ServiceResult<TResult, TError>
	{
		public TResult Result { get; private set; }
		public bool Success { get; private set; }
		public TError Error { get; private set; }
		public string Message { get; private set; }

		public ServiceResult(TResult result, bool success, TError error, string message)
		{
			this.Error = error;
			this.Result = result;
			this.Success = success;
			this.Message = message;
		}
	}
}
