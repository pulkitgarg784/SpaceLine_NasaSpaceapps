using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    const float G = 6674f;

    public static List<Gravity> Attractors;
	//StarValue

	public Rigidbody rb;
	//ObjectSpecific Vars
	public bool star;
	public int StartVelocity;
	// 1 Mass is 1/1000 of Earth
	private void Start()
	{
		rb = this.transform.GetComponent<Rigidbody>();
		if (!star)
		{
			rb.AddForce(rb.transform.forward * StartVelocity);
		}
	}
	void FixedUpdate()
	{


		foreach (Gravity attractor in Attractors)
        {
            if (attractor != this)
                Attract(attractor);
        }
    }

    void OnEnable()
    {
        if (Attractors == null)
            Attractors = new List<Gravity>();

        Attractors.Add(this);
    }

    void OnDisable()
    {
        Attractors.Remove(this);
    }

    void Attract(Gravity objToAttract)
    {
        Rigidbody rbToAttract = objToAttract.rb;

        Vector3 direction = rb.position - rbToAttract.position;
        float sqrDistance = direction.sqrMagnitude;

        if (sqrDistance == 0f)
            return;

        float forceMagnitude = G * (rb.mass * rbToAttract.mass) / sqrDistance;
        Vector3 force = direction.normalized * forceMagnitude;

		rbToAttract.AddForce(force);
    }

}