using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

	private bool isDead = false;
	Rigidbody2D rb2d;
	public float upForce = 200f;
	private Animator anim; //obiekt klasy Animator dodany, żeby można było operować na animacji dodanej w unity

	// Use this for initialization
	void Start () 
	{
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> (); //dodane, żeby dało się operować na animacjach poniżej
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (isDead == false)
		{
			if (Input.GetMouseButtonDown (0)) {
				rb2d.velocity = Vector2.zero; //skrót od new Vector2.zero.zero
				rb2d.AddForce (new Vector2 (0, upForce));
				anim.SetTrigger ("Flapp"); //zmienia wczesniej ustawioną animację "Flapp" na true
			}
		}
	}


	void OnCollisionEnter2D ()
	{
		rb2d.velocity = Vector2.zero; //upewniamy sie ze po opadnieciu na ziemie ptaka, nie bedzie sie przemieszczac/odbijac od ziemi
		isDead = true;
		anim.SetTrigger ("Die"); //zmienia wczesniej ustawioną animację o nazwie "Die" na true
		GameController.instance.BirdDied();
	}
}
