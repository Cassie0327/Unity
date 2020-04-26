using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class shotController : Shotplayer
{   public float spead2;
	private void Start()
	{
		Vector3 fw= transform.TransformDirection(transform.forward);
		GetComponent<Rigidbody>().AddForce(fw * 2000);
        countText.text = "Count:" + count.ToString();
        AlertText.text = "";
        if (count > 6)
        {
            AlertText.text = "You win!";
        }
	}

	void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick up"))
        {
            other.gameObject.SetActive(false);
			Destroy(gameObject);
            count = count + 1;
            countText.text = "Count:" + count.ToString();
            if (count > 5)
            {
                AlertText.text = "You win!";
            }
        }
		if(other.gameObject.CompareTag("wall"))
		{
			Destroy(gameObject);
		}
		if (other.gameObject.CompareTag("bigger"))
        {
            other.gameObject.SetActive(false);
			Destroy(gameObject);
            gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
    }



}
