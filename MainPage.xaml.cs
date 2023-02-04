//using Android.Content;
//using Android.Views;
//using IntelliJ.Lang.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WeatherApp1;

public partial class MainPage : ContentPage
{
	City MyCity;
	List<City> data;

	CityViewModel viewModel;

	public MainPage()
	{
		InitializeComponent();
		LoadCities();
	}

	public async void LoadCities()
	{
        // добавление городов
        string json = await SecureStorage.GetAsync("City");
        if (!string.IsNullOrEmpty(json))
		{
			data = JsonConvert.DeserializeObject<List<City>>(json);
			foreach (var track in data)
			{
				languagePicker.Items.Add(track.Title);
			}				
		}           
    }

    private void PickerSelectedIndexChanged(object sender, EventArgs e)
	{
		string name = languagePicker.SelectedItem.ToString();
		foreach (var track in data)
		{
			if (name == track.Title)
			{
				DisplayAlert("Уведомление", track.Title + " lat:" +track.Latitude.ToString()
				+ " lon:" + track.Longitude.ToString(), "ОК");
				// установка контекста данных
				this.BindingContext = new CityViewModel
				{
					Title = track.Title,
					Latitude = track.Latitude,
					Longitude = track.Longitude,
					Time = "",
					Temperature = 0,
					Windspeed = 0,
				};
				
			}			
		}
		
	}




}

