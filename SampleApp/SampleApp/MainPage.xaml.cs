using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleApp
{
    public partial class MainPage : ContentPage
    {
        public const string ShowPop = "ShowPop";

        public MainPage()
        {
            InitializeComponent();
        }

        void ShowPopBtn_Clicked(System.Object sender, System.EventArgs e)
        {
            MessagingCenter.Send(new object(), ShowPop);
        }
    }
}
