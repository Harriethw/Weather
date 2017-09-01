using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindComponent : MonoBehaviour {

		// To use:
		// 1. Create an empty game object
		// Add a Collider2D to the empty object. I used a standard Box Collider 2D, as a trigger, to create an isolated square that applies "wind"
		// 3. Add this WindComponent to the empty object, then adjust the Force (Vector2). You can adjust this in the editor or in the script, as it is a public property
		// Note: Only works on game objects that have the Rigid Body 2D and Collider 2D components

		// Directional force applied to objects that enter this object's Collider 2D boundaries
		public Vector3 Force = Vector3.zero;

		// Internal list that tracks objects that enter this object's "zone"
		private List<Collider> objects = new List<Collider>();

		private WeatherAPI weather;
	private float windspeed;

		void Start (){
		weather = WeatherAPI.FindObjectOfType<WeatherAPI>();
		windspeed = weather.wind;
		Force.x = windspeed;
		Debug.Log (windspeed);
		}
		void FixedUpdate()
		{

		windspeed = weather.wind;
		Force.x = windspeed;

			// For every object being tracked
			for(int i = 0; i < objects.Count; i++)
			{



				// Get the rigid body for the object.
				Rigidbody body = objects[i].attachedRigidbody;

				// Apply the force
				body.AddForce(Force);
			}
		}

	void OnTriggerEnter(Collider other)
		{
			objects.Add(other);
		}

		void OnTriggerExit(Collider other)
		{
			objects.Remove(other);
		}
	}

