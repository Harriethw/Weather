using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChimeController : MonoBehaviour {

	public GameObject Rain3D, Cloudy3D, Sun3D, Snow3D;
	private WeatherAPI weather;
	private string skyWeather;

	// Use this for initialization
	void Start () {
		weather = WeatherAPI.FindObjectOfType<WeatherAPI>();

		Debug.Log ("found chime API"); 


	}

	void Update (){


	}

	public void ChimeChoice (){
		
		string skyWeather = weather.weatherDescription;

		if (skyWeather == "Clear" || skyWeather == "clear sky" || skyWeather == "scattered clouds" || skyWeather == "few clouds") {
			Instantiate (Sun3D, gameObject.transform.position, Quaternion.identity); 
			Debug.Log ("Clear Chime");
		} else if (skyWeather == "Clouds" || skyWeather == "overcast clouds" || skyWeather == "scattered clouds") {
			Instantiate (Cloudy3D, gameObject.transform.position, Quaternion.identity); 
			Debug.Log ("Cloudy Chime");
		} else if (skyWeather == "Rain" || skyWeather == "Thunderstorm" || 
			skyWeather == "mist" || skyWeather == "shower rain" || skyWeather == "light intensity rain" || skyWeather == "light thunderstorm" 
			|| skyWeather == "thunderstorm with light rain" || skyWeather == "thunderstorm with rain" || skyWeather == "thunderstorm with heavy rain"
			|| skyWeather == "drizzle"|| skyWeather == "light intensity drizzle"|| skyWeather == "moderate rain"
			|| skyWeather == "heavy intensity rain"|| skyWeather == "freezing rain"|| skyWeather == "moderate rain"
			|| skyWeather == "light intensity shower rain" || skyWeather == "light rain") {
			Instantiate (Rain3D, gameObject.transform.position, Quaternion.identity); 
			Debug.Log ("precipitation chime");
		} else if (skyWeather == "Snow" || skyWeather == "hail"|| skyWeather == "hail"|| skyWeather == "hail"
			|| skyWeather == "light snow" || skyWeather == "heavy snow"|| skyWeather == "sleet"|| skyWeather == "rain and snow"
			|| skyWeather == "light snow" || skyWeather == "heavy shower snow"|| skyWeather == "light shower snow"|| skyWeather == "shower snow") {
			Instantiate (Snow3D, gameObject.transform.position, Quaternion.identity); 
			Debug.Log ("Snow Chime");
		}
		else {
			Instantiate (Cloudy3D, gameObject.transform.position, Quaternion.identity); 
			Debug.Log ("Not found Chime");
		}

	}
}
