using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GarnerLifeAppRevised
{
    [DesignTimeVisible(false)]
    public partial class MainPage 
    {
        public string Message
        {
            get
            {
                return textLabel.Text;
            }
            set
            {
                textLabel.Text = value;
            }
        }
        public MainPage()
        {
            InitializeComponent();
            
        }
        protected override bool OnBackButtonPressed()
        { 
            base.OnBackButtonPressed();
            //return false;

            return true;
        }
    }
}
