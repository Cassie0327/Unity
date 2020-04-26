using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform target;
	private Vector3 currentVelocity;
    // Start is called before the first frame update

    // Update is called once per frame
    void LateUpdate()
    {
		if(target.position.y>transform.position.y)
		{
			Vector3 newPos = new Vector3(transform.position.x, target.position.y, transform.position.z);
			transform.position = newPos;
		}
        
    }
}
