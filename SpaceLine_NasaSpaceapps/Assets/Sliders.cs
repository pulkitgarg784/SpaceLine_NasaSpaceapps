using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sliders : MonoBehaviour
{
	private Slider oxygen;
	private Slider nitrogen;
	private Slider carbondioxide;

	public float oxygenValue;
	public float nitrogenValue;
	public float co2Value;

	private float oxygenChange;
	private float nitrogenChange;
	private float co2Change;
	public PlanetValues planetValues;

	// Start is called before the first frame update
	void Start()
    {
		oxygen = GameObject.Find("oxygen").GetComponent<Slider>();
		nitrogen = GameObject.Find("nitrogen").GetComponent<Slider>();
		carbondioxide = GameObject.Find("carbondioxide").GetComponent<Slider>();
		nitrogen.value = 33.33f;
		oxygen.value = 33.33f;
		carbondioxide.value = 33.33f;
		oxygenValue = oxygen.value;
		nitrogenValue = nitrogen.value;
		co2Value = carbondioxide.value;
	}
	public void OxygenDragBegin()
	{
		oxygenValue = oxygen.value;
	}
	public void OxygenDragEnd()
	{

		oxygenChange = oxygen.value-oxygenValue;
		AdjustSliderCO2andNitrogen();
		oxygenValue = oxygen.value;
		nitrogenValue = nitrogen.value;
		co2Value = carbondioxide.value;

	}
	public void NitrogenDragBegin()
	{
		nitrogenValue = nitrogen.value;
	}
	public void NitrogenDragEnd()
	{

		nitrogenChange = nitrogen.value - nitrogenValue;
		AdjustSliderCO2andOxygen();
		oxygenValue = oxygen.value;
		nitrogenValue = nitrogen.value;
		co2Value = carbondioxide.value;
	}
	public void co2DragBegin()
	{
		co2Change = carbondioxide.value;
	}
	public void co2DragEnd()
	{

		co2Change = carbondioxide.value - co2Value;
		AdjustSliderNitrogenandOxygen();
		oxygenValue = oxygen.value;
		nitrogenValue = nitrogen.value;
		co2Value = carbondioxide.value;
	}

	void AdjustSliderCO2andNitrogen()
	{	
		//nitrogen.value = nitrogen.value - oxygenChange / 2;
		//carbondioxide.value = carbondioxide.value - oxygenChange / 2;
		if(co2Value >= oxygenChange / 2)
		{
			carbondioxide.value -= oxygenChange / 2;
		}
		else
		{
			carbondioxide.value = 0;
		}
		nitrogen.value = 100 - oxygen.value - carbondioxide.value;


	}
	void AdjustSliderCO2andOxygen()
	{
		//carbondioxide.value = carbondioxide.value - nitrogenChange / 2;
		//oxygen.value = oxygen.value - oxygenChange / 2;
		if (co2Value >= nitrogenChange / 2)
		{
			carbondioxide.value -= nitrogenChange / 2;
		}
		else
		{
			carbondioxide.value = 0;
		}
		oxygen.value = 100 - nitrogen.value - carbondioxide.value;

	}
	void AdjustSliderNitrogenandOxygen()
	{
		//nitrogen.value = nitrogen.value - co2Change / 2;
		//oxygen.value = oxygen.value - co2Change / 2;
		if (nitrogenValue >= co2Change / 2)
		{
			nitrogen.value -= co2Change / 2;
		}
		else
		{
			nitrogen.value = 0;
		}
		oxygen.value = 100 -carbondioxide.value - nitrogen.value;


	}

}
