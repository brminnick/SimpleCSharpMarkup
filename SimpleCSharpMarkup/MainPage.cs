using Xamarin.Forms;
using Xamarin.Forms.Markup;
using static Xamarin.Forms.Markup.GridRowsColumns;

namespace SimpleCSharpMarkup
{
    public class MainPage : ContentPage
    {
        public MainPage()
        {
            BindingContext = new MainViewModel();

            Content = new Grid
            {
                RowDefinitions = Rows.Define(
                    (Row.Counter, AbsoluteGridLength(30)),
                    (Row.Button, Star)),    
                ColumnDefinitions = Columns.Define(
                    (Column.Label, Star),
                    (Column.Value, Star)),

                Children =
                {
                    new BoldLabel().TextEnd()
                        .Row(Row.Counter).Column(Column.Label),
                    new Label().TextStart()
                        .Row(Row.Counter).Column(Column.Value)
                        .Bind<Label, int, string>(Label.TextProperty, nameof(MainViewModel.TappedCount), convert: intValue => intValue.ToString()),
                    new Button { Text = "Tap Here" }
                        .Row(Row.Button).ColumnSpan(All<Column>())
                        .Bind(Button.CommandProperty, nameof(MainViewModel.ButtonTapped))
                }
            }.Center();
        }

        enum Row { Counter, Button }
        enum Column { Label, Value }

        static GridLength AbsoluteGridLength(double value) => new GridLength(value, GridUnitType.Absolute);

        class BoldLabel : Label
        {
            public BoldLabel()
            {
                Text = "Tapped Count";
                FontSize = 13;
                FontAttributes = FontAttributes.Bold;
            }
        }
    }
}
