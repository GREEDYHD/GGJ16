using UnityEngine;
using System.Collections;

public class JumpingScript : MonoBehaviour {

	[SerializeField]
	private float numberOfJumps;
	[SerializeField]
	private bool isGrounded;
	[SerializeField]
	private float jumpForce = 4;
	

	private Rigidbody2D m_RB;

	// Use this for initialization
	void Start () 
	{
		m_RB = GetComponent <Rigidbody2D>();	
	}

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Space) && numberOfJumps < 2)
		{
			m_RB.velocity = Vector2.zero;
			m_RB.AddForce(Vector2.up * jumpForce / 100);
			numberOfJumps++;
		}

		if (m_RB.velocity.y < 0)

		{
			//change animation to grounded
			Debug.Log ("Ground Animation Play");
		}
	}

	public void OnCollisionEnter2D(Collision2D collider) //Checks the player has collided with the ground
	{
		if(collider.gameObject.tag == ("Ground"))
		{
			numberOfJumps = 0f;
			jumpForce = 4;
		}
	}
}
