using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class timeManger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		Time.timeScale = 5;
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.R))
		{
			SceneManager.LoadScene(0);
		}
		if (Input.GetKeyDown(KeyCode.Period))
		{
			if (Time.timeScale == 5)
			{
				Time.timeScale = 10;
			}
			else if (Time.timeScale == 10)
			{
				Time.timeScale = 5;
			}
		}

		if (Input.GetKeyDown(KeyCode.Comma))
		{
			if (Time.timeScale == 5)
			{
				Time.timeScale = 0.1f;
			}
			else if (Time.timeScale == 0.1f)
			{
				Time.timeScale = 5;
			}
		}

	}
}
