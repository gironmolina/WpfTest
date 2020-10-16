using System.Threading.Tasks;
using WpfTest.Model;

namespace WpfTest.Services
{
	public interface IPrcSstService
	{
		Task<PrcSst> LoadPrcSstXml();
	}
}
