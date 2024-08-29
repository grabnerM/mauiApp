using System.Collections.ObjectModel;

namespace mauiApp;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}	
	
	protected async void OnPickerTapped(object sender, EventArgs e)
	{
		try 
		{
			// Workaround for android(API 28+) because already focused picker focus don't trigger picker selection popup
			if (DeviceInfo.Current.Platform == DevicePlatform.Android && picker.IsFocused)
				picker.Unfocus();

			// Workaround for ios because click on right end of picker does not trigger
			picker.Focus();

			// Lock it longer for extra double tapping prevention
			await Task.Delay(400);
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}
}