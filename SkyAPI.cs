using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyAPI : MonoBehaviour {

	public Sprite clear , cloudy, precip, snow;
	private WeatherAPI weather;
	public string skyWeather;

	// Use this for initialization
	void Start () {
		//get WeatherAPI
		weather = WeatherAPI.FindObjectOfType<WeatherAPI>();

		Debug.Log ("found sky API"); 


	}

	public void SkyChoice (){
		//get weather forecast from weather API
		string skyWeather = weather.weatherDescription.ToString();
		Debug.Log ("skyweather is" + skyWeather);

		if (skyWeather == "Clear" ||  skyWeather == "clear sky" || skyWeather == "scattered clouds" || skyWeather == "few clouds") {
			gameObject.GetComponent<SpriteRenderer>().sprite = clear;
			Debug.Log ("Clear");
		} else if (skyWeather == "Clouds" ||  skyWeather == "overcast clouds" || skyWeather == "scattered clouds" || skyWeather == "broken clouds") {
			gameObject.GetComponent<SpriteRenderer>().sprite = cloudy;
			//Debug.Log ("Cloudy");
		} else if (skyWeather == "Rain" || skyWeather == "Thunderstorm" || 
			skyWeather == "mist" || skyWeather == "shower rain" || skyWeather == "light intensity rain" || skyWeather == "light thunderstorm" 
			|| skyWeather == "thunderstorm with light rain" || skyWeather == "thunderstorm with rain" || skyWeather == "thunderstorm with heavy rain"
			|| skyWeather == "drizzle"|| skyWeather == "light intensity drizzle"|| skyWeather == "moderate rain"
			|| skyWeather == "heavy intensity rain"|| skyWeather == "freezing rain"|| skyWeather == "moderate rain"
			|| skyWeather == "light intensity shower rain" || skyWeather == "light rain"
		) {
			gameObject.GetComponent<SpriteRenderer>().sprite = precip;
			//Debug.Log ("precipitation");
		} else if (skyWeather == "Snow" || skyWeather == "hail"|| skyWeather == "hail"|| skyWeather == "hail"
			|| skyWeather == "light snow" || skyWeather == "heavy snow"|| skyWeather == "sleet"|| skyWeather == "rain and snow"
			|| skyWeather == "light snow" || skyWeather == "heavy shower snow"|| skyWeather == "light shower snow"|| skyWeather == "shower snow") {
			gameObject.GetComponent<SpriteRenderer>().sprite = snow;
		}
		else {
			gameObject.GetComponent<SpriteRenderer>().sprite = cloudy;
			Debug.Log ("weather type not found for sky");
		}


	}

	// Update is called once per frame
	void Update(){

		//SkyChoice ();
		

	}
}
