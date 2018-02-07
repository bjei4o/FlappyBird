using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //trzeba dopisać, żeby można było zarządzać scenami (w update)
using UnityEngine.UI; // dzieki temu mozemy zadeklarowac nowy obiekt klasy Text, potrzebny do wyswietlania komunitaków w grze (wynik)


public class GameController : MonoBehaviour {

	public static GameController instance; //dzieki static można z każdego skryptu korzystać z tej zmiennej
	public bool gameOver = false; // flaga do sprawdzania czy gra jeszcze trwa
	public GameObject GameOverText;
	public float scrollSpeed = -1.5f;
	public int score = 0;
	public Text scoreText; //Tworzymy obiekt klasy Text

	// Use this for initialization
	void Awake () {
		if (instance == null) {
			instance = this;
		} 
		else if (instance != this) 
		{
			Destroy (gameObject);	
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Escape)) 
		{  
			SceneManager.LoadScene ("Menu");
		}

		if(gameOver == true && Input.GetMouseButtonDown(0))
		{
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex); //przeładowanie gry od poczatku sceny
		}
	}

	public void BirdScored() //funkcja zliczjąca punkty
	{
		if (gameOver) //sprawdzenie czy gra jest dalej odpalona. Jak nie to wychodzi z funkcji zliczania punktów
		{
			return; 
		}
		score++;
		scoreText.text = "Score: " + score.ToString (); //Przypisujemy text wyniku rozgrywki, do obiektu klasy Text. Trzeba zrzutować "score" na Stringa, bo by nie wyswietlilo 
	}


	public void BirdDied()
	{
		
		GameOverText.SetActive (true);
		gameOver = true;
	}


}
