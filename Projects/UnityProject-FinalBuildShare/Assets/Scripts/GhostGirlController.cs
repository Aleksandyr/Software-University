// Author: Atoro 
using UnityEngine;
using System.Collections;

public class GhostGirlController : CreatureController
{
		// Update is called once per frame
		void Update ()
		{
				if (!isDead) { // GhostGirl is not dead 
						// Compute the distance to the goal 
						float dist = Vector3.Distance (transform.position, goal.transform.position); 
						if (dist < distInRange) { // GhostGirl can see the goal 
								isInRange = true; 
								transform.LookAt (goal.transform.position); // Look at the goal 
								if (dist < distTooClose) { // GhostGirl is very close 
										isTooClose = true; 
								} else { // GhostGirl is not very close  
										isTooClose = false; 
								} 

						} else { // GhostGirl can not see the goal 
								isInRange = false; 
						}
				} 	
		}
}
