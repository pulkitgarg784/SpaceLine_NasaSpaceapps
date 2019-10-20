using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class VR_Toggle : MonoBehaviour
{
	public bool isEnabled;
    // Start is called before the first frame update
    void Start()
    {
		XRSettings.enabled = false;
		isEnabled = false;

	}

	// Update is called once per frame
	void Update()
    {
		if (Input.GetKeyDown(KeyCode.V))
		{
			if (!isEnabled)
			{
				Debug.Log("enabled");
				XRSettings.enabled = true;
				XRSettings.eyeTextureResolutionScale = 1.5f;
				XRSettings.renderViewportScale = 1.5f;
				isEnabled = true;

			}
			else if (isEnabled)
			{
				Debug.Log("disabled");

				XRSettings.enabled = false;
				isEnabled = false  ;

			}
		}
	}
}
