using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetTemp : MonoBehaviour
{


	void OnTriggerEnter()

	{
		SceneManager.LoadScene (0);
	}

}
