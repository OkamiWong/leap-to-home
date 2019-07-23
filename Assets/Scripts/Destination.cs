using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destination : MonoBehaviour
{
	private void OnCollisionEnter(Collision collision)
	{
		StartCoroutine(LoadScene());
	}

	IEnumerator LoadScene()
	{
		yield return new WaitForSeconds(2f);

		SceneManager.LoadScene(0);
	}
}
