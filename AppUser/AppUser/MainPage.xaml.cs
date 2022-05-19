using AppUser.Models;
using AppUser.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppUser
{
    public partial class MainPage : ContentPage
    {
        private User user;
        private UserAPI api;
        public MainPage()
        {
            InitializeComponent();
            api = new UserAPI();
        }

        private async void btRegister_Clicked(object sender, EventArgs e)
        {
            try
            {
                user = new User();
                user.FirstName = entFirstName.Text;
                user.Surname = entSurname.Text;
                user.Age = Convert.ToInt32(entAge.Text);

                await api.CreateUser(user);

                await DisplayAlert($"Alerta", "Cadastro de usuário realizado com sucesso!", "OK");

                ClearData();
            }
            catch (Exception error)
            {
                await DisplayAlert("Erro", error.Message, "OK");
            }
        }

        private void ClearData()
        {
            entFirstName.Text = "";
            entSurname.Text = "";
            entAge.Text = "";   
        }
    }
}
