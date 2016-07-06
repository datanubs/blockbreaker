using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour
{

    public int maxHits;
    private int timesHit;
    public Sprite[] hitSprites;
    private LevelManager levelManager;
    // Use this for initialization
    void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        timesHit = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
      
        timesHit++;
        if (timesHit >= maxHits){
            Destroy(gameObject);
        }
        else {
            LoadSprites();
        }
        Brick[] bricks = GameObject.FindObjectsOfType<Brick>();
        foreach (var brick in bricks)
        {
            print(brick);
        }
        if(bricks.Length == 0){
            levelManager.LoadNextLevel();
        }
    }
    void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }
}
