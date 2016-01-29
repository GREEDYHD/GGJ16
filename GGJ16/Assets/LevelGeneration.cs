using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class LevelGeneration : MonoBehaviour
{
    public List<GameObject> listOfPlatforms;
    public GameObject initialPlatform;

	bool isPlayerCharging = false;
    [SerializeField] float platformSpeed = 1;
	float originalPlatformSpeed = 1;
	public float initialWaitTime = 3;

	public float minPlatformWidth = 3;
	public float maxPlatformWidth = 6;

	float chargeSpeed;

    BoxCollider2D destructionBoundary;


	// Use this for initialization
	void Start ()
    {
        listOfPlatforms = new List<GameObject>();
        addToPlatforms(initialPlatform);
        destructionBoundary = GetComponentInChildren<BoxCollider2D>();

        // initialise the platforms spawning
        InvokeRepeating("createNewPlatform", initialWaitTime, initialWaitTime);
    }

    // Update is called once per frame
    void Update ()
    {
        movePlatforms();
	}

    // public function to change how often the platfroms spawn
    public void changePlatformFrequency(float newWaitTime)
    {
		initialWaitTime = newWaitTime;
        CancelInvoke("createNewPlatform");
        InvokeRepeating("createNewPlatform", newWaitTime, newWaitTime);
    }
    // public function to change the platfrom width range
    public void changePlatformWidthRange(float min, float max)
    {
        minPlatformWidth = min;
        maxPlatformWidth = max;
    }

	public void changePlatformSpeed(float value)
	{
		platformSpeed = value;
	}
    //public function to change the platform material
    public void changePlatformSprite(Sprite sprite)
    {
        initialPlatform.GetComponent<SpriteRenderer>().sprite = sprite;
    }

    //creates a new platform
    void createNewPlatform()
    {
        //instantiate a new platform
        GameObject platform = Instantiate(initialPlatform) as GameObject;
        //add to the list
        addToPlatforms(platform);

        // randomise the platfrom width
        float width = Random.Range(minPlatformWidth, maxPlatformWidth);
        platform.transform.localScale = new Vector2(width, 1);

        //randomise it's y posiiton
        float yCoord = Random.Range(-3.0f, 3.0f);
        // set it's position off screen
        platform.transform.position = new Vector2(9, yCoord);
        // renable it's renderer
        platform.GetComponent<MeshRenderer>().enabled = true;
    }

    // moves the platforms left each update
    void movePlatforms()
    {
        for (int i = 0; i < listOfPlatforms.Count; ++i)
        {
            // increments by the value platformSpeed
			listOfPlatforms[i].transform.position = new Vector2(listOfPlatforms[i].transform.position.x - (platformSpeed * (isPlayerCharging ? chargeSpeed : 1) / 20), listOfPlatforms[i].transform.position.y);
			Debug.Log (isPlayerCharging);
		}
    }

    // delete the platform referenced
    public void removePlatforms(GameObject platform)
    {
        for(int i = 0; i < listOfPlatforms.Count; ++i)
        {
            if(listOfPlatforms[i] == platform)
            {
                listOfPlatforms.RemoveAt(i);

                // if the platform is the original platform, don't delete it because it is the reference for creating new platforms
                if (platform == initialPlatform)
                {
                    platform.GetComponent<MeshRenderer>().enabled = false;
                }
                else
                {
                    Destroy(platform);
                }
            }
        }
    }

    // function to add each platform to the list
    void addToPlatforms(GameObject platform)
    {
        listOfPlatforms.Add(platform);
    }

	public void Charge(float chargeTime)
	{
		chargeSpeed = chargeTime;
		isPlayerCharging = true;
		Invoke ("stopCharge", chargeTime);
	}

	public float GetChargeTime()
	{
		return chargeSpeed;
	}

	void stopCharge()
	{
		isPlayerCharging = false;
		//changePlatformSpeed (originalPlatformSpeed);
	}
}
