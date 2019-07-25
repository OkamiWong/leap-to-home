using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingIce : MonoBehaviour
{
	public float deltaX;
	public float deltaY;
	public float deltaZ;

	public float time;

	float timer = 0f;

	Vector3 translation;

	private void Start()
	{
		translation = (new Vector3(deltaX, deltaY, deltaZ));
	}

	private void FixedUpdate()
	{
		timer += Time.fixedDeltaTime;

		if (timer < time)
		{
			transform.position += translation;
		}
		else if(timer < time * 2)
		{
			transform.position -= translation;
		}
		else
		{
			timer = 0f;
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.rigidbody.tag != "Player") return;
		collision.transform.parent = this.transform;
	}

	private void OnCollisionExit(Collision collision)
	{
		if (collision.rigidbody.tag != "Player") return;
		collision.transform.parent = null;
	}
}
