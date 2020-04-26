using UnityEngine;

public class CarSpawner : MonoBehaviour {

	public float spawnDelay = .3f;

	public GameObject car;

	public Transform[] spawnPoints;

	float nextTimeToSpawn = 0f;

	void Update ()
	{
		if (nextTimeToSpawn <= Time.time)
		{
			SpawnCar();
			nextTimeToSpawn = Time.time + spawnDelay;
		}
	}

	void SpawnCar ()
	{
		int randomIndex1 = Random.Range(0, spawnPoints.Length);
		Transform spawnPoint1 = spawnPoints[randomIndex1];
		Instantiate(car, spawnPoint1.position, spawnPoint1.rotation);

		int randomIndex2 = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint2 = spawnPoints[randomIndex2];
        Instantiate(car, spawnPoint2.position, spawnPoint2.rotation);

		int randomIndex3 = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint3 = spawnPoints[randomIndex3];
        Instantiate(car, spawnPoint3.position, spawnPoint3.rotation);


	}

}
