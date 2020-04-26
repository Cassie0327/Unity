using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shotplayer : MonoBehaviour
{
	private bool onground;

	public float nextFire;
	public float fireRate;
	public GameObject shot;
	public Transform shotSqawn;

	public float speed1;
    public Text countText;
    public Text AlertText;

    private Rigidbody rb;
    public int count;
    void Start()
    {
		onground = true;
        rb = GetComponent<Rigidbody>();
        count = 0;
        countText.text = "Count:" + count.ToString();
        AlertText.text = "";
        if (count > 6)
        {
            AlertText.text = "You win!";
        }

    }
	 void Update()
	{
		
		if (Input.GetKeyDown(KeyCode.Q)&&Time.time>nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, transform.position, transform.rotation);
		}
		if (Input.GetKeyDown(KeyCode.Space))
        {
			rb.velocity = new Vector3(0f, 5f, 0f);
			onground = false;

        }


	}

	void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed1);
		      
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            countText.text = "Count:" + count.ToString();
            if (count > 6)
            {
                AlertText.text = "You win!";
				Destroy(gameObject);
            }
        }
        if(other.gameObject.CompareTag("bigger"))
		{
			other.gameObject.SetActive(false);
			gameObject.transform.localScale = gameObject.transform.localScale +new Vector3(0.5f,0.5f,0.5f);
		}
		if (other.gameObject.CompareTag("wall"))
        {
			AlertText.text = "You collide wall!";
			count = count - 1;
			countText.text = "Count:" + count.ToString();

        }
		if (other.gameObject.CompareTag("ob"))
        {
			AlertText.text = "The game is over!";
			Destroy(gameObject);
        }
        if(other.gameObject.CompareTag("ground"))
		{
			onground = true;
		}
	
    }
}
