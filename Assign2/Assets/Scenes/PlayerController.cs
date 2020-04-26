using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	Rigidbody2D rb;
	private int count;
	private float movement = 0f;
	public float spead = 10f;
	public Text countText;
	public Text AlertText;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		count = 0;
		countText.text = "Count:" + count.ToString();
		AlertText.text = "";
		if (count > 20)
		{
			AlertText.text = "You win!";
		}

	}
	void Update()
	{
		movement = Input.GetAxis("Horizontal") * spead;
	}

	private void FixedUpdate()
	{
		Vector2 velocity = rb.velocity;
		velocity.x = movement;
		rb.velocity = velocity;
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Cherry"))
		{
			Destroy(other.gameObject);
			count = count + 1;
			countText.text = "Count:" + count.ToString();
			if (count > 20)
			{
				AlertText.text = "You win!";
				Destroy(gameObject);
			}
		}
		if (other.gameObject.CompareTag("bush"))
        {
           
                AlertText.text = "Game over!";
                Destroy(gameObject);
           
        }
        
		if (other.gameObject.CompareTag("rock"))
        {
            
			Destroy(other.gameObject);
            count = count - 1;
            countText.text = "Count:" + count.ToString();

        }
        


	}
}
