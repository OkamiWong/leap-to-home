using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.UI;

public class VRMove : MonoBehaviour
{
	public Rigidbody playerRigidbody;

	public SteamVR_Action_Boolean spawn = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("InteractUI");

	public Image fuelImage;

	public float fuel = 1f, fuelConsumingSpeed = 0.01f;

	SteamVR_Behaviour_Pose trackedObj;

	bool triggerPressed = false;

	private void Awake()
	{
		trackedObj = GetComponent<SteamVR_Behaviour_Pose>();
	}

	private void FixedUpdate()
	{
		if (spawn.GetStateDown(trackedObj.inputSource))
		{
			Debug.Log("button pressed");
			triggerPressed = true;
		}

		if (spawn.GetStateUp(trackedObj.inputSource))
		{
			Debug.Log("button released");
			triggerPressed = false;
		}

		if (triggerPressed)
		{
			if(fuel >= fuelConsumingSpeed)
			{
				fuel -= fuelConsumingSpeed;
				playerRigidbody.AddForce(transform.forward * 10f, ForceMode.Acceleration);
			}
		}
		else
		{
			if(fuel < 1f)
			{
				fuel += fuelConsumingSpeed;
			}
		}
	}

	private void Update()
	{
		fuelImage.fillAmount = fuel;
	}
}
