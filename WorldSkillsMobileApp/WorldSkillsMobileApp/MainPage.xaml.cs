using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace WorldSkillsMobileApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            frameCaptcha.BorderColor = this.BackgroundColor;
            frameLogin.BorderColor = this.BackgroundColor;
            framePassword.BorderColor = this.BackgroundColor;
            lableLogin.Text = "";
            lablePassword.Text = "";
            frameCaptcha.BackgroundColor = Color.Transparent;
            frameLogin.BackgroundColor = Color.Transparent;
            framePassword.BackgroundColor = Color.Transparent;
            lableLogin.BackgroundColor = Color.Transparent;
            lablePassword.BackgroundColor = Color.Transparent;
            slider.ThumbImageSource = "RightArrow.png";
            slider.DragCompleted += Slider_DragCompleted;


        }

        private void Slider_DragCompleted(object sender, EventArgs e)
        {
            if (slider.Value == slider.Maximum)
            {
                slider.Opacity = 0;
                frameCaptcha.BorderColor = this.BackgroundColor;
                lableCaptcha.Text = "";
            }
            else
            {
                slider.Value = slider.Minimum;
                
            }
        }

        private async void ButtonAutorization_Clicked(object sender, EventArgs e)
        {
            StringBuilder errorList = new StringBuilder();
            if (string.IsNullOrWhiteSpace(entryLogin.Text))
            {
                errorList.AppendLine("Логин не может быть пустым или состоять из пробелов");
                lableLogin.Text = "Введите логин";
                frameLogin.BorderColor = Color.Red;
            }
            else
            {
                frameLogin.BorderColor = this.BackgroundColor;
                lableLogin.Text = "";
            }
            if (string.IsNullOrWhiteSpace(entryPassword.Text))
            {
                errorList.AppendLine("Пароль не может быть пустым или состоять из пробелов");
                lablePassword.Text = "Введите пароль";
                framePassword.BorderColor = Color.Red;
            }
            else
            {
                framePassword.BorderColor = this.BackgroundColor;
                lablePassword.Text = "";
            }
            if (slider.Value != slider.Maximum)
            {
                errorList.AppendLine("Перетащите ползунок впрво!");
                frameCaptcha.BorderColor = Color.Red; 
                lableCaptcha.Text = "Перетощите ползунок вправо.";
            }
            else
            {
                frameCaptcha.BorderColor = this.BackgroundColor;
                lableCaptcha.Text = "";
            }
            if (errorList.Length == 0)
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync("http://www.worldskillsrussia.somee.com/api/BigData");
                HttpContent responseContent = response.Content;
                string json = await responseContent.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<Pages.BigData>(json);
                await Navigation.PushAsync(new Pages.TempPage() { Title = entryLogin.Text, BigData = data});
            }
            else
            {
                slider.Opacity = 100;
                slider.Value = slider.Minimum;
                lableCaptcha.Text = "Перетощите ползунок вправо.";
            }
            
        }


        
    }
}
