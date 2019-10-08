using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParcelManager;
using ParcelManager.Domain;

namespace Test
{
	[TestClass]
	public class ReadFile
	{
		[TestMethod]
		public void FilePathIsNull()
		{
			var file = new XmlFile();
			var result = file.ReadFileAsText(null);
			Assert.AreEqual(result.Error, ErrorType.PathIsNull);

		}
		[TestMethod]
		public void FilePathIsEmpty()
		{
			var file = new XmlFile();
			var result = file.ReadFileAsText(string.Empty);
			Assert.AreEqual(result.Error, ErrorType.PathIsEmpty);

		}
		[TestMethod]
		public void FilePathIsTooLong()
		{
			var file = new XmlFile();
			var result = file.ReadFileAsText("asdjf laksdjf l;aksdjf l;;;;;;aflak;sd jflak;sdjf lk;asdjf l;kasdjf l;kasjdf l;kasjdf lk;a fl;aksdjf lkajsdfl ajsdlkf jalskdfj la;ksdj flkasjdfl;ajas;dfas;kdflkasjdflkajsdlfkjasldkf jalsk;dfj laks;dj fl;aksjd fl;kajsd fl;kjasdl;fkjalsk; dfjlaks djflk;asj dflk;ja sdl;fkjal;skdfjl ka;sdjf al;skdjfla;ksdjflkasjdf lkasj dlfkjasdl;k fjalsk dfjlkas djflkaj sdfl;kjasdlkfjalskdfj alskdjf lkasdj flkas djflkaj sdlfkj asldk fjla; ksdjflkas djflasdj flkasdj flk;ajsd flk;ajsd flkajsd l;fkjas dl;kfjal;skdfj al;ksd jflk;a sdjflk ajsdlkfj alsk;djflkaj sdlfkjasldkf jalksdj flkasjdflajsdflkjasdlfasdlf jal;skdjf laksdj flk;ajs dfl;");
			Assert.AreEqual(result.Error, ErrorType.PathLengthIsTooLong);

		}
		[TestMethod]
		public void FileIsNotExist()
		{
			var file = new XmlFile();
			var result = file.ReadFileAsText("E:/C");
			Assert.AreEqual(result.Error, ErrorType.FileDoseNotExist);

		}


		[TestMethod]
		public void FileLoadSuccessfully()
		{
			var file = new XmlFile();
			var pathResult = file.GetFullPath(@"AppData\Container_68465468.xml");
			var result = file.ReadFileAsText(pathResult.Result);
			Assert.AreEqual(result.Error, ErrorType.None);
			Assert.IsTrue(string.IsNullOrEmpty(result.Message));
			Assert.IsTrue(result.Success);
			Assert.IsNotNull(result.Result);
		}
	}
}
