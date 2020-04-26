using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
	public GameObject platformpre1;
	public GameObject platformpre2;
	public GameObject platformpre3;
	public int numberOfPlatforms1=1000;
	public float levelWidth;
	public float minY;
	public float maxY;
	private int j = 3;
	private int m = 7;
    // Start is called before the first frame update
    void Start()
    {
		Vector3 spawnPosition = new Vector3();
		for (int i = 0; i < numberOfPlatforms1;i++)
		{
			spawnPosition.y += Random.Range(minY, maxY);
			spawnPosition.x = Random.Range(-levelWidth, levelWidth);
			Instantiate(platformpre1, spawnPosition, Quaternion.identity);
			while(i>j){
				spawnPosition.y += Random.Range(minY, maxY);
                spawnPosition.x = Random.Range(-levelWidth, levelWidth);
                Instantiate(platformpre2, spawnPosition, Quaternion.identity);
				j = j + 3;
			}
            while(i>m)
			{spawnPosition.y += Random.Range(minY, maxY);
                spawnPosition.x = Random.Range(-levelWidth, levelWidth);
                Instantiate(platformpre3, spawnPosition, Quaternion.identity);
                m = m + 7;
				
			}
		}
        
    }

}
