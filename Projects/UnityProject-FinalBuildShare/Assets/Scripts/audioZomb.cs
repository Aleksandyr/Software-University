using UnityEngine;
using System.Collections;

public class audioZomb : MonoBehaviour {

	public int timer;
	public AudioClip[] zombieAudio;
	// Use this for initialization
	void Start () {
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		timer++;
		if(timer%111==0){
			//Debug.Log(timer);
			OnCollisionEnter();
		}
	}

	void OnCollisionEnter(){
		AudioSource.PlayClipAtPoint (zombieAudio[ Random.Range (0, zombieAudio.Length)], transform.position);
	}
}
