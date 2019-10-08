using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParcelManager;
using ParcelManager.Domain;

namespace Test
{
	[TestClass]
	public class FilePath
	{
		[TestMethod]
		public void FileNameIsNull()
		{
			var file = new XmlFile();
			var result = file.GetFullPath(null);
			Assert.AreEqual(result.Error, ErrorType.FileNameIsNull);

		}
		[TestMethod]
		public void FileNameIsEmpty()
		{
			var file = new XmlFile();
			var result = file.GetFullPath("");
			Assert.AreEqual(result.Error, ErrorType.FileNameIsEmpty);

		}

		[TestMethod]
		public void GetFilePathSuccessfully()
		{
			var file = new XmlFile();
			var result = file.GetFullPath("test");
			Assert.AreEqual(result.Error, ErrorType.None);
			Assert.IsTrue(string.IsNullOrEmpty(result.Message));
			Assert.IsTrue(result.Success);
			Assert.IsNotNull(result.Result);
		}
	}
}
