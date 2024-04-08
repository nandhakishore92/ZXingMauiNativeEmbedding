using Microsoft.Maui.Embedding;
using ZXing.Net.Maui.Controls;
using ZXingMauiNativeEmbedding.MauiPages;

namespace ZXingMauiNativeEmbedding.Droid
{
	[Activity(Label = "@string/app_name", MainLauncher = true, Theme = "@style/Theme.MaterialComponents.Light.DarkActionBar")]
    public class MainActivity : Activity
    {
		public static readonly Lazy<MauiApp> MauiApp = new(() =>
		{
			var mauiApp = MauiProgram.CreateMauiApp(builder =>
			{
				builder
					.UseMauiEmbedding()
					.UseBarcodeReader();
			});
			return mauiApp;
		});
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			// Ensure .NET MAUI app is built before creating .NET MAUI views
			var mauiApp = MauiApp.Value;

			// Create .NET MAUI context
			var mauiContext = new MauiContext(mauiApp.Services, this);  // Create app context
			var mauiView = new MainPage();
			var scannerView = mauiView.ToPlatformEmbedded(mauiContext);
			SetContentView(scannerView);
		}

		public override void OnBackPressed()
		{
			MoveTaskToBack(true);
		}
	}
}