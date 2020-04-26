using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenade : MonoBehaviour
{
	public float delay = 3f;
	public float radius = 5f;
	public float force = 700f;

	public GameObject explosionEffect;
	float coutdown;
	bool hasExploded = false;
    // Start is called before the first frame update
    void Start()
    {
		coutdown = delay;
        
    }

    // Update is called once per frame
    void Update()
    {
		coutdown -= Time.deltaTime;
        if(coutdown<=0f&&!hasExploded)
		{
			Explode();
			hasExploded = true;
		}
        
    }
    void Explode()
	{
		Instantiate(explosionEffect, transform.position, transform.rotation);
		Collider[] collidersToDestroy = Physics.OverlapSphere(transform.position, radius);
		foreach(Collider nearbyObject in collidersToDestroy)
		{
			Destructible dest = nearbyObject.GetComponent<Destructible>();
			if(dest!=null)
			{
				dest.Destroy();
			}
		}
		Collider[] colliderToMove = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearbyObject in colliderToMove)
        {
            Rigidbody rb= nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
				rb.AddExplosionForce(force, transform.position, radius);
            }
        }
		Destroy(gameObject);
			
	}
}
