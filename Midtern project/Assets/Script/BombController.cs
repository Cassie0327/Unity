using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
	public float time = 1f;
	public GameObject explosionPrefabs1;

    // Start is called before the first frame update
    void Start()
    {
	Destroy(gameObject, time);
        
    }


	private void OnDestroy()
	{
		
		 Instantiate(explosionPrefabs1, transform.position, Quaternion.identity); 
	}
}
