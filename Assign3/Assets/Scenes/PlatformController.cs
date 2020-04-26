using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
	private float jumpforce = 10f;
	public AudioClip Break;   
    private AudioSource source;
	int i = 0;
    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

	void OnCollisionEnter2D(Collision2D collision)
	{
		Rigidbody2D rb2 = collision.collider.GetComponent<Rigidbody2D>();
		if (rb2 != null)
		{

			Vector2 velocity = rb2.velocity;
			velocity.y = jumpforce;
			rb2.velocity = velocity;

		}
       
		if (collision.gameObject.CompareTag("Player"))
        {
            i++;
            if (i > 2)
            {
				source.PlayOneShot(Break, 1F);
                Destroy(gameObject);
                i = 0;


            }
        }

	}


}
