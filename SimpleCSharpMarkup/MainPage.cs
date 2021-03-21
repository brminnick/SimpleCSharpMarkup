using Xamarin.Forms;
using Xamarin.CommunityToolkit.Markup;
using static Xamarin.CommunityToolkit.Markup.GridRowsColumns;

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
                    (Row.Counter, 30),
                    (Row.Button, Star)),

                ColumnDefinitions = Columns.Define(
                    (Column.Label, Star),
                    (Column.Value, Star)),

                Children =
                {
                    new TextLabel("Tap Count").TextEnd()
                        .Row(Row.Counter).Column(Column.Label),

                    new Label().TextStart()
                        .Row(Row.Counter).Column(Column.Value)
                        .Bind<Label, int, string>(Label.TextProperty, nameof(MainViewModel.TappedCount), convert: intValue => intValue.ToString()),

                    new TextButton("Tap Here")
                        .Row(Row.Button).ColumnSpan(All<Column>())
                        .Bind(Button.CommandProperty, nameof(MainViewModel.ButtonTapped))
                }
            }.Center();
        }

        enum Row { Counter, Button }
        enum Column { Label, Value }

        class TextLabel : Label
        {
            public TextLabel(in string text) => Text = text;
        }

        class TextButton : Button
        {
            public TextButton(in string text) => Text = text;
        }
    }
}
