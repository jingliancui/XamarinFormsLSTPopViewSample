using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Xamarin.Forms;
using LSTPopView_ApiDefinition;

namespace SampleApp.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {

        private UILabel text;

        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            text = new UILabel(new CoreGraphics.CGRect(0, 60, 50, 50))
            {
                Text = "click"
            };

            MessagingCenter.Subscribe<object>(this, MainPage.ShowPop, _ =>
            {
                var view = new UIView(new CoreGraphics.CGRect(0, 0, 200, 200)) { BackgroundColor = UIColor.DarkGray };
                var button = new UIButton(new CoreGraphics.CGRect(0, 0, 50, 50)) {BackgroundColor=UIColor.Gray };
                button.SetTitle("click", UIControlState.Normal);
                button.TouchUpInside += Button_TouchUpInside;
                view.AddSubviews(button,text);
                var popView=LSTPopView.InitWithCustomView(view);
                popView.HemStyle = LSTPopView_Structs.LSTHemStyle.Center;
                popView.BgClickBlock = () =>
                {
                    popView.Dismiss();
                };
                popView.Pop();
            });

            return base.FinishedLaunching(app, options);
        }

        private void Button_TouchUpInside(object sender, EventArgs e)
        {
            if (text.Text=="ok")
            {
                text.Text = "click";
                return;
            }
            if (text.Text=="click")
            {
                text.Text = "ok";
                return;
            }

        }
    }
}
