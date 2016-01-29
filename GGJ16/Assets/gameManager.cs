using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    int score = 0;
    int circle = 0;
    float timeElapsed = 0;

    public Text scoreText;
    public Text circleText;
    public Text timeText;

    [SerializeField] int[] circleBoundaries;
    [SerializeField] Sprite[] platformSprites;
    [SerializeField] Sprite[] backgroundSprites;

    LevelGeneration level;

    // Use this for initialization
    void Start ()
    {
        InvokeRepeating("calculateScore", 0, 1);

        circleText.text = "Circle 1";

        level = GameObject.Find("levelObject").GetComponent<LevelGeneration>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        calculateTime();

        // if the player has reached the circle boundary
        if(score > circleBoundaries[circle])
        {
            updateCicle();
        }
	}

    void calculateTime()
    {
        timeElapsed = Time.realtimeSinceStartup;
        timeText.text = timeElapsed.ToString("F2");
    }

    void calculateScore()
    {
        score += 5;
        scoreText.text = "Score " + score.ToString();
    }

    // change the textures etc for the next circle
    void updateCicle()
    {
        ++circle;
        circleText.text = "Circle " + circle;

        // the change platform material function needs to be changed to change sprite
        //level.changePlatformSprite(platformSprites[circle]);

        // reduce the platforms frequency and size
        //level.changePlatformFrequency(level.initialWaitTime - 0.5);
        //level.changePlatformWidthRange(level.minPlatformWidth - 0.5, level.maxPlatformWidth - 0.5);

    }

    public void resetGame()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
