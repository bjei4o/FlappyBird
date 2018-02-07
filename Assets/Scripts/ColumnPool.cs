using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour {

	public int columnPoolSize = 5; // ilosc kolumn które będa utworzone
	public GameObject columnPrefab;
	public float spawnRate = 4; //czestotliwość generacji kolumn
	public float columnMin = 1f; //minimalna wysokosc kolummn
	public float columnMax = 3f; //maksymalna wysokość kolumn

	private GameObject[] columns; //tablica do przechowywania utworzonych kolumn
	private Vector2 objectPoolPosition = new Vector2 (-15f, -25f); //pozycja kolumn
	private float timeSinceLastSpawn; //zmienna przechowująca informację kiedy ostatnio utworzono kolumnę
	private float spawnXPosition = 11f; //miejsce pojawienia się kolumny <- ustawione minimalnie poza ekranem
	private int currentColumn = 0; //zmienna 

	// Use this for initialization
	void Start () 
	{
		timeSinceLastSpawn = 4; //inicjalizacjana poziomie 4s, żeby od razu została ustawiona pierwsza kolumna
		columns = new GameObject[columnPoolSize]; //inicjalizacja tablicy przechowującej kolumny
		for (int i = 0; i < columnPoolSize; i++) 
		{	//instiantiate robi klony danego obiektu. Tutaj kopiuje prefab kolumn
			columns [i] = (GameObject)Instantiate (columnPrefab, objectPoolPosition, Quaternion.identity); 
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		timeSinceLastSpawn += Time.deltaTime; //zmienna inkrementowana o 1 co sekunde (licznik)

		//sprawdzenie warunku czy gra jeszcze trwa i czy minal odpowiedni czas, wiekszy od zadanego czasu swawnu kolumn
		if (GameController.instance.gameOver == false && timeSinceLastSpawn >= spawnRate) 
		{
			timeSinceLastSpawn = 0; //zerowanie licznika, by za określony czas można było sprawdzić warunek powyżej
			float spawnYPosition = Random.Range (columnMin, columnMax); //losowanie wartości dla położenia kolumn na osi Y
			columns [currentColumn].transform.position = new Vector2 (spawnXPosition, spawnYPosition); //ustawienie kolumny wg wylosowanego Y
			currentColumn++; //przejscie do kolejnej pary kolumn
			if (currentColumn >= columnPoolSize) 
			{	//powrót do pierwszej kolumny
				currentColumn = 0;
			}
		}
	}
}
//W tym projekcie korzystamy z 5 kolumn i je przestawiamy co ookreślony czas (4s), zamiast tworzyć nowe i potem je niszczyć.
//W ten sposób oszczędzamy zasoby komputera - gra działa szybciej!