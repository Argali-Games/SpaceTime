using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
	// gravity variables
	private float gravityForce = 9.81f;
	private Vector3 gravityDirection;

	private GameController gameController;
	private GameObject playerCamera;
	private GameObject player;

	// Use this for initialization
	void Start ()
	{
		gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
		playerCamera = GameObject.FindGameObjectWithTag("MainCamera");
		player = GameObject.FindGameObjectWithTag("Player");

		gravityForce = gameController.defaultGravityForce;
		gravityDirection = gameController.defaultGravityDirection;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void ChangeGravityByPlayerView()
	{
		// RayCast to find normal of environment object hit
		RaycastHit Hit;
		if (!RayCastFromCamera(out Hit))
			return;

		gravityDirection = -Hit.normal;
		
		Physics.gravity = gravityDirection * gravityForce;
	}

	private bool RayCastFromCamera(out RaycastHit hit)
	{
		Ray ray = playerCamera.GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
		// Raycast
		return Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("Environment"));
	}
}
