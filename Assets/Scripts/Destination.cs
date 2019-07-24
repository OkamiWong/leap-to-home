using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destination : MonoBehaviour
{
    public AudioSource crowd;
    public AudioClip huanhu;

    private void OnCollisionEnter(Collision collision)
	{
		StartCoroutine(LoadScene());
        crowd = gameObject.AddComponent<AudioSource>();
        crowd.playOnAwake = false;
        huanhu = Resources.Load<AudioClip>("crowd/huanhu");
    }

	IEnumerator LoadScene()
	{
		yield return new WaitForSeconds(2f);

		
        crowd.clip = huanhu;
        crowd.Play();
    }
}
