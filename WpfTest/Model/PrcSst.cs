using System.Collections.Generic;
using System.Xml.Serialization;

namespace WpfTest.Model
{
	[XmlRoot(ElementName = "PRC_SST")]
	public class PrcSst
	{
		[XmlElement(ElementName = "NAM")]
		public string Nam { get; set; }

		[XmlElement(ElementName = "PAR")]
		public List<Par> Pars { get; set; }
	}
}
