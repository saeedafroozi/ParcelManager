using System;
using System.Xml.Serialization;

namespace ParcelManager.Domain
{
	[XmlRoot("Parcel")]
	[Serializable]
	public class Parcel
	{
		[XmlElement(ElementName = "Sender")]
		public Sender Sender { get; set; }

		[XmlElement(ElementName = "Receipient")]
		public Receipient Receipient { get; set; }

		[XmlElement(ElementName = "Weight")]
		public decimal Weight { get; set; }

		[XmlElement(ElementName = "Value")]
		public decimal Value { get; set; }


		[XmlIgnoreAttribute]
		[XmlElement(IsNullable = true)]
		public bool? IsSignOff { get; private set; }//Prevent Set From The Out

		[XmlIgnoreAttribute]
		[XmlElement(IsNullable = true)]
		public bool? IsProcessed { get; private set; }

		[XmlIgnoreAttribute]
		[XmlElement(IsNullable = true)]
		public string DepartmentName { get; private set; }

		public void SetIsSignOff()
		{
			this.IsSignOff = true;
		}

		public void SetIsProcessed()
		{
			this.IsProcessed = true;
		}

		public void SetDepartmentName(string departmentName)
		{
			this.DepartmentName = departmentName;
		}

	}
}
