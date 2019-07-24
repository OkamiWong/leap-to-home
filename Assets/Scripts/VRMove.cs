using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class VRMove : MonoBehaviour
{
	public Transform playerTransform;

	public SteamVR_Action_Boolean spawn = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("InteractUI");

	SteamVR_Behaviour_Pose trackedObj;

	bool triggerPressed = false;

    public AudioSource music;
    public AudioClip fly;

    
	private void Awake()
	{
		trackedObj = GetComponent<SteamVR_Behaviour_Pose>();
        music = gameObject.AddComponent<AudioSource>();
        music.playOnAwake = false;
        fly = Resources.Load<AudioClip>("music/fly");
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
			playerTransform.Translate(transform.forward);
            music.clip = fly;
            music.Play();
		}
	}
}

