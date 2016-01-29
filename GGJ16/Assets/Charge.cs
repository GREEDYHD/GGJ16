using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Charge : MonoBehaviour
{
	Rigidbody2D mRigidBody2D;
	public GameObject mAimArrow;
	public GameObject mLevelScroller;

	public Slider mSlider;

	public float mChargeForce;
	[SerializeField]
	Vector2 mChargeDirection = new Vector2(1,0);

	public float mAimAngle;
	float chargeUpTime = 0;
	float maxChargeUpTime = 3;
	float chargeDuration = 1;
	bool isCharging = false;
	bool canCharge = false;

	[SerializeField]
	int angleStep = 0;
	void Start()
	{
		mRigidBody2D = gameObject.GetComponent<Rigidbody2D>();
	}

	void Update ()
	{
//		angleStep = Mathf.Clamp (angleStep,-45,45);
//
//		Vector2 dir = new Vector2 (transform.position.x, transform.position .y) - mChargeDirection;
//		float angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
//		mAimArrow.transform.rotation = Quaternion.AngleAxis (angleStep * mAimAngle, Vector3.forward);
//
//		mChargeDirection = new Vector2(Mathf.Sin (angle),Mathf.Cos (angle));
//

		if (isCharging)
		{
			chargeDuration -= Time.deltaTime;
			if(chargeDuration <= 0)
			{
				chargeDuration = 1;
				isCharging = false;
			}
		}

		if (Input.GetKey (KeyCode.RightControl))
		{
			chargeUpTime += Time.deltaTime;
			chargeUpTime = Mathf.Clamp(chargeUpTime, 0, maxChargeUpTime);
		}

		if (Input.GetKeyUp (KeyCode.RightControl))
		{
			mLevelScroller.GetComponent<LevelGeneration>().Charge(chargeUpTime * 3);
			chargeUpTime = 0;
		}
		mSlider.value = chargeUpTime;
	}
}