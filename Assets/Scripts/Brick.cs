using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour
{
    private int timesHit;
    public static int breakableCount = 0;
    public Sprite[] hitSprites;
    private LevelManager levelManager;
    public AudioClip crack;

    private bool isBreakable;
    // Use this for initialization
    void Start()
    {
    
        isBreakable = (this.tag == "Breakable");
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        if (isBreakable)
        {
            breakableCount++;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        print(crack);
        AudioSource.PlayClipAtPoint(crack, transform.position);
        
        if (isBreakable)
        {
            HandleHits();
        }
    }

    void HandleHits ()
    {
        timesHit++;
        if (timesHit >= hitSprites.Length + 1)
        {
            breakableCount--;
            levelManager.BrickDestroyed();
            Destroy(gameObject); 
        }
        else
        {
            LoadSprites();
        }
    }

    void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        // If a sprite is missing make sure that the collider disappears
        if (hitSprites[spriteIndex])
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        
    }
}
