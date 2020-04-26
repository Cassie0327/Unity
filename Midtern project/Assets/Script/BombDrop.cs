using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BombDrop : MonoBehaviour
{
	public GameObject Bomb1;
	public GameObject Bomb2;
	public Text Life;
	public  int lifecount = 3;
	public string winname;

	public AudioClip bgm;
    private AudioSource source;

	public GameObject StarEffect;
    
   
	private bool isPick = false;
	public void Start()
	{
		source.PlayOneShot(bgm, 0.2F);
	}

	private void Awake()
    {
        source = GetComponent<AudioSource>();

    }

	void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("cherry"))
        {
            Destroy(other.gameObject);
            isPick = true;
			lifecount = lifecount+1;
			Life.text = "X" + lifecount.ToString();
			Instantiate(StarEffect, transform.position, transform.rotation);
			         
        }
		if(other.gameObject.CompareTag("win"))
		{
			SceneManager.LoadScene(winname, LoadSceneMode.Single);

		}

       
    }
  
  

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("worm"))
        {
           
			lifecount = lifecount - 1;  
			Life.text = "X" + lifecount.ToString();
            if(lifecount<0)
			{
				SceneManager.LoadScene("scene_lose", LoadSceneMode.Single);
			}

        }
		
	}
	void Update()
    {
		
		if(isPick==true)
		{
			Invoke("change", 10f);
		}
		if(Input.GetKeyDown(KeyCode.Space))
		{
			
			if (isPick ==true)
			{
				
				Vector2 pos = transform.position;
                Instantiate(Bomb1, pos, Quaternion.identity);

			}
			else
			{
				Vector2 pos = transform.position;
				Instantiate(Bomb2, pos, Quaternion.identity);
			}

		}
		if (lifecount < 0)
        {
			
            Destroy(gameObject);

        }
        
    }
    void change()
	{
		isPick = false;
	}

}
