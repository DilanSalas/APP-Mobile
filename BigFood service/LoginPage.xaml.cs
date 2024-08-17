using BigFood_service.Models;
using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace BigFood_service
{
    public partial class LoginPage : ContentPage
    {
        private Conexion conexion;

        public LoginPage()
        {
            InitializeComponent();
            conexion = new Conexion();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            string username = usernameEntry.Text;
            string password = passwordEntry.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                await DisplayAlert("Validation Error", "Please enter both username and password.", "OK");
                return;
            }

            Usuario user = await conexion.ValidarUsuario(username, password);
            if (user != null)
            {
                // Navegar a la p�gina principal de la aplicaci�n
                await DisplayAlert("Login Successful", "Welcome!", "OK");
                // Navegar a la p�gina principal despu�s de un inicio de sesi�n exitoso
                await Shell.Current.GoToAsync("//MainPage");
            }
            else
            {
                await DisplayAlert("Login Failed", "Invalid username or password.", "OK");
            }
        }
    }
}

