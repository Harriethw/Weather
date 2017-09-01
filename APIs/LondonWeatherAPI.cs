using UnityEngine;
using System.Collections;
using SimpleJSON;
public class LondonWeatherAPI : MonoBehaviour {
	//public string url = "http://api.openweathermap.org/data/2.5/weather?lat=43.667027&lon=-79.424759&APPID=391013b34d8368540317a2dd0dd2536d";
	public string city;
	public string weatherDescription;
	public float temp;
	public float temp_min;
	public float temp_max;
	public float rain;
	public float wind;
	public float clouds;

	public string currentIP;
	public string currentCountry;
	public string currentCity;
	public string APPID = "&APPID=391013b34d8368540317a2dd0dd2536d";

	private LondonSkyAPI sky;
	private LondonChimeController chimes;

	void Awake (){

		sky = LondonSkyAPI.FindObjectOfType<LondonSkyAPI>();
		chimes = LondonChimeController.FindObjectOfType<LondonChimeController>();
	}


	// Use this for initialization
	IEnumerator Start () {

		//go to the api
		WWW request = new WWW("http://api.openweathermap.org/data/2.5/weather?q=London,uk" + APPID);
		yield return request;
		if (request.error == null || request.error == "") 
		{
			setWeatherAttributes(request.text);
		} 
		else 
		{
			Debug.Log("Error: " + request.error);
		}

	}

	void setWeatherAttributes(string jsonString) {
		var weatherJson = JSON.Parse(jsonString);
		city = weatherJson["name"].Value;
		weatherDescription = weatherJson["weather"][0]["description"].Value;
		temp = weatherJson["main"]["temp"].AsFloat;
		temp_min = weatherJson["main"]["temp_min"].AsFloat;
		temp_max = weatherJson["main"]["temp_max"].AsFloat;
		rain = weatherJson["rain"]["3h"].AsFloat;
		clouds = weatherJson["clouds"]["all"].AsInt;
		wind = weatherJson["wind"]["speed"].AsFloat;

		sky.SkyChoice ();
		chimes.ChimeChoice();
	}

}