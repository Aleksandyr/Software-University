using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour 
{
    public Animator controller;
    int[] stateHashes = new int[2];

    void Start()
    {
        stateHashes[0] = Animator.StringToHash("Run");
        stateHashes[1] = Animator.StringToHash("Jump");
    }

	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            controller.SetBool("Run", true);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            controller.SetBool("Run", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            int jumpHash = stateHashes[(int)Animations.Jump];
            controller.SetBool(jumpHash, true);


            StartCoroutine(UncheckStateFlag(Animations.Jump));
        }
	}

    IEnumerator UncheckStateFlag(Animations flagHash)
    {
        yield return new WaitForEndOfFrame();
        Debug.Log("UncheckStateFlag");
        int hash = stateHashes[(int)flagHash];
        controller.SetBool(hash, false);
    }
}

public enum Animations
{
    Run = 0,
    Jump
}