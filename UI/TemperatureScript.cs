using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class TemperatureScript : MonoBehaviour {
	public bool knowsWeather;
	private WeatherAPI weather;
	Text tempText;
	private float kelvinTemp;
	private float celciusTemp;
	private float calculationtemp = 273.15f;

	// Use this for initialization
	void Start () {
		knowsWeather = false;
		//find the text of this component
		tempText = GameObject.Find("Temperature").GetComponent<Text>();
		//gets the weather from the API
		weather = WeatherAPI.FindObjectOfType<WeatherAPI>();
	}
	// Update is called once per frame
	void Update () {
		if (!knowsWeather && weather.temp != 0) 
		{
			//tempText.text = weather.temp.ToString() + " kelvin";
			kelvinTemp = weather.temp;
			celciusTemp = kelvinTemp - calculationtemp;
			tempText.text = celciusTemp.ToString ("F2") + " Celcius";
			knowsWeather = true;
		}
	}
}