using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WindTextScript : MonoBehaviour {
	public bool knowsWeather;
	private WeatherAPI weather;
	Text windText;
	// Use this for initialization
	// Use this for initialization
	void Start () {
		knowsWeather = false;
		//find the text of this component
		windText = GameObject.Find("WindText").GetComponent<Text>();
		//gets the weather from the API
		weather = WeatherAPI.FindObjectOfType<WeatherAPI>();
	}
	// Update is called once per frame
	void Update () {
		if (!knowsWeather && weather.wind != 0) 
		{
			windText.text = weather.wind.ToString() + "m/s wind speed";
			knowsWeather = true;
		}
	}
}
