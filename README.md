# How-to-add-custom-data-marker-in-Xamarin.Forms-Chart

In this article, we will discuss how to use the custom view as a chart data marker and how to change its appearance based on the y plot.

Step 1: 

By using the ChartDataMarker LabelTemplate, we can replace the data marker label with our own view.

The following code sample shows how to add a circle ring shape as a data marker using the Xamarin. Forms border.

    <chart:SfChart>
            . . .        
    <chart:SfChart.Series>
        <chart:SplineAreaSeries ItemsSource="{Binding AreaCollection}" 
                                XBindingPath="XData" 
                                YBindingPath="YData" >
            <chart:SplineAreaSeries.DataMarker>
                <chart:ChartDataMarker x:Name="dataMarker">
                    <chart:ChartDataMarker.LabelTemplate>
                        <DataTemplate>
                            <sfborder:SfBorder 
                                HeightRequest="10" 
                                CornerRadius="20" 
                                WidthRequest="10" 
                                BorderColor="Red" 
                                BorderWidth="2" 
                                BackgroundColor="WhiteSmoke">
                            </sfborder:SfBorder>
                        </DataTemplate>
                    </chart:ChartDataMarker.LabelTemplate>

                    <chart:ChartDataMarker.LabelStyle>
                        <chart:DataMarkerLabelStyle LabelPosition="Center"/>
                    </chart:ChartDataMarker.LabelStyle>
                </chart:ChartDataMarker>
            </chart:SplineAreaSeries.DataMarker>
        </chart:SplineAreaSeries>
    </chart:SfChart.Series>
    </chart:SfChart>

Step 2:

Using IValueConverter, we can customize each and every single view that is added as a data marker, the following code shows how to change the circle color based on the "Y" series of plots.

XAML
    <ContentPage.Resources>
        <local:BorderColorConverter x:Key="borderColorConverter"/>
    </ContentPage.Resources> 

    <chart:SfChart>
    . . . 
    <chart:SfChart.Series>
        . . .
                <chart:ChartDataMarker x:Name="dataMarker">
                    <chart:ChartDataMarker.LabelTemplate>
                        <DataTemplate>
                            <sfborder:SfBorder 
                                HeightRequest="10" 
                                CornerRadius="20" 
                                WidthRequest="10" 
                                BorderColor="{Binding Converter={StaticResource borderColorConverter}}" 
                                BorderWidth="2" 
                                BackgroundColor="WhiteSmoke">
                            </sfborder:SfBorder>
                        </DataTemplate>
                    </chart:ChartDataMarker.LabelTemplate>
                </chart:ChartDataMarker>
            </chart:SplineAreaSeries.DataMarker>
        </chart:SplineAreaSeries>
    </chart:SfChart.Series>
    </chart:SfChart>


IValueConverter:

    public class BorderColorConverter : IValueConverter
    {
      static double YValue = 0;
      public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value != null)
        {
            var yData = (value as DataModel).YData;
            if (yData >= YValue)
            {
                //if y value increased
                YValue = yData;
                return Color.Green;
            }
            else
            {
                //if y value decreased
                YValue = yData;
                return Color.Red;
            }
        }

        return value;
    }
    }
