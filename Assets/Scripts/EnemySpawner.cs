using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

	public GameObject Spawnportal;

	public GameObject[] Enemy;

	public Transform[] SpawnPoint;

	public float TimeBetweenSpawnValue;
	public float TimeBetweenSpawn;

	public int enemyCount;
	public int currentenemycount;

	public List<GameObject> EnemiesSpawned;

	public AudioSource Clip;
	GameObject portal;
	GameManager GM;
	// Start is called before the first frame update
	void Start()
	{
		GM = GM = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
		currentenemycount = enemyCount;
		TimeBetweenSpawn = 0;
	}

	// Update is called once per frame
	void Update()
	{
		if(GM.Player == null)
		{
			if(portal != null)
			{
				Destroy(portal);
				Destroy(gameObject);
			}
		}
		EnemiesSpawned.RemoveAll(item => item == null);
		if (currentenemycount != 0)
		{
			if (TimeBetweenSpawn <= 0)
			{
				StartCoroutine(Spawnenemy());
				TimeBetweenSpawn = TimeBetweenSpawnValue;
			}
			else
			{
				TimeBetweenSpawn -= Time.deltaTime;
			}
		}
	
		if(currentenemycount == 0)
		{
			if (EnemiesSpawned.Count == 0)
			{
				if(TimeBetweenSpawnValue > 1f)
				{
					Debug.Log("Here");
					TimeBetweenSpawnValue = TimeBetweenSpawnValue - 1;
					TimeBetweenSpawn = TimeBetweenSpawnValue;
				}
				else
				{
					TimeBetweenSpawn = TimeBetweenSpawnValue;
				}

				enemyCount = enemyCount + 2;
				currentenemycount = enemyCount;
			}

		}
		
	}

	IEnumerator Spawnenemy()
	{

	
		int Posnum = Random.Range(0, transform.childCount - 1);
		int EnemyNum = Random.Range(0, 3);
		Vector3 pos = new Vector3(SpawnPoint[Posnum].transform.position.x, SpawnPoint[Posnum].transform.position.y, 0f);
		GameObject P = Instantiate(Spawnportal, pos, Quaternion.identity);
		portal = P;
		yield return new WaitForSeconds(2f);
		Destroy(P);
		Clip.Play();
		GameObject G = Instantiate(Enemy[EnemyNum], pos, Quaternion.identity);
		EnemiesSpawned.Add(G);
		currentenemycount--;
	}
}
