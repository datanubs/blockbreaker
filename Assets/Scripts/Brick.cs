using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour
{
	/**
	 * Game control
	*/
	private bool isBreakable;
    private int timesHit = 0;
    public static int breakableCount = 0;
	private bool containsPowerUp = false;

	/**
	 * Game Objects and Components
	*/
	public GameObject smoke;
    public Sprite[] hitSprites;
	public GameObject[] powerUp;
    private LevelManager levelManager;
    public AudioClip crack;

    
    // Use this for initialization
    void Start()
    {
		if (breakableCount % 10 == 0) {
			containsPowerUp = true;
		}
	
        isBreakable = (this.tag == "Breakable");
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        if (isBreakable)
        {
            breakableCount++;
        }
    }

	/**
	 * Tiggers on Collision
	 */
    void OnCollisionEnter2D(Collision2D collider)
    {
        //AudioSource.PlayClipAtPoint(crack, transform.position)
        if (isBreakable)
        {
            HandleHits();
        }
    }

	/*
	 * Logic For when a Brick is hit
	 * The hitSprites array determines how many hits the block can take
	 */
    void HandleHits ()
    {
        timesHit++;
        if (timesHit >= hitSprites.Length + 1)
        {
            breakableCount--;
            levelManager.BrickDestroyed();
			AddSmoke ();
			if (containsPowerUp) {
				Instantiate (powerUp[Random.Range (0, 2)], gameObject.transform.position, Quaternion.identity);
			}
            Destroy(gameObject); 
        }
        else
        {
            LoadSprites();
        }
    }

	/*
	 * Use Particle System to create smoke when a brick is destroyed
	 * the smode is centered at the brick and has the same color
	 */
	void AddSmoke(){
		Vector3 smokepos = new Vector3 (gameObject.transform.position.x + 0.5f, gameObject.transform.position.y + 0.327f, 0f);
		GameObject brickSmoke = Instantiate (smoke, smokepos, Quaternion.identity) as GameObject;
		brickSmoke.GetComponent<ParticleSystem> ().startColor = gameObject.GetComponent<SpriteRenderer> ().color;
	}

	/*
	 * When a Brick is hit set the next sprite in the sprite array
	 * making them look damaged.
	 * 
	 * If a sprite somehow disappears then show an error for this
	 */
    void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        // If a sprite is missing make sure that the collider disappears
        if (hitSprites[spriteIndex])
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		} else {
			Debug.LogError ("Sprite Missing");
		}
        
    }
}
