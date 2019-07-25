using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescendingIce : MonoBehaviour
{
	public float step1, step2, time;//1 for death, 2 for disappearance

	private void OnCollisionEnter(Collision collision)
	{
		StartCoroutine(Descend());
	}

	IEnumerator Descend()
	{
		var speed = step1 / time;
		var timer = 0f;

		while (timer < step2 / speed)
		{
			transform.position -= new Vector3(0f, speed * Time.fixedDeltaTime, 0f);
			timer += Time.fixedDeltaTime;
			yield return new WaitForFixedUpdate();
		}

		Destroy(gameObject);
	}
}
