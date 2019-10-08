using ParcelManager.Domain;

namespace ParcelManager.Dto
{
	public class ParcelManagerServiceResult<TResult> : ServiceResult<TResult, ErrorType>
	{
		public ParcelManagerServiceResult(TResult result)
			: this(success: true, result: result, error: ErrorType.None, message: string.Empty)
		{ }

		public ParcelManagerServiceResult(ErrorType error, string message = "")
			: this(success: false, result: default(TResult), error: error, message: message)
		{ }

		public ParcelManagerServiceResult(bool success, TResult result, ErrorType error, string message)
			: base(result, success, error, message)
		{ }
	}
}
