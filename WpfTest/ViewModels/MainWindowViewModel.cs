using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using WpfTest.Model;
using WpfTest.Services;

namespace WpfTest.ViewModels
{
	public class MainWindowViewModel : BindableBase
	{
		private readonly IPrcSstService elementService;

		public MainWindowViewModel(IPrcSstService elementService)
		{
			this.elementService = elementService;
			this.PrcSst.CollectionChanged += ElementsOnCollectionChanged;
		}

		private void ElementsOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			CommandLoadXml.RaiseCanExecuteChanged();
			CommandClear.RaiseCanExecuteChanged();
		}

		public ObservableCollection<PrcSst> PrcSst { get; } = new ObservableCollection<PrcSst>();

		private DelegateCommand commandLoadXml;

		public DelegateCommand CommandLoadXml => 
			this.commandLoadXml ??= new DelegateCommand(async ()=> await CommandLoadXmlExecute(), CommandLoadXmlCanExecute);

		private DelegateCommand commandClear;

		public DelegateCommand CommandClear =>
			this.commandClear ??= new DelegateCommand(CommandClearExecute, CommandClearCanExecute);

		private async Task CommandLoadXmlExecute()
		{
			var element = await elementService.LoadPrcSstXml();
			PrcSst.Add(element);
		}

		private bool CommandLoadXmlCanExecute()
		{
			return PrcSst.Count < 10;
		}

		private void CommandClearExecute()
		{
			PrcSst.Clear();
		}

		private bool CommandClearCanExecute()
		{
			return PrcSst.Count > 0;
		}
	}
}
