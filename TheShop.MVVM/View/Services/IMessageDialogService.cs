namespace TheShop.MVVM.View.Services
{
	public interface IMessageDialogService
	{
		MessageDialogResult ShowOkCancelDialog(string text, string title);
	}
}