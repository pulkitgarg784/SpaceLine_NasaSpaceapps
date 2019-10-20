using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Planet : MonoBehaviour
{
	public GameObject Star;
	private Transform target;
	//inputs
	public InputField PlanetSize;
	public InputField PlanetSpeed;
	private Rigidbody rb;
	//values
	private PlanetValues planetValues;
	private StarValues starValues;





	[Range(2, 512)]
	public int resolution = 256;

	public float frequency = 1f;

	[Range(1, 8)]
	public int octaves = 1;

	[Range(1f, 4f)]
	public float lacunarity = 2f;

	[Range(0f, 1f)]
	public float persistence = 0.5f;

	[Range(1, 3)]
	public int dimensions = 3;

	public NoiseMethodType type;

	public Gradient coloring;
	GradientColorKey[] colorKey;
	GradientAlphaKey[] alphaKey;

	private Texture2D texture;
	// Start is called before the first frame update
	void Start()
    {
        
    }
	private void OnEnable()
	{
		Star = GameObject.FindGameObjectWithTag("Star");
		PlanetSize = GameObject.Find("PlanetSize").GetComponent<InputField>();
		PlanetSpeed = GameObject.Find("PlanetSpeed").GetComponent<InputField>();
		planetValues = GetComponent<PlanetValues>();
		starValues = Star.GetComponent<StarValues>();
		rb = GetComponent<Rigidbody>();


		planetValues.planetSize = int.Parse(PlanetSize.text);
		planetValues.planetSpeed = int.Parse(PlanetSpeed.text);


		target = Star.transform;
		Vector3 targetRot = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
		transform.LookAt(targetRot);
		transform.Rotate(0, 90, 0);
		transform.localScale = new Vector3(planetValues.planetSize, planetValues.planetSize, planetValues.planetSize);
		rb.AddForce(rb.transform.forward * int.Parse(PlanetSpeed.text));
		planetValues.planetMass = ((planetValues.planetSize / 5f)* (planetValues.planetSize / 5f));
		rb.mass = planetValues.planetMass;

		///////////////////
		
		coloring = new Gradient();
		colorKey = new GradientColorKey[2];
		colorKey[0].color = Random.ColorHSV();
		colorKey[0].time = 0.0f;
		colorKey[1].color = Random.ColorHSV();
		colorKey[1].time = 1.0f;

		alphaKey = new GradientAlphaKey[2];
		alphaKey[0].alpha = 1.0f;
		alphaKey[0].time = 0.0f;
		alphaKey[1].alpha = 0.0f;
		alphaKey[1].time = 1.0f;

		coloring.SetKeys(colorKey, alphaKey);



		if (texture == null)
		{
			texture = new Texture2D(resolution, resolution, TextureFormat.RGB24, true);
			//texture.name = "Planet Texture";
			texture.wrapMode = TextureWrapMode.Clamp;
			texture.filterMode = FilterMode.Trilinear;
			texture.anisoLevel = 9;
			GetComponent<MeshRenderer>().material.mainTexture = texture;
		}
		FillTexture();



	}

	// Update is called once per frame
	void Update()
    {
		float dist = Vector3.Distance(Star.transform.position, transform.position);
		Debug.Log(dist + "dist");
		Debug.Log(starValues.starTemp + "star");
		float scaleValue = starValues.starTemp / 5200f;
		if (dist/scaleValue > 1500)
		{
			planetValues.planetTemp = Random.Range(-350, -425);

		}
		else if (dist / scaleValue > 1250)
		{
			planetValues.planetTemp = Random.Range(-250, -350);

		}
		else if (dist / scaleValue > 1000)
		{
			planetValues.planetTemp = Random.Range(-50, -150);

		}
		else if (dist / scaleValue > 900)
		{
			planetValues.planetTemp = Random.Range(-20, -50);

		}
		else if (dist / scaleValue > 450)
		{
			planetValues.planetTemp = Random.Range(-5, 40);

		}
		else if (dist / scaleValue > 375)
		{
			planetValues.planetTemp = Random.Range(50, 150);
		}
		else if (dist / scaleValue > 300)
		{
			planetValues.planetTemp = Random.Range(150, 200);
		}
		else if (dist / scaleValue > 150)
		{
			planetValues.planetTemp = Random.Range(200, 300);
		}
		else if (dist / scaleValue > 0)
		{
			planetValues.planetTemp = Random.Range(300, 350);
		}

	}

	public void FillTexture()
	{
		if (texture.width != resolution)
		{
			texture.Resize(resolution, resolution);
		}

		Vector3 point00 = transform.TransformPoint(new Vector3(-0.5f, -0.5f));
		Vector3 point10 = transform.TransformPoint(new Vector3(0.5f, -0.5f));
		Vector3 point01 = transform.TransformPoint(new Vector3(-0.5f, 0.5f));
		Vector3 point11 = transform.TransformPoint(new Vector3(0.5f, 0.5f));

		NoiseMethod method = Noise.methods[(int)type][dimensions - 1];
		float stepSize = 1f / resolution;
		for (int y = 0; y < resolution; y++)
		{
			Vector3 point0 = Vector3.Lerp(point00, point01, (y + 0.5f) * stepSize);
			Vector3 point1 = Vector3.Lerp(point10, point11, (y + 0.5f) * stepSize);
			for (int x = 0; x < resolution; x++)
			{
				Vector3 point = Vector3.Lerp(point0, point1, (x + 0.5f) * stepSize);
				float sample = Noise.Sum(method, point, frequency, octaves, lacunarity, persistence);
				if (type != NoiseMethodType.Value)
				{
					sample = sample * 0.5f + 0.5f;
				}
				texture.SetPixel(x, y, coloring.Evaluate(sample));
			}
		}
		texture.Apply();
	}
}
