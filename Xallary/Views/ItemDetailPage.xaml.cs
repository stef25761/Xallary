using System.ComponentModel;
using Xallary.ViewModels;
using Xamarin.Forms;

namespace Xallary.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}