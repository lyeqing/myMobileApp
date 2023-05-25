using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyMobileApp.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }
        public void HandleClick(Object sender, EventArgs args) {
            var lavb = new Label();
            lavb.Text = "adfgadfgad;";
            bbbu.Text = "done";
            Console.WriteLine("Clicked sdfds !!!@");
            stach.Children.Insert(1,lavb);
        }
    }
}