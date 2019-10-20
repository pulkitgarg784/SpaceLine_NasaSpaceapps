using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifePredictor : MonoBehaviour
{
	private PlanetValues planetValues;

    // Start is called before the first frame update
    void OnEnable()
    {
		planetValues = GetComponent<PlanetValues>();
    }

    // Update is called once per frame
    void Update()
    {
		if (planetValues.planetTemp >= -5 && planetValues.planetTemp <= 100)	
		{
			if (planetValues.planetMass >= 4 && planetValues.planetMass <= 40)
			{
				if (planetValues.oxy <= 35 && planetValues.oxy >=15 && planetValues.carb >= 0.5 && planetValues.carb <= 10)
				{
					planetValues.Life = true;
					planetValues.Message = "All the conditions for life are met!";
				}
				else if(planetValues.oxy > 35)
				{
					planetValues.Life = false;
					planetValues.Message = "Your planet has a very high oxygen content, the organisms will die of oxygen poisoning and the planet chemistry will be very volatile";
				}
				else if (planetValues.oxy < 15)
				{
					planetValues.Life = false;
					planetValues.Message = "Due to scarecity of Oxygen, chemical reactions will be slow and complex lifeforms cannot exist";
				}
				else if (planetValues.carb < .05)
				{
					planetValues.Life = false;
					planetValues.Message = "Plant lifeforms canno exist without C02 which is a byproduct of life";
				}
				else if (planetValues.carb > 10)
				{
					planetValues.Life = false;
					planetValues.planetTemp += 50;
					planetValues.Message = "High surface temperature due to green house effect, Oceans will boil away";
				}
			}
			else if(planetValues.planetMass < 4)
			{
				planetValues.Message = "Planet's Gravity is too low, Atmosphere escaped the planet, water boiled away and the stars radiations scorched it's surface";
			}
			else if (planetValues.planetMass > 40)
			{
				planetValues.Message = "Planet's Gravity is too high, Complex life structures cannot form due to the Square–cube law";
			}
		}
		else if (planetValues.planetTemp < -5) {
			planetValues.Life = false;
			planetValues.Message = "Low temperatures cause chemicals to react slowly, which interferes with the reactions necessary for life.Also low temperatures freeze water, making liquid water unavailable. ";
		}
		else if (planetValues.planetTemp >100)
		{
			planetValues.Life = false;
			planetValues.Message = "Water Boils away at such high temperatures, and protien and DNA break apart";
		}
	}
}
