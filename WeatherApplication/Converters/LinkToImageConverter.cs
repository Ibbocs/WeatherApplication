using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApplication.Converters
{
    public class LinkToImageConverter : IValueConverter //bu sayede converterler yaziriq
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string link)//bize apiden gelen datada iconlar gelir, olarin url'sinin evveline https: yoxdu deye elave edirik.Cunki o iconleri istfade edeceyik...
            {              
                link = link.StartsWith("//") ? link.Insert(0, "https:") : link;
                var imageSource = ImageSource.FromUri(new Uri(link));//link değişkenindeki URL’den bir resim yükleyerek bir ImageSource nesnesi oluşturacak, bunu da viewde islederik ContentPage.Resources altinda

                return imageSource;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
