using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ScoutingApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            CurrIndex = 0;
            RepeatTeam = -1;
            Data = new List<List<string>> { new List<string> { "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "0" } };
            Entries = new List<Entry> ( new Entry[10] );
            RepeatTeam = -1;
            this.BackgroundImage = "SpaceBackground.jpg";
        }

        //0 = team num, 1 = match
        //2-4 = hatches, 5-7 = cargo
        //8 -9 = cargo ship
        public List<List<string>> Data
        {
            get;
            set;
        }

        public int RepeatTeam { get; set; }

        public int CurrIndex { get; set; }

        public int Climb { get; set; }

        public List<Entry> Entries{ get; set;}

        private void Export_Clicked(object sender, EventArgs e)
        {
            
        }

        private void NextMatch(object sender, EventArgs e)
        {
            for (int i = 0; i < Entries.Count; i++)
            {
                if(Entries[i] == null)
                {
                    if (i < 2)
                        Entries[i] = new Entry() { Text = "null" };
                    else
                        Entries[i] = new Entry() { Text = "0" };
                }
                for (int j = 0; j < Data.Count; j++)
                {
                    if(Data?[j][0] == Entries[0].Text)
                        RepeatTeam = j;
                    else
                        RepeatTeam = -1;
                }
                if (RepeatTeam == -1)
                {
                    Data[CurrIndex][i] = Entries[i].Text;
                }else if(i < 2 || i == 11)
                {
                    Data[RepeatTeam][i] = Entries[i].Text;
                }else if(i >= 2 && i < 10)
                {
                    Data[RepeatTeam][i] = Convert.ToString((int.Parse(Entries[i].Text) + int.Parse(Data[RepeatTeam][i])) / 2);
                } else if(i == 10)
                {
                    Data[RepeatTeam][i] = Convert.ToString((Climb + int.Parse(Data[RepeatTeam][i])) / 2);
                }
                Entries[i].Text = string.Empty;
            }
            CurrIndex += 1;
            Data.Add(new List<string> { "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "0" });
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            Entries[0] = (Entry)sender;
        }
        private void Entry_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            Entries[1] = (Entry)sender;
        }
        private void Entry_TextChanged_2(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                ((Entry)sender).Text = 0.ToString();
                return;
            }

            double _;
            if (!double.TryParse(e.NewTextValue, out _))
                ((Entry)sender).Text = e.OldTextValue;

            if (int.Parse(((Entry)sender).Text) > 4)
            {
                ((Entry)sender).Text = "4";
            }
            Entries[2] = (Entry)sender;
        }
        private void Entry_TextChanged_3(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                ((Entry)sender).Text = 0.ToString();
                return;
            }

            double _;
            if (!double.TryParse(e.NewTextValue, out _))
                ((Entry)sender).Text = e.OldTextValue;

            if (int.Parse(((Entry)sender).Text) > 4 ){
                ((Entry)sender).Text = "4";
            }
            Entries[3] = (Entry)sender;
        }
        private void Entry_TextChanged_4(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                ((Entry)sender).Text = 0.ToString();
                return;
            }

            double _;
            if (!double.TryParse(e.NewTextValue, out _))
                ((Entry)sender).Text = e.OldTextValue;

            if (int.Parse(((Entry)sender).Text) >4)
            {
                ((Entry)sender).Text = "4";
            }
            Entries[4] = (Entry)sender;
        }
        private void Entry_TextChanged_5(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                ((Entry)sender).Text = 0.ToString();
                return;
            }

            double _;
            if (!double.TryParse(e.NewTextValue, out _))
                ((Entry)sender).Text = e.OldTextValue;

            if (int.Parse(((Entry)sender).Text) >4)
            {
                ((Entry)sender).Text = "4";
            }
            Entries[5] = (Entry)sender;
        }
        private void Entry_TextChanged_6(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                ((Entry)sender).Text = 0.ToString();
                return;
            }

            double _;
            if (!double.TryParse(e.NewTextValue, out _))
                ((Entry)sender).Text = e.OldTextValue;

            if (int.Parse(((Entry)sender).Text) >4)
            {
                ((Entry)sender).Text = "4";
            }
            Entries[6] = (Entry)sender;
        }
        private void Entry_TextChanged_7(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                ((Entry)sender).Text = 0.ToString();
                return;
            }

            double _;
            if (!double.TryParse(e.NewTextValue, out _))
                ((Entry)sender).Text = e.OldTextValue;

            if (int.Parse(((Entry)sender).Text) >4)
            {
                ((Entry)sender).Text = "4";
            }
            Entries[7] = (Entry)sender;
        }
        private void Entry_TextChanged_8(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                ((Entry)sender).Text = 0.ToString();
                return;
            }

            double _;
            if (!double.TryParse(e.NewTextValue, out _))
                ((Entry)sender).Text = e.OldTextValue;

            if (int.Parse(((Entry)sender).Text) > 8)
            {
                ((Entry)sender).Text = "8";
            }
            Entries[8] = (Entry)sender;
        }
        private void Entry_TextChanged_9(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                ((Entry)sender).Text = 0.ToString();
                return;
            }

            double _;
            if (!double.TryParse(e.NewTextValue, out _))
                ((Entry)sender).Text = e.OldTextValue;

            if (int.Parse(((Entry)sender).Text) >8)
            {
                ((Entry)sender).Text = "8";
            }
            Entries[9] = (Entry)sender;
        }
        private void Entry_TextChanged_10(object sender, TextChangedEventArgs e)
        {
            Entries[11] = (Entry)sender;
        }

        private void HABStart3_Clicked(object sender, EventArgs e)
        {
            Climb = 3;
        }
        private void HABStart2_Clicked(object sender, EventArgs e)
        {

            Climb = 2;
        }
        private void HABStart1_Clicked(object sender, EventArgs e)
        {

            Climb = 1;
        }
    }
}
