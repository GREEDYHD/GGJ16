using UnityEngine;
using System.Collections;

public class Charge : MonoBehaviour
{
	Rigidbody2D mRigidBody2D;
	public GameObject mAimArrow;

	public float mChargeForce;
	[SerializeField]
	Vector2 mChargeDirection = new Vector2(1,0);

	public float mAimAngle;

	[SerializeField]
	int angleStep = 0;
	void Start()
	{
		mRigidBody2D = gameObject.GetComponent<Rigidbody2D>();
	}

	void Update ()
	{

		if (Input.GetKey(KeyCode.UpArrow))
		{
			angleStep++;
		}

		if (Input.GetKey (KeyCode.DownArrow))
		{
			angleStep--;
		}

		//angleStep = Mathf.Clamp (angleStep,-45,45);

		Vector2 dir = new Vector2 (transform.position.x, transform.position .y) - mChargeDirection;
		float angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
		mAimArrow.transform.rotation = Quaternion.AngleAxis (angleStep * mAimAngle, Vector3.forward);

		mChargeDirection = new Vector2(Mathf.Sin (angle),Mathf.Cos (angle));

		if (Input.GetKeyDown (KeyCode.RightControl))
		{
			mRigidBody2D.AddForce(mChargeDirection * mChargeForce);
			Debug.Log (mChargeDirection);
		}

	}
}