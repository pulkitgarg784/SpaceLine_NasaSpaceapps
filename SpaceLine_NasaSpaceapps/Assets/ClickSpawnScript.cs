using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ClickSpawnScript : MonoBehaviour
{

	public GameObject Prefab;
	public int RayDistance = 10000;
	private Vector3 Point;

	public Text tempText;
	public Text atmosText;
	public Text lifeText;
	public Text lifeMessage;


	public void Update()
	{
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if (Physics.Raycast(ray, out hit) && hit.transform.tag == "Planet")
		{
			tempText.text = hit.transform.GetComponent<PlanetValues>().planetTemp.ToString() + " C";
			lifeText.text = "Life: " + hit.transform.GetComponent<PlanetValues>().Life.ToString();
			lifeMessage.text = hit.transform.GetComponent<PlanetValues>().Message;

		}
		if (Input.GetMouseButtonDown(0))
		{

			if (Physics.Raycast(ray, out hit) && hit.transform.tag != "Star")
			{
				Point = hit.point;
				Instantiate(Prefab, Point, Quaternion.identity);
			}

		}
	}
}