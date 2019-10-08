using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ParcelManager;
using ParcelManager.Business;
using ParcelManager.Domain;
using ParcelManager.Interfaces;
using System;
using System.Linq;

namespace Test
{
	[TestClass]
	public class ParcelDispatchingTest
	{

		[TestMethod]
		public void ValueLessThan1kg()
		{
			var appStart = new ParcelDispatching();

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
					 Name="test",
						Address=new Address{
							 City="city",
								HouseNumber=56546,
								 PostalCode="j321321",
									Street="street"
						},
						 CcNumber=23121
				},
				Value = 0.01m,
				Weight = 0.05m
				}
				},
				Id = 123,
				ShippingDate = DateTime.Now
			};

			var result = appStart.Start(container.Parcels);

			Assert.AreEqual(result.Result.SingleOrDefault().DepartmentName, nameof(Mail));
			Assert.AreEqual(result.Result.SingleOrDefault().Sender.Name, "test");
			Assert.AreEqual(result.Result.SingleOrDefault().Receipient.Name, "receipient");
			Assert.AreEqual(result.Error, ErrorType.None);
			Assert.IsTrue(string.IsNullOrEmpty(result.Message));
			Assert.IsTrue(result.Success);
			Assert.IsNotNull(result.Result);
		}

		[TestMethod]
		public void ValueLessThan10kg()
		{
			var appStart = new ParcelDispatching();

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
					 Name="test",
						Address=new Address{
							 City="city",
								HouseNumber=56546,
								 PostalCode="j321321",
									Street="street"
						},
						 CcNumber=23121
				},
				Value = 1.01m,
				Weight = 1.05m
				}
				},
				Id = 123,
				ShippingDate = DateTime.Now
			};



			var result = appStart.Start(container.Parcels);

			Assert.AreEqual(result.Result.SingleOrDefault().DepartmentName, nameof(Regular));
			Assert.AreEqual(result.Result.SingleOrDefault().Sender.Name, "test");
			Assert.AreEqual(result.Result.SingleOrDefault().Receipient.Name, "receipient");
			Assert.AreEqual(result.Error, ErrorType.None);
			Assert.IsTrue(string.IsNullOrEmpty(result.Message));
			Assert.IsTrue(result.Success);
			Assert.IsNotNull(result.Result);
		}

		[TestMethod]
		public void ValueMoreThan10kg()
		{

			var appStart = new ParcelDispatching();

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
					 Name="test",
						Address=new Address{
							 City="city",
								HouseNumber=56546,
								 PostalCode="j321321",
									Street="street"
						},
						 CcNumber=23121
				},
				Value = 10.01m,
				Weight = 10.05m
				}
				},
				Id = 123,
				ShippingDate = DateTime.Now
			};



			var result = appStart.Start(container.Parcels);

			Assert.AreEqual(result.Result.SingleOrDefault().DepartmentName, nameof(Heavy));
			Assert.AreEqual(result.Result.SingleOrDefault().Sender.Name, "test");
			Assert.AreEqual(result.Result.SingleOrDefault().Receipient.Name, "receipient");
			Assert.AreEqual(result.Error, ErrorType.None);
			Assert.IsTrue(string.IsNullOrEmpty(result.Message));
			Assert.IsTrue(result.Success);
			Assert.IsNotNull(result.Result);
		}

		[TestMethod]
		public void ValueLessThan1kgAndValueMoreThan1000()
		{

			var appStart = new ParcelDispatching();

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
					 Name="test",
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



			var result = appStart.Start(container.Parcels);

			Assert.AreEqual(result.Result.SingleOrDefault().DepartmentName, nameof(Heavy));
			Assert.IsTrue(result.Result.SingleOrDefault().IsSignOff.GetValueOrDefault());
			Assert.AreEqual(result.Result.SingleOrDefault().Sender.Name, "test");
			Assert.AreEqual(result.Result.SingleOrDefault().Receipient.Name, "receipient");
			Assert.AreEqual(result.Error, ErrorType.None);
			Assert.IsTrue(string.IsNullOrEmpty(result.Message));
			Assert.IsTrue(result.Success);
			Assert.IsNotNull(result.Result);
		}

		[TestMethod]
		public void OneParcelLessThan1kgAndOneParcelMoreThan10kg()
		{
			var serialize = new Mock<ISerialization>();
			var file = new Mock<IXmlFile>();
			var appStart = new ParcelDispatching();

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
							Name="receipient1"
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
							Name="receipient2"
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

			var result = appStart.Start(container.Parcels);

			Assert.AreEqual(result.Result.ToList()[0].DepartmentName, nameof(Mail));
			Assert.IsTrue(result.Result.ToList()[0].IsSignOff.GetValueOrDefault());
			Assert.AreEqual(result.Result.ToList()[0].Sender, "test1");
			Assert.AreEqual(result.Result.ToList()[0].Receipient.Name, "receipient1");

			Assert.AreEqual(result.Result.ToList()[1].DepartmentName, nameof(Heavy));
			Assert.IsTrue(result.Result.ToList()[1].IsSignOff.GetValueOrDefault());
			Assert.AreEqual(result.Result.ToList()[1].Sender, "test2");
			Assert.AreEqual(result.Result.ToList()[0].Receipient.Name, "receipient2");


			Assert.AreEqual(result.Error, ErrorType.None);
			Assert.IsTrue(string.IsNullOrEmpty(result.Message));
			Assert.IsTrue(result.Success);
			Assert.IsNotNull(result.Result);
		}
	}
}
