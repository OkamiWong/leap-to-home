using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Water : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag != "Player") return;

		SceneManager.LoadScene(0);
	}
}
