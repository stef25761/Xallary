using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xallary.Models;
using Xallary.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xallary.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}