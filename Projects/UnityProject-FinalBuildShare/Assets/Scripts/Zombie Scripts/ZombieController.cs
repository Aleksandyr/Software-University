// Author: Atoro 
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ZombieController : CreatureController
{
    public float Health = 300;
    public bool paused = false;
    public bool isZombieDead = false;
    // Update is called once per frame
    void Update()
    {
        // The Zombie is on the lava and have to die 
        if ((transform.position.y < lavaLevel))
        {
            isDead = true;
        }
        if (!isDead)
        { // The Zombie is not dead 
            // Compute the distance to the goal 
            float dist = Vector3.Distance(transform.position, goal.transform.position);
            // Debug.Log (dist); 
            if (dist < distInRange)
            { // The Zombie can see the goal 
                isInRange = true;
                Vector3 vect = new Vector3(goal.transform.position.x, transform.position.y, goal.transform.position.z);
                transform.LookAt(vect); // Look at the goal 
                if (dist < distTooClose)
                { // The Zombie can attack 
                    isTooClose = true;
                    transform.Translate(0.0F, 0.0F, -speed * 0.01f); // Move toward the goal 
                }
                else
                { // The Zombie can not attack 
                    isTooClose = false;
                    transform.Translate(0.0F, 0.0F, speed); // Move toward the goal 
                }

            }
            else
            { // The Zombie can not see the goal 
                isInRange = false;
            }
        }
        else
        { // The Zombie is dead 
            dyingTimer--;
            if (dyingTimer < 0)
            { // It is time to destroy the dead Zombie 
                GameObject zmkr = GameObject.Find("ZombieMaker");
                ZombieMaker zmkrScript = zmkr.GetComponent<ZombieMaker>();
                zmkrScript.score++;
                Destroy(this.gameObject);
            }
        }


        // Stay always on the ground 
        transform.Translate(0F, goDownSpeed, 0F);

        // Secret key for killing Zombies if thay are around  
        if (Input.GetKeyDown(KeyCode.K) && isInRange)
        {
            isDead = true;
        }

        // Set Animator Controller parameters 
        anim.SetBool("isDead", isDead);
        anim.SetBool("isInRange", isInRange);
        anim.SetBool("isTooClose", isTooClose);
        // Debug.Log ("inRange: " + tooClose + ", tooClose: " + tooClose);
    }
  
    void ApplyDammage(int Dammage)
    {
        Health -= Dammage;
        if (Health <= 0)
        {
            isDead = true;
        }
    }
    void OnGUI()
    {

        GUIStyle scoreStyle = new GUIStyle(GUI.skin.button);
        scoreStyle.fontSize = 28;
        Font myFont = (Font)Resources.Load("Fonts/youmurdererbb_reg", typeof(Font));
        scoreStyle.font = myFont;
        GUI.backgroundColor = Color.red;

        GameObject zmkr = GameObject.Find("ZombieMaker");
        ZombieMaker zmkrScript = zmkr.GetComponent<ZombieMaker>();
        GUI.Box(new Rect(840, 25, 100, 25), zmkrScript.score.ToString(), scoreStyle);
    }
}
