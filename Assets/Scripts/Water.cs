using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Water : MonoBehaviour
{
	public GameObject inGame, lose;

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag != "Player") return;
		StartCoroutine(ShowLose());
	}

	IEnumerator ShowLose()
	{
		lose.SetActive(true);
		inGame.SetActive(false);
		yield return new WaitForSeconds(3f);
		VRMove.gameState = 0;
		SceneManager.LoadScene(0);
	}
}
