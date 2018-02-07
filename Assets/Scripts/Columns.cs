using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Columns : MonoBehaviour {

	private void OnTriggerEnter2D(Collider2D other) // funkcja pobierająca informacje co weszło w obręb Collidera
	{
		if (other.GetComponent<Bird> () != null) //sprawdzenie czy  rzeczą która weszła w obręb Collidera jest obiekt Bird 
		{
			GameController.instance.BirdScored (); //odwołanie się do funkcji z skryptu "GameController" o nazwie BirdScored
		}
	}
}
