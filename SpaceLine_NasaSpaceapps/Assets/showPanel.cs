using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Cameras;

public class showPanel : MonoBehaviour
{
	public GameObject panel;
	private bool isOpen;
	public ClickSpawnScript cks;
	public FreeLookCam flc;
	public GameObject pointer;


	void Start()
    {
		panel.GetComponent<CanvasGroup>().alpha = 0f;
		panel.GetComponent<CanvasGroup>().blocksRaycasts = false;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		cks.enabled = false;
		isOpen = false;
		
	}

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			if (isOpen)
			{
				panel.GetComponent<CanvasGroup>().alpha = 0f;
				panel.GetComponent<CanvasGroup>().blocksRaycasts = false;
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
				cks.enabled = true;
				pointer.SetActive(true);
				flc.enabled = true;

				isOpen = false;


			}
			else if (!isOpen)
			{
				panel.GetComponent<CanvasGroup>().alpha = 1f;
				panel.GetComponent<CanvasGroup>().blocksRaycasts = true;
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
				cks.enabled = false;
				pointer.SetActive(false);
				flc.enabled = false;

				isOpen = true;

			}

		}
    }
}
