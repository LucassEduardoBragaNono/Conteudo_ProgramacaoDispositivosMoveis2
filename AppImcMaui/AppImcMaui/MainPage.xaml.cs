namespace AppImcMaui
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            double altura_metros = Convert.ToDouble(altura.Text);
			double peso_quilos = Convert.ToDouble(peso.Text);
            string msg = "";
            double imc = peso_quilos / (altura_metros * altura_metros);

            if (imc <= 18.5)
            {
                msg = "Abaixo do peso";
            }
            else if (imc > 18.5 && imc <= 24.9)
            {
                msg = "Peso normal";
            }
            else if (imc > 24.9 && imc <= 29.9)
            {
                msg = "Acima do peso";
            }
            else if (imc > 30)
            {
                msg = "Obesidade";
            }
		}
	}
}
