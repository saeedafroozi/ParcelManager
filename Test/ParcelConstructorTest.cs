using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ParcelManager;
using ParcelManager.Domain;
using ParcelManager.Interfaces;
using System;
using System.Linq;

namespace Test
{
	[TestClass]
	public class ParcelConstructorTest
	{
		[TestMethod]
		public void CreatePurcelListSuccessfully()
		{
			var serialize = new Mock<ISerialization>();
			var file = new Mock<IXmlFile>();
			var createParcels = new ParcelConstructor(serialize.Object, file.Object);

			var container = new Container
			{
				Parcels = new System.Collections.Generic.List<Parcel> {
					new Parcel {
						Receipient = new Receipient{
						 Address=new Address{
							 City="city",
								HouseNumber=56546,
								 PostalCode="j321321",
									Street="street"
						},
							Name="receipient"
					},
					Sender = new Sender{
					 Name="test1",
						Address=new Address{
							 City="city",
								HouseNumber=56546,
								 PostalCode="j321321",
									Street="street"
						},
						 CcNumber=23121
				},
				Value = 1000.01m,
				Weight = 0.05m
				},
					new Parcel {
					Receipient = new Receipient{
						 Address=new Address{
							 City="city",
								HouseNumber=56546,
								 PostalCode="j321321",
									Street="street"
						},
							Name="receipient"
					},
					Sender = new Sender{
					 Name="test2",
						Address=new Address{
							 City="city",
								HouseNumber=56546,
								 PostalCode="j321321",
									Street="street"
						},
						 CcNumber=23121
				},
				Value = 1000.01m,
				Weight = 10.05m
				}
				},
				Id = 123,
				ShippingDate = DateTime.Now
			};

			file.Setup(x => x.GetFullPath(It.IsAny<string>())).Returns(new ParcelManager.Dto.ParcelManagerServiceResult<string>(result: "*"));
			file.Setup(x => x.ReadFileAsText(It.IsAny<string>())).Returns(new ParcelManager.Dto.ParcelManagerServiceResult<string>(result: "Content"));
			serialize.Setup(x => x.DeserializeXml<Container>(It.IsAny<string>())).Returns(container);

			var result = createParcels.Create("test");



			Assert.AreEqual(result.Error, ErrorType.None);
			Assert.IsTrue(string.IsNullOrEmpty(result.Message));
			Assert.IsTrue(result.Success);
			Assert.IsNotNull(result.Result);

			result.Result.ToList().ForEach((item) =>
			{
				Assert.IsTrue(container.Parcels.Where(x => x.Value == item.Value).Any());
				Assert.IsTrue(container.Parcels.Where(x => x.Weight == item.Weight).Any());
			});
		}
	}
}
