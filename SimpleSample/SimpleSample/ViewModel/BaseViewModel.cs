using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace SimpleSample
{
    public class DataModel
    {
        public string XData { get; set; }
        public double YData { get; set; }
    }

    public class BaseViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<GridModel> ItemSource { get; set; }

        public ObservableCollection<DataModel> AreaCollection { get; set; }
        public ObservableCollection<View> CustomViews { get; set; }

        private ContentView content;
        public ContentView ContentView
        {
            get { return content; }
            set
            {
                content = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("ContentView"));
            }
        }

        public BaseViewModel()
        {
            CustomViews = new ObservableCollection<View>();
            string fontfamily = "FontAwesome5Pro-Regular";
            if (Device.RuntimePlatform == Device.Android)
            {
                fontfamily = "FontAwesome.otf#FontAwesome5Pro-Regular";
            }
            else if (Device.RuntimePlatform == Device.UWP)
            {
                fontfamily = "/Assets/FontAwesome.otf#FontAwesome5Pro-Regular";
            }

            Image photo = new Image()
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };

            Image video = new Image()
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };

            Image doc = new Image()
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };

            photo.Source = new FontImageSource()
            {
                FontFamily = fontfamily,
                // Glyph = "\uf03e",
                Glyph = "\uf148",
                Size = 20,
                Color = Color.Green,
            };

            video.Source = new FontImageSource()
            {
                FontFamily = fontfamily,
                Glyph = "\uf149",
                //Glyph = "\uf03d",
                Size = 20,
                Color = Color.Red,
            };

            doc.Source = new FontImageSource()
            {
                FontFamily = fontfamily,
                Glyph = "\uf001",
                Size = 25,
                Color = Color.Accent,
            };

            var stack_1 = new StackLayout() { Orientation = StackOrientation.Horizontal, Spacing = 0, Padding = 0 };
            Label l1 = new Label() { Text = "Increase", FontSize = 15, FontAttributes = FontAttributes.Bold, TextColor = Color.Green, HorizontalTextAlignment = TextAlignment.Start, VerticalTextAlignment = TextAlignment.Center };
            stack_1.Children.Add(photo);
            stack_1.Children.Add(l1);
            Label l2 = new Label() { Text = "Decrease", FontSize = 15, FontAttributes = FontAttributes.Bold, TextColor = Color.Red, HorizontalTextAlignment = TextAlignment.Start, VerticalTextAlignment = TextAlignment.Center };
            var stack_2 = new StackLayout() { Orientation = StackOrientation.Horizontal, Spacing = 0, Padding = 0 };
            stack_2.Children.Add(video);
            stack_2.Children.Add(l2);
            CustomViews.Add(stack_1);
            CustomViews.Add(stack_2);

            ItemSource = new ObservableCollection<GridModel>()
            {
                new GridModel(){GridColumn=0, GridRow=0},
                new GridModel(){GridColumn=0, GridRow=0},
                new GridModel(){GridColumn=0, GridRow=0},
                new GridModel(){GridColumn=0, GridRow=1},
                new GridModel(){GridColumn=0, GridRow=1},
                new GridModel(){GridColumn=0, GridRow=1},
                new GridModel(){GridColumn=0, GridRow=2},
                new GridModel(){GridColumn=0, GridRow=2},
                new GridModel(){GridColumn=0, GridRow=2},
                new GridModel(){GridColumn=0, GridRow=3},
                new GridModel(){GridColumn=0, GridRow=3},
                new GridModel(){GridColumn=0, GridRow=3},
            };

            AreaCollection = new ObservableCollection<DataModel>()
            {
                new DataModel(){XData = "Jan", YData=10},
                new DataModel(){XData = "Feb", YData= 20},
                new DataModel(){XData = "Mar", YData=15},
                new DataModel(){XData = "Apr", YData=21},
                new DataModel(){XData = "May", YData=18},
                new DataModel(){XData = "Jun", YData=28},
                new DataModel(){XData = "Jul", YData=25},
                new DataModel(){XData = "Aug", YData=29},
                new DataModel(){XData = "Sep", YData=35},
                new DataModel(){XData = "Oct", YData=28},
            };
        }


        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class GridModel
    {
        public int GridRow { get; set; }
        public int GridColumn { get; set; }
    }
}
