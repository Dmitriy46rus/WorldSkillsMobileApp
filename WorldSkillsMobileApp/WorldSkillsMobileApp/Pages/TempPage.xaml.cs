using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorldSkillsMobileApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TempPage : ContentPage
    {
        public BigData BigData {
            set
            {
                lableDescription.Text = value.Description;
                lableSubtitle.Text = value.Subtitle;
                lableTitle.Text = value.Title;
                image.Source = ImageSource.FromStream(() => new MemoryStream(value.Photo));
            }
        }
        public TempPage()
        {
            InitializeComponent();

        }


    }


    

    public class BigData
    {
        public string Title { get; set; }
        public byte[] Photo { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }

    }

}