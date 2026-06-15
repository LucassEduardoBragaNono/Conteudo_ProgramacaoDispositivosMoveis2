using MauiAppHotel.Models;

namespace MauiAppHotel.Views;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

    private async void Button_Clicked_Entrar(object sender, EventArgs e)
    {
        try 
        {
            Usuario u = new Usuario();
            u.Email = txtEmail.Text;
            u.Senha = txtSenha.Text;

            bool retorno = App.lista_usuarios.Any(i => (i.Senha == u.Senha && i.Email == u.Email));

            if (retorno)
            {
                await DisplayAlertAsync("Muito bem!", "Logado com sucesso", "OK");
                await SecureStorage.Default.SetAsync("nome_usuario", u.Email);
                await Navigation.PushAsync(new Views.ContratacaoHospedagem());
            } else
            {
                throw new Exception("Email ou senha incorretos");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Ops", ex.Message, "OK");
        }
    }

    private void Button_Clicked_Cadastro(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Views.Cadastro());
    }
}