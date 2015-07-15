using UnityEngine;
using System.Collections;

public class CoinsManager : MonoBehaviour 
{
    float nextCoinSpawnMin = 0.1f;
    float nextCoinSpawnMax = 0.5f;
    float nextCoinSpawn = 0f;

    float nextCoinXCoordinateMin = 0.88f;
    float nextCoinXCoordinateMax = 7.77f;
    Vector3 nextCoinCoordinates = new Vector3(0f, 4.33f, 197f);
    GameObject[] pool;

    // Use this for initialization
    void Start()
    {
        PopulatePool();
    }

    // Update is called once per frame
    void Update()
    {
        if (nextCoinSpawn > 0f)
        {
            nextCoinSpawn -= Time.deltaTime;
        }
        else
        {
            SpawnNextCoin();
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
                item.transform.localScale = new Vector3(0.5f, 0.02f, 0.5f);
                return item;
            }
        }

        Debug.Log("No free items in the pool");
        return null;
    }

    void SpawnNextCoin()
    {
        GameObject nextCoinGO = GetNextFreeItemFromPool();

        if (nextCoinGO == null)
        {
            return;
        }

        nextCoinCoordinates.x = Random.Range(nextCoinXCoordinateMin, nextCoinXCoordinateMax);
        nextCoinSpawn = Random.Range(nextCoinSpawnMin, nextCoinSpawnMax);
        nextCoinGO.SetActive(true);
        nextCoinGO.transform.position = nextCoinCoordinates;
    }
}
