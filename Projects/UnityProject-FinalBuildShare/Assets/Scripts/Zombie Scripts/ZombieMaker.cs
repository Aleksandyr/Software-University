// Author: Atoro 
using UnityEngine;
using System.Collections;
 
public class ZombieMaker : MonoBehaviour
{
	// Public 
	public bool enable;
	public int count;
    public int score;

	// Private 
	float createNewRate;
	float createPointHeight;
	float maxNum;
	Terrain terr;
	float terrSizeX, terrSizeY, terrSizeZ;
	GameObject zombie; 

	// Use this for initialization
	void Start ()
	{
			// Public 
			enable = true; 
			count = CompZombieCount (); 

			// Private 
			terr = Terrain.activeTerrain; 
			terrSizeX = terr.terrainData.size.x; 
			terrSizeY = terr.terrainData.size.y; 
			terrSizeZ = terr.terrainData.size.z; 
			zombie = (GameObject)Resources.Load ("Zombie"); 
			createNewRate = CompCreateNewRate (terrSizeX, terrSizeZ); 
			createPointHeight = CompCreatePointHeight (terrSizeY); 
			maxNum = CompZombieMaxNum (terrSizeX, terrSizeZ); 
	}
	
	// Update is called once per frame
	void Update ()
	{
			// Computer how many Zombies there are 
			count = CompZombieCount (); 

			if (enable) { // Do the things below only if the ZombieMaker is ON 
					if (Random.value < createNewRate && count < maxNum) { // To create or not new Zombie 
							Instantiate (zombie); 
							float x = Random.Range (0.0f, terrSizeX); 
							float y = terrSizeY + createPointHeight; 
							float z = Random.Range (0.0f, terrSizeZ); 
							zombie.transform.position = new Vector3 (x, y, z); 
					}
			}
	}

	// Compute createNewRate value 
	float CompCreateNewRate (float x_, float z_)
	{
			int c = 1000000; 
			float ret = x_ * z_ / c; 
			if (ret < 0.001) {
					ret = 0.001f; 
			} else if (ret > 0.05) {
					ret = 0.05f; 
			}
			//Debug.Log ("CNR: " + ret); 
			return ret; 
	}

	// Compute createPointHeight value 
	float CompCreatePointHeight (float y_)
	{
			float ret = y_ + 10; 
			//Debug.Log ("CPH: " + ret); 
			return ret;  
	} 

	// Compute zombieMaxNum value 
	float CompZombieMaxNum (float x_, float z_)
	{
			int c = 1000; 
			float ret = x_ * z_ / c; 
			if (ret < 1) {
					ret = 1;
			} else if (ret > 300) {
					ret = 300;
			}
			//Debug.Log ("ZMN: " + ret); 
			return ret;  
	}

	// Compute zombieCount value 
	int CompZombieCount ()
	{
			GameObject[] zombies = (GameObject[])GameObject.FindGameObjectsWithTag ("Zombie"); 
			int ret = zombies.Length; 
			//Debug.Log ("ZC: " + ret); 
			return ret;  
	}
} 
