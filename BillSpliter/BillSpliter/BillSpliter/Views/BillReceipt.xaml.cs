using BillSpliter.Model;
using BillSpliter.Services;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BillSpliter.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BillReceipt : ContentPage
    {
        private readonly Bill _bill;
        public BillReceipt(Bill bill)
        {
            _bill = bill;
            InitializeComponent();
            Calcule();
        }

        private void Calcule() 
        {
            double tipMount = _bill.Amout * _bill.Tip / 100;
            double total = tipMount + _bill.Amout;
            double perPerson = total / _bill.People;

            lblAmount.Text = _bill.Amout.ToString("C", CultureInfo.CurrentCulture);
            lblTip.Text = tipMount.ToString("C", CultureInfo.CurrentCulture);
            lblTotal.Text = total.ToString("C", CultureInfo.CurrentCulture);
            lblPerPeople.Text = perPerson.ToString("C", CultureInfo.CurrentCulture);
        }

        private async void btnShare_Clicked(object sender, System.EventArgs e)
        {
            await ScreenshotService.CaptureScreenshotAsync();
        }

        private async void lblCancel_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}