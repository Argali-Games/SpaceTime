using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	[SerializeField]
	private Vector3 gravityDirection;

	[SerializeField]
	private float gravityForce;

	public Vector3 GravityDirection
	{
		get
		{
			return gravityDirection;
		}
		set
		{
			gravityDirection = value;
		}
	}

	public float GravityForce
	{
		get
		{
			return gravityForce;
		}
		set
		{
			gravityForce = value;
		}
	}

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
