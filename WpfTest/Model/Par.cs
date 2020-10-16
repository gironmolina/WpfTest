using System.Collections.Generic;
using System.Xml.Serialization;

namespace WpfTest.Model
{
	public class Par
	{
		[XmlElement(ElementName = "PI1")]
		public string Pi1 { get; set; }

		[XmlElement(ElementName = "STC")]
		public string Stc { get; set; }

		[XmlElement(ElementName = "SEQ")]
		public int Seq { get; set; }

		[XmlElement("MAR")]
		public List<Mar> Mars { get; set; } = new List<Mar>();
    }
}
