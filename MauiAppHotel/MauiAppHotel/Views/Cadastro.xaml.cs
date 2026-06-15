using MauiAppHotel.Models;

namespace MauiAppHotel.Views;

public partial class Cadastro : ContentPage
{
	public Cadastro()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		try 
		{
			Usuario u = new Usuario();
			u.Nome = txtNome.Text;
			u.Email = txtEmail.Text;
			u.Senha = txtSenha.Text;

			if(u.Senha != txtConfirmarSenha.Text)
			{
				await DisplayAlertAsync("Ops", "As senhas não coincidem", "OK");
				return;
			}

			App.lista_usuarios.Add(u);

			await DisplayAlertAsync("OK", "Cadastro concluído", "OK");

			await Navigation.PushAsync(new Views.Login());
        }
		catch(Exception ex) {
			await DisplayAlertAsync("Ops", ex.Message, "OK");
		}
		
    }
}