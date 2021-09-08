using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyStateController : StateController
{
	public GameObject enemyToAngryChase;
	
	
    public bool CheckIfInAngryRange(string tag)
	{
		enemies = GameObject.FindGameObjectsWithTag(tag);
        if (enemies != null)
        {
            foreach (GameObject g in enemies)
            {
                if (Vector3.Distance(g.transform.position, transform.position) < detectionRange - 2)
                {
                    enemyToAngryChase = g;
                    return true;
                }
            }
        }
        return false;
	}
}
