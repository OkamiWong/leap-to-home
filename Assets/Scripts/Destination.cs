using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destination : MonoBehaviour
{
	public GameObject inGame,win;

	private void OnCollisionEnter(Collision collision)
	{
		StartCoroutine(Win());
	}

	IEnumerator Win()
	{
		inGame.SetActive(false);
		win.SetActive(true);
		yield return new WaitForSeconds(3f);
		VRMove.gameState = 0;
		SceneManager.LoadScene(0);
	}
}
