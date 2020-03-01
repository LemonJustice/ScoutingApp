using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.IO;
using Xamarin.Forms.Xaml;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;

namespace ScoutingApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public struct Fonterish
        {
            public static double medium, small;

            public Fonterish(double x, double y)
            {
                medium = x;
                small = y;
            }
        }

        public int RepeatTeam;

        public int CurrIndex;

        public int Climb = 0;

        private string fileName;

        public int FileCount;


        public MainPage()
        {
            InitializeComponent();

            CurrIndex = 0;
            FileCount = 0;
            RepeatTeam = -1;

         
            Data = new List<string>{ "null", "null", "0", "0", "0", "0", "0", "0", "0", "Null" };
            Original = new List<string> { "null", "null", "0", "0", "0", "0", "0", "0", "0", "Null" };
            Entries = new List<Entry> ( new Entry[10] );
            this.BackgroundImageSource = "background.png";
            this.IconImageSource = "neobotsLogo.png";

            StoragePopup();
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            Fonterish.medium = height / 28;
            Fonterish.small = width / 22;
            m1.FontSize = Fonterish.medium;
            m2.FontSize = Fonterish.medium;
            m3.FontSize = Fonterish.medium;
            m4.FontSize = Fonterish.medium;
            m5.FontSize = Fonterish.medium;
            m6.FontSize = Fonterish.medium;
            m7.FontSize = Fonterish.medium;
            m9.FontSize = Fonterish.medium;
            m10.FontSize = Fonterish.medium;
            m11.FontSize = Fonterish.medium;
            m12.FontSize = Fonterish.medium;
            m14.FontSize = Fonterish.medium;
            m15.FontSize = Fonterish.medium;
            m17.FontSize = Fonterish.medium;
        }

        async void StoragePopup()
        {
            await DisplayAlert("This app requires permissions", "Writing data to your phone's storage is a important part of this scouting operation. \n\nThis app WILL crash if you do not allow the app to write to storage.", "I understand");
          
            string directory = "";
            if (Device.RuntimePlatform == Device.iOS)
            {
                directory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }
            else if (Device.RuntimePlatform == Device.Android)
            {
                directory = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDocuments).AbsolutePath;
            }
            fileName = Path.Combine(directory, "ScoutingTest.csv");
        }

        //0 = team num
        //2-4 = hatches, 5-7 = cargo
        //8 -9 = cargo ship
        public List<string> Data { get; set; }
        public List<string> Original { get; set; }

        public List<Entry> Entries { get; set; }

        private void NextMatch(object sender, EventArgs e)
        {
            for (int i = 0; i < Data.Count; i++)
            {
                File.AppendAllText(fileName, Data[i]);
                File.AppendAllText(fileName, ",");
            }
            Data = Original;

            File.AppendAllText(fileName, "\n");

            for (int i = 0; i < Entries.Count; i++)
            {
                if (Entries[i] != null)
                {
                    Entries[i].Text = string.Empty;
                }
            }
        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            Entries[int.Parse(((Entry)sender).BindingContext as string)] = ((Entry)sender);
            Data[int.Parse(((Entry)sender).BindingContext as string)] = ((Entry)sender).Text;
            if(string.IsNullOrEmpty(e.NewTextValue))
                ((Entry)sender).Text = string.Empty;
        }

        private void RocketChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                ((Entry)sender).Text = string.Empty;
                return;
            }

            if (((Entry)sender).Text != ((Entry)sender).Placeholder) { 
                double _;
                if (!double.TryParse(e.NewTextValue, out _))
                    ((Entry)sender).Text = e.OldTextValue;

                int i = int.Parse(((Entry)sender).Text);
                ((Entry)sender).Text = Convert.ToString(i);
            }

            Entries[int.Parse(((Entry)sender).BindingContext as string)] = ((Entry)sender);
            Data[int.Parse(((Entry)sender).BindingContext as string)] = ((Entry)sender).Text;
        }

        private void ShipChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                ((Entry)sender).Text = string.Empty;
                return;
            }

                double _;
                if (!double.TryParse(e.NewTextValue, out _))
                    ((Entry)sender).Text = e.OldTextValue;

                int i = int.Parse(((Entry)sender).Text);
                ((Entry)sender).Text = Convert.ToString(i);
       
            Entries[int.Parse(((Entry)sender).BindingContext as string)] = ((Entry)sender);
            Data[int.Parse(((Entry)sender).BindingContext as string)] = ((Entry)sender).Text;
        }

        private void ClimbClicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (Climb == 1)
            {
                Climb = 0;
                btn.BackgroundColor = Color.FromHex("#E4220066");
            }
            else {
                Climb = 1;
                btn.BackgroundColor = Color.FromHex("#E4110044");
            }
            Data[8] = Climb.ToString();
        }
    }
}
