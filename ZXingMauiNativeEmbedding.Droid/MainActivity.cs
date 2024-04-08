using Microsoft.Maui.Embedding;
using Microsoft.Maui.Platform;
using ZXing.Net.Maui.Controls;

namespace ZXingMauiNativeEmbedding.Droid
{
	[Activity(Label = "@string/app_name", MainLauncher = true, Theme = "@style/Theme.MaterialComponents.Light.DarkActionBar")]
	public class MainActivity : Activity
	{
		MauiContext mauiContext;
		protected override void OnCreate(Bundle? savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			var builder = MauiApp.CreateBuilder();
			builder.UseMauiEmbedding<Microsoft.Maui.Controls.Application>().UseBarcodeReader();
			var mauiApp = builder.Build();
			mauiContext = new MauiContext(mauiApp.Services, this);
			var myMauiPage = new MainPage();
			var containerView = myMauiPage.ToContainerView(mauiContext);
			SetContentView(containerView);
		}
	}
}