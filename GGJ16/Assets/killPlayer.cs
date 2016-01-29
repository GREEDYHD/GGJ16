using UnityEngine;
using System.Collections;

public class killPlayer : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(GameObject.Find("Player") == coll.gameObject)
        {
            GameObject.Find("GameManager").GetComponent<gameManager>().resetGame();
        }
    }
}
