using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetTemp : MonoBehaviour
{



	void OnTriggerEnter()

	{
		if (gameObject.tag == "Player") 
		{
			SceneManager.LoadScene (0);
		}
	}

}
