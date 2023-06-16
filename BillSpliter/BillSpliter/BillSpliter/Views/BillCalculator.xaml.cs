using BillSpliter.Model;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BillSpliter.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BillCalculator : ContentPage
    {
        const string Zero = "0";
        const string One = "1";

        public BillCalculator()
        {
            InitializeComponent();
        }

        private async void btnCalculate_Clicked(object sender, EventArgs e)
        {
            if (!Validate())
            {
                var bill = new Bill()
                {
                    Amout = double.Parse(txtAmount.Text),
                    Tip = double.Parse(txtTipPorcent.Text),
                    People = int.Parse(txtPeople.Text),
                };

                await Navigation.PushAsync(new BillReceipt(bill));
                return;
            }
            await DisplayAlert("Advertencia!", "Favor ingrese valores validos...", "Ok");
            return;
        }

        private void btnCancel_Clicked(object sender, EventArgs e)
        {
            txtAmount.Text = Zero;
            txtTipPorcent.Text = Zero;
            txtPeople.Text = One;
        }

        private bool Validate()
        {
            if (txtAmount.Text == Zero || txtTipPorcent.Text == Zero || txtPeople.Text == Zero) return true;
            
            return false;
        }
    }
}