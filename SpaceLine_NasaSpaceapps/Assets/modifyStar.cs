using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class modifyStar : MonoBehaviour
{
	public int temp;
	public Slider ScaleSlider;
	public Slider TempSlider;
	public InputField nameField;
	public Text nameLabel;

	private bool isOpen;
	public GameObject drawer;

	public StarValues starvalues;
	private Rigidbody rb;
	Renderer rend;
	
	// Start is called before the first frame update
	void Start()
    {
		starvalues = GetComponent<StarValues>();
		rb = this.transform.GetComponent<Rigidbody>();
		rend = GetComponent<Renderer>();

		transform.localScale = new Vector3(starvalues.starSize, starvalues.starSize, starvalues.starSize);
		ChangeSize();
	}

    // Update is called once per frame
    void Update()
    {
		if (Input.GetMouseButtonDown(1))
		{
			if (isOpen)
			{
				drawer.SetActive(false);
				isOpen = false;
			}
		}
	}

	private void OnMouseOver()
	{
		if (Input.GetMouseButtonDown(0)){
			if (!isOpen)
			{
				drawer.SetActive(true);
				isOpen = true;
			}
		}
	}


	//custom Func
	public void ChangeSize()
	{
		//size = newSize;
		starvalues.starSize = ScaleSlider.value;
		transform.localScale = new Vector3(starvalues.starSize, starvalues.starSize, starvalues.starSize);
		if (starvalues.starSize < 30)
		{
			rb.mass = starvalues.starSize * 3.6f;
		}
		else if (starvalues.starSize > 150)
		{
			rb.mass = starvalues.starSize * 3.4f;
		}
		else
		{
			rb.mass = starvalues.starSize * 4.6f;
		}
		ChangeTemp();
	}
	public void ChangeTemp()
	{

		 if (starvalues.starSize <= 330 && starvalues.starSize >= 90)
		{
			TempSlider.minValue = 10000f;
			TempSlider.maxValue = 33000f;
			rend.material.color = Color.blue;

		}
		else if (starvalues.starSize <= 90 && starvalues.starSize >= 70)
		{
			TempSlider.minValue = 7500f;
			TempSlider.maxValue = 10000f;
			rend.material.color = Color.cyan;
		}
		else if (starvalues.starSize <= 70 && starvalues.starSize >= 58)
		{
			TempSlider.minValue = 6000f;
			TempSlider.maxValue = 7500f;
			rend.material.color = Color.white;

		}
		else if (starvalues.starSize <= 58 && starvalues.starSize >= 48)
		{
			TempSlider.minValue = 5200f;
			TempSlider.maxValue = 6000f;
			rend.material.color = Color.yellow;
		}
		else if (starvalues.starSize <= 48 && starvalues.starSize >= 35)
		{
			TempSlider.minValue = 3700f;
			TempSlider.maxValue = 5200f;
			rend.material.color = new Color(1.0f, 0.5f, 0.0f);
		}
		else if (starvalues.starSize <= 35)
		{
			TempSlider.minValue = 2000f;
			TempSlider.maxValue = 3700f;
			rend.material.color = new Color(.7f, 0.0f, 0.0f);

		}

	}
	public void changeName() {
		starvalues.starName = nameField.text;
		nameLabel.text = starvalues.starName + " System";
	}


}
