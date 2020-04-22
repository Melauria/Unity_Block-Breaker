using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooseCollider : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collision)
	{
        print("Trigger");
	}

    // we are using collision here
    private LevelManager levelManager;
    
	private void OnCollisionEnter2D(Collision2D collision)
	{
        //print("Collision");
        levelManager = Object.FindObjectOfType<LevelManager>();
        levelManager.LoadLevel("Lose");
	}
}
