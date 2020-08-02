using UnityEngine;

public class PlayerController : MonoBehaviour {

	// required components
	private Rigidbody myRigidbody;
	private CharacterMovement playerCharacterMovement;
	private GravityController playerGravityController;
	private TimeController playerTimeController;

	// Use this for initialization
	void Start () {
		// initialise required components
		myRigidbody = GetComponent<Rigidbody> ();
		playerCharacterMovement = GetComponent<CharacterMovement> ();
		playerGravityController = GetComponent<GravityController> ();
		playerTimeController = GetComponent<TimeController> ();
	}

	// Update is called once per frame
	void Update () {
		GetInput ();
	}

	private void GetInput () {
		// check if player wants character to sprint
		if (Input.GetButtonDown ("Sprint")) {
			playerCharacterMovement.isSprinting = true;
		} else if (Input.GetButtonUp ("Sprint")) {
			playerCharacterMovement.isSprinting = false;
		}

		// check if player wants character to jump
		if (Input.GetButtonDown ("Jump")) {
			playerCharacterMovement.Jump ();
		}

		if (Input.GetButtonDown ("Fire1")) {
			playerGravityController.ChangeGravityByPlayerView ();
		}

		if (Input.GetAxis ("Time Scale Scroll") != 0) {
			playerTimeController.AdjustTime (Input.GetAxis ("Time Scale Scroll"), true);
		} else if (Input.GetAxis ("Time Scale") != 0) {
			playerTimeController.AdjustTime (Input.GetAxis ("Time Scale"), false);
		}

		// move character based on input
		playerCharacterMovement.Move (Input.GetAxis ("Strafe"), Input.GetAxis ("Walk"));
	}
}