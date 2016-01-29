using UnityEngine;
using System.Collections;

public class checkCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D coll)
    {
        GetComponentInParent<LevelGeneration>().removePlatforms(coll.gameObject);
    }	
}
