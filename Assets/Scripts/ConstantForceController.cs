using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantForceController : MonoBehaviour
{
	private GameController gameController;
	private ConstantForce constantForceComponent;

	// Use this for initialization
	void Start ()
	{
		gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
		if (!gameController)
		{
			Debug.Log("GameController not found");
			return;
		}

		constantForceComponent = GetComponent<ConstantForce>();
		if (!constantForceComponent)
		{
			Debug.Log("Constant Force not found");
			return;
		}

		UpdateGravity();
	}

	private void UpdateGravity()
	{
		constantForceComponent.force = gameController.GravityDirection * gameController.GravityForce;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!gameController || !constantForceComponent)
			return;
		UpdateGravity();
	}
}
