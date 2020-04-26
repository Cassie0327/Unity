using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExplosionController:MonoBehaviour
{
	public float time = 0.5f;
    

	public AudioClip boom;
    private AudioSource source;

    
    void Start()
    {
        Destroy(gameObject, time);
		source.PlayOneShot(boom, 0.2F);


    }

    private void Awake()
    {
        source = GetComponent<AudioSource>();

    }


	private void OnTriggerEnter2D(Collider2D collision)
	{


		if (collision.gameObject.CompareTag("Player"))
		{


		}
		else
		{
			if(collision.gameObject.CompareTag("win"))
				{}
         
			else{
            
				if (!collision.gameObject.isStatic)
				{


					Destroy(collision.gameObject);
				}

			}
		}
	}
}
