using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour {
	private BoxCollider2D groundCollider; //utworzenie obiektu klasy Collider, reprezentującego ColliderBox podłoża
	private float groundHorizontalLenght; //utworzenie zmiennej która będzie przechowywać długość podłoża

	// Use this for initialization
	void Start () {
		groundCollider = GetComponent<BoxCollider2D> (); // przypisanie do obiektu klasy ColliderBox Collidera z obiektu, pod który skrypt został podpięty
		groundHorizontalLenght = groundCollider.size.x; //przypisanie wartości x (długości) Collidera podłoża 
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (transform.position.x < -groundHorizontalLenght) //tło zaczyna ze współrzędnymi (0,0), a gdy przesuwa sie w lewo robi sie ujemna wartośc na "x". Gdy bedzie mniejsza wartość niż długość "-tła", to warunek jest spełniony  
		{
			RepositionBackground (); 
		}
	}

	private void RepositionBackground()
	{
		Vector2 grundOffset = new Vector2 (groundHorizontalLenght * 2f, 0); //utworzenie wektora (długość tła*2, 0) <- gdyby było *1 to by tylko zakryło tło po prawej, zamiast ustawić się na prawo od niego
		transform.position = (Vector2)transform.position + grundOffset; //przesunięcie tła z obecnej pozycji na pozycję oddaloną o 2 długości tła (na koniec tła po prawej)
	}
}
