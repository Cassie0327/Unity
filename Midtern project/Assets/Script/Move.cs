using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Move : MonoBehaviour
{
	public float spead = 16f;


	private void FixedUpdate()
	{
		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");

		GetComponent<Rigidbody2D>().velocity = new Vector2(h,v)*spead;
        
		GetComponent<Animator>().SetInteger("X", (int)h);
		GetComponent<Animator>().SetInteger("Y", (int)v);
        


	}

   


    
    

    
}
