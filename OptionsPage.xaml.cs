//using Android.Views;
using Newtonsoft.Json;
//using static Android.Provider.Settings;

namespace WeatherApp1;

public partial class OptionsPage : ContentPage
{
	public OptionsPage()
	{
		InitializeComponent();
	}

    private async void OnButtonAddClick(object sender, EventArgs e)
    {
        var p = EntryCity.Text.ToString();
        string json = await SecureStorage.GetAsync(p);
        if (!string.IsNullOrEmpty(json))
        {
            //LabelInfo.Text = json;
            List<City> data = JsonConvert.DeserializeObject<List<City>>(json);
            foreach (var track in data)
            {
                LabelInfo.Text += Environment.NewLine + track.Title + track.Latitude.ToString() +
                    track.Longitude.ToString();
            }                
        }
        else
        {
            await SecureStorage.SetAsync("name2", "Sergeu");
        }
    }

    private void OnCuttonClear(object sender, EventArgs e)
    {
        SecureStorage.RemoveAll();
        DisplayAlert("Уведомление", "Список городов очищен!", "ОК");
        List<City> cities;
        City city1 = new City();
        city1.Title = "Москва";
        city1.Latitude = 55.75;
        city1.Longitude = 37.62;

        City city2 = new City();
        city2.Title = "Санкт-Петербург";
        city2.Latitude = 59.94;
        city2.Longitude = 30.31;

        City city3 = new City();
        city3.Title = "Сочи";
        city3.Latitude = 43.60;
        city3.Longitude = 39.73;

        cities = new List<City> { city1, city2, city3 };
        string data = JsonConvert.SerializeObject(cities);
        SecureStorage.SetAsync("City", data); // key: City - под ним храниться список словарей
        DisplayAlert("Уведомление", "Добавлены 3 базовых города!", "ОК");
    }
}