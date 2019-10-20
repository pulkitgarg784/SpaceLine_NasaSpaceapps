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
				planetValues.Life = true;
				planetValues.Message = "All the conditions for life are met!";
			}
			else
			{
				planetValues.Message = "Planet's Gravity is too low, Atmosphere escaped the planet, water boiled away and the stars radiations scorched it's surface";
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
