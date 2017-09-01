using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class CityScript : MonoBehaviour {
	public bool knowsWeather;
	private WeatherAPI weather;
	Text cityText;
	// Use this for initialization
	// Use this for initialization
	void Start () {
		knowsWeather = false;
		//find the text of this component
		cityText = GameObject.Find("City").GetComponent<Text>();
		//gets the weather from the API
		weather = WeatherAPI.FindObjectOfType<WeatherAPI>();
	}
	// Update is called once per frame
	void Update () {
		if (!knowsWeather && weather.temp != 0) 
		{
			cityText.text = weather.city;
			knowsWeather = true;
		}
	}
}