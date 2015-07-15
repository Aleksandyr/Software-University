// Author: Atoro 
using UnityEngine;
using System.Collections;

public class CreatureController : MonoBehaviour
{
    // Public 
    public bool isDead;
    public bool isInRange;
    public bool isTooClose;

    // Private 
    internal float dyingTimer;
    internal float dyingTimerForScore;
    internal float distInRange;
    internal float distTooClose;
    internal float speed;
    internal float goDownSpeed;
    internal float lavaLevel;
    internal Animator anim;
    internal GameObject goal;


    // Use this for initialization
    void Start()
    {
        // Public 
        isDead = false;
        isInRange = false;
        isTooClose = false;

        // Private
        dyingTimer = 50;
        distInRange = 50f;
        distTooClose = 3f;
        speed = 0.05f;
        goDownSpeed = -0.05f;
        lavaLevel = 0.5f;
        anim = GetComponent<Animator>();
        goal = GameObject.FindWithTag("Player");
    }
}
