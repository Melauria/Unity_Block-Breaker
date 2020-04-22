using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public AudioClip crack;
    public Sprite[] hitSprites;
    public static int brickCount = 0;
    
    private int timesHit;
    private LevelManager levelManager;
    private bool isBreakable;

	// Use this for initialization
	void Start () {
        // keep track of breakable bricks
        isBreakable = (this.tag == "Breakable");
        if (isBreakable){
            brickCount++;
        }
        
        levelManager = Object.FindObjectOfType<LevelManager>();
        timesHit = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    void OnCollisionEnter2D(Collision2D collision) {
        //AudioSource.PlayClipAtPoint (crack, transform.position);
        if (isBreakable){
            HandleHits();
        }
    }
    
    void HandleHits(){
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits){
            brickCount--;
            levelManager.BrickDestryed();
            Destroy(gameObject);
        } else {
            LoadSprites();
        }
    }
       
    void LoadSprites(){
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex]){
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
    }
    
    void SimulateWin(){
        levelManager.LoadNextLevel();
    }
}
