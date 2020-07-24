using Syncfusion.ListView.XForms;
using Syncfusion.XForms.Buttons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Markup;
using Xamarin.Forms.Xaml;
using XFHabitTracker.Models;
using XFHabitTracker.Services;
using XFHabitTracker.ViewModels;

namespace XFHabitTracker.Views
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HabitListPage : ContentPage
    {
        private readonly HabitListViewModel _viewModel;

        public HabitListPage()
        {
            //InitializeComponent();
            Build();

            this.BindingContext = _viewModel = Startup.ServiceProvider.GetService<HabitListViewModel>();
        }

        private void Build()
        {
            Content = new Grid
            {
                Children =
                {
                    HabitList,
                    new SfButton{ Text="Add",
                                  HorizontalOptions=LayoutOptions.End,
                                  VerticalOptions=LayoutOptions.End,
                    }.Margins(10,10,10,10)
                    .Invoke(button=>{
                        button.Clicked+=AddHabitButtonClicked;
                    }),
                    new Label{
                        BackgroundColor=Color.Yellow,
                        HorizontalOptions=LayoutOptions.Start,
                        VerticalOptions=LayoutOptions.End
                    }.FormattedText(new Span{}.Bind(Span.TextProperty,nameof(HabitListViewModel.ActionType)),
                                    new Span{Text=" "},
                                    new Span{}.Bind(Span.TextProperty,nameof(HabitListViewModel.HabitId)))
                }
            };
        }

        SfListView HabitList = new SfListView
        {
            AutoFitMode = AutoFitMode.Height,
            DragStartMode = DragStartMode.OnHold,
            FooterSize = 200,
            ItemSpacing = 0.5,
            DragItemTemplate = new DataTemplate(() => HabitListItemTemplate(Color.LightPink)),
            ItemTemplate = new DataTemplate(() => HabitListItemTemplate(Color.LightBlue)),
            FooterTemplate = new DataTemplate(() => new Grid { }.Height(100)),
        }.Bind(SfListView.ItemsSourceProperty, nameof(HabitListViewModel.Habits));

        private static StackLayout HabitListItemTemplate(Color bgColor) => new StackLayout
        {
            BackgroundColor = bgColor,
            Children =
                {
                    new Label{}.Bind(Label.TextProperty,nameof(Habit.Name)),
                    new Label{}.Bind(Label.TextProperty,nameof(Habit.Id)),
                }
        };


        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await _viewModel.UpdateList();
        }

        private async void AddHabitButtonClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(AddHabitPage));
        }
    }
}