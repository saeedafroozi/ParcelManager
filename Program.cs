using ParcelManager.Domain;
using System;

namespace ParcelManager
{
	public class Program
	{
		static void Main(string[] args)
		{

			//create parcels and inject its dependencies and pass fileName
			var parcelsResult = new ParcelConstructor(new Serialization(), new XmlFile()).Create(@"AppData\Container_68465468.xml");

			if (!parcelsResult.Success)
			{
				if (parcelsResult.Error == ErrorType.ErrorIsUnkownPleaseContactAdmin)
				{
					Console.WriteLine($"Unknown Error:  {parcelsResult.Message}");
				}
				else
				{
					Console.WriteLine($"Please Check This Issue: {parcelsResult.Error}");
				}
			}

			else
			{

				//starting the program for setting up the chain of responsibility pattern
				var appStartResult = new ParcelDispatching().Start(parcelsResult.Result);

				if (appStartResult.Success)
				{
					foreach (var result in appStartResult.Result)
					{
						//if if  parcel is signed off by insurance we checked here then  log it here
						if (result.IsSignOff.GetValueOrDefault())
						{
							Console.WriteLine($"Parcel from {result.Sender.Name} and Received by {result.Receipient.Name} Is Signed Off ");
						}

						if (result.IsProcessed.GetValueOrDefault())
						{
							//console write to state which department handle each parcel
							Console.WriteLine($"Parcel from {result.Sender.Name} and Received by {result.Receipient.Name} Is Handled By Department Of {result.DepartmentName}");
						}
					}
				}
			}

			Console.ReadLine();
		}
	}
}
