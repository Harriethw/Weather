using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class ForecastScript : MonoBehaviour {
	public bool knowsWeather;
	private WeatherAPI weather;
	Text forecastText;
	// Use this for initialization
	// Use this for initialization
	void Start () {
		knowsWeather = false;
		//find the text of this component
		forecastText = GameObject.Find("Forecast").GetComponent<Text>();
		//gets the weather from the API
		weather = WeatherAPI.FindObjectOfType<WeatherAPI>();
	}
	// Update is called once per frame
	void Update () {
		if (!knowsWeather && weather.temp != 0) 
		{
			forecastText.text = weather.weatherDescription;
			knowsWeather = true;
		}
	}
}
