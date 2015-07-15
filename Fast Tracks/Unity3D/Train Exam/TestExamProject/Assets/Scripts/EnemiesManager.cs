using UnityEngine;
using System.Collections;

public class EnemiesManager : MonoBehaviour 
{
    float nextEnemySpawnMin = 0.5f; 
    float nextEnemySpawnMax = 1f;
    float nextEnemySpawn = 0f;

    float nextEnemyXCoordinateMin = 0.88f;
    float nextEnemyXCoordinateMax = 7.77f;
    Vector3 nextEnemyCoordinates = new Vector3(3f, 4.33f, 197f);
    GameObject[] pool;

	// Use this for initialization
	void Start () 
    {
        PopulatePool();
	}

    // Update is called once per frame
    void Update()
    {
        if (nextEnemySpawn > 0f)
        {
            nextEnemySpawn -= Time.deltaTime;
        }
        else
        {
            SpawnNextEnemy();
        }
	}

    void PopulatePool()
    {
        int count = transform.childCount;
        pool = new GameObject[count];

        for (int i = 0; i < count; i++)
        {
            pool[i] = transform.GetChild(i).gameObject;
        }
    }

    GameObject GetNextFreeItemFromPool()
    {
        int count = pool.Length;
        for (int i = 0; i < count; i++)
        {
            if (!pool[i].activeSelf)
            {
                GameObject item = pool[i];
                item.SetActive(true);
                item.transform.localScale = Vector3.one;
                return item;
            }
        }

        Debug.Log("No free items in the pool");
        return null;
    }

    void SpawnNextEnemy()
    {
        GameObject nextEnemyGO = GetNextFreeItemFromPool();

        if (nextEnemyGO == null)
        {
            return;
        }

        nextEnemyCoordinates.x = Random.Range(nextEnemyXCoordinateMin, nextEnemyXCoordinateMax);
        nextEnemySpawn = Random.Range(nextEnemySpawnMin, nextEnemySpawnMax);
        nextEnemyGO.SetActive(true);
        nextEnemyGO.transform.position = nextEnemyCoordinates;
    }
}
