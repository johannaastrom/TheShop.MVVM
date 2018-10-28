using Prism.Events;

namespace TheShop.MVVM.Event
{
	public class AfterProductSavedEvent : PubSubEvent<AfterProductSavedEventArgs>
	{
	}

	public class AfterProductSavedEventArgs
	{
		public int Id { get; set; }
		public string DisplayProduct { get; set; }
	}
}
