namespace AppJogoDaVelha2
{
	public partial class MainPage : ContentPage
	{
		string vez = "X";
		int count = 0;
		int vitoriaX = 0;
		int vitoriaO = 0;
		int empates = 0;

		public MainPage()
		{
			InitializeComponent();
		}

		private async void Button_Clicked(object sender, EventArgs e)
		{
			Button clicado = (Button)sender;
			count++;
			clicado.Text = vez;
			clicado.IsEnabled = false;


			if (VerificarVitoria(vez))
			{
				await DisplayAlertAsync("Vitória!", $"O jogador {vez} venceu!", "OK");

				if (vez == "X")
				{
					vitoriaX++;
				}
				else
				{
					vitoriaO++;
				}

				lblPlacar.Text = $"Vitórias X: {vitoriaX} | Vitórias O: {vitoriaO} | Empates: {empates}";

				ReiniciarJogo();
				return;
			}
			else if (count == 9)
			{
				await DisplayAlertAsync("Velha!", $"O jogo deu empate!", "OK");
				empates++;
				lblPlacar.Text = $"Vitórias X: {vitoriaX} | Vitórias O: {vitoriaO} | Empates: {empates}";
				ReiniciarJogo();
				return;
			}

			

			vez = (vez == "X") ? "O" : "X";
		}

		bool VerificarVitoria(string jogada)
		{
			if (btn10.Text == jogada && btn11.Text == jogada && btn12.Text == jogada) return true;
			if (btn20.Text == jogada && btn21.Text == jogada && btn22.Text == jogada) return true;
			if (btn30.Text == jogada && btn31.Text == jogada && btn32.Text == jogada) return true;

			if (btn10.Text == jogada && btn20.Text == jogada && btn30.Text == jogada) return true;
			if (btn11.Text == jogada && btn21.Text == jogada && btn31.Text == jogada) return true;
			if (btn12.Text == jogada && btn22.Text == jogada && btn32.Text == jogada) return true;

			if (btn10.Text == jogada && btn21.Text == jogada && btn32.Text == jogada) return true;
			if (btn12.Text == jogada && btn21.Text == jogada && btn30.Text == jogada) return true;

			return false;
		}


		void ReiniciarJogo()
		{
			Button[] botoes =
			{
				btn10, btn11, btn12,
				btn20, btn21, btn22,
				btn30, btn31, btn32
			};

			foreach (var botao in botoes)
			{
				botao.Text = "";
				botao.IsEnabled = true;
			}

			count = 0;
		}
	}
}