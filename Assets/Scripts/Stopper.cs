using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stopper : MonoBehaviour
{
	GameObject player;

	private void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

	private void OnCollisionEnter(Collision collision)
	{
		player.GetComponent<Rigidbody>().velocity = Vector3.zero;
	}
}
