using MvvmHelpers;
using Syncfusion.XForms.Buttons;
using Syncfusion.XForms.TextInputLayout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Markup;
using Xamarin.Forms.Xaml;
using XFHabitTracker.ViewModels;

namespace XFHabitTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddHabitPage : ContentPage
    {
        private readonly object _viewModel;

        public AddHabitPage()
        {
            //InitializeComponent();
            Build();

            this.BindingContext = _viewModel = Startup.ServiceProvider.GetService<AddHabitViewModel>();
        }

        private void Build()
        {
            //SfTextInputLayouで例外が発生してしまう.どうしたらいいんだ.
            Content = new StackLayout
            {
                Children =
                {
                    new SfTextInputLayout{
                        Hint="Name",
                        InputView=new Entry{Placeholder="habit name"}.Bind(Entry.TextProperty,nameof(AddHabitViewModel.Name)),
                    },
                    new SfButton{Text="Ok"}.BindCommand(nameof(AddHabitViewModel.AddNewHabitCommand))
                }
            };
        }
    }
}