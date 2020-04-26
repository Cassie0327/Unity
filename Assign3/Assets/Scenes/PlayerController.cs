using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	public AudioClip Vcoin;
    public AudioClip Vobstacle;
	public AudioClip background;
	public AudioClip Win;
    public AudioClip Lose;
   
    private AudioSource source;
	Rigidbody2D rb;
	private int count;
	private float movement = 0f;
	public float spead = 10f;
	public Text countText;
	public Text AlertText;

	private void Awake()
	{
		source = GetComponent<AudioSource>();
	}

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		count = 0;
		countText.text = "Count:" + count.ToString();
		AlertText.text = "";
		source.PlayOneShot(background, 0.2F);


	}
	void Update()
	{
		movement = Input.GetAxis("Horizontal") * spead;
		if (count > 10)
        {
            AlertText.text = "You win!";
			source.Stop();

        }
     

       
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
			source.PlayOneShot(Vcoin, 1F);
			if (count > 10)
			{
               
				AlertText.text = "You win!";
				source.Stop();
				source.PlayOneShot(Win, 1F);
				Time.timeScale = 0;             


			}
		}
		if (other.gameObject.CompareTag("bush"))
        {
                AlertText.text = "Game over!";
			    source.Stop();
			    source.PlayOneShot(Lose, 1F);
			Time.timeScale = 0;			    

           
        }
        
		if (other.gameObject.CompareTag("rock"))
        {
            
			Destroy(other.gameObject);
            count = count - 1;
            countText.text = "Count:" + count.ToString();
			source.PlayOneShot(Vobstacle, 1F);

        }
       
        


	}
}
