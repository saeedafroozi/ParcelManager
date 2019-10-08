namespace ParcelManager.Domain
{
	public enum ErrorType
	{
		None = 0,
		PathIsNull = 1,
		PathIsEmpty = 2,
		PathLengthIsTooLong = 3,
		FileDoseNotExist = 4,
		ErrorIsUnkownPleaseContactAdmin = 5,
		FileNameIsNull = 6,
		FileNameIsEmpty = 7,
	}
}
