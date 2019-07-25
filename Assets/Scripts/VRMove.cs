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

	public GameObject particles;

	public GameObject start, inGame;

	public float fuel = 1f, fuelConsumingSpeed = 0.01f;

	public static int gameState = 0;

	SteamVR_Behaviour_Pose trackedObj;

	AudioSource audioSource;

	bool triggerPressed = false;

	private void Awake()
	{
		trackedObj = GetComponent<SteamVR_Behaviour_Pose>();
	}

	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}

	private void FixedUpdate()
	{
		if (spawn.GetStateDown(trackedObj.inputSource))
		{
			Debug.Log("button pressed");

			if(gameState == 0)
			{
				gameState = 1;
				start.SetActive(false);
				inGame.SetActive(true);
			}

			else if(gameState == 1)
			{
				triggerPressed = true;
				particles.SetActive(true);
				audioSource.Play();
			}
		}

		if (spawn.GetStateUp(trackedObj.inputSource))
		{
			Debug.Log("button released");

			if(gameState == 1)
			{
				triggerPressed = false;
				particles.SetActive(false);
				audioSource.Stop();
			}
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
		if(gameState == 1)
			fuelImage.fillAmount = fuel;
	}
}
