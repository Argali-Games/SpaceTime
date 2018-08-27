using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
	// Camera movement speed
	[SerializeField]
	private float movementSpeedHorizontal = 5.0f;
	[SerializeField]
	private float movementSpeedVertical = 5.0f;

	private GameObject Player;

	// Use this for initialization
	void Start ()
	{
		Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update ()
	{
		LookVertical();
		LookHorizontal();
	}

	// rotate camera on x-axis to look up and down
	private void LookVertical()
	{
		transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * movementSpeedVertical, 0.0f), Space.Self);
		//TODO: Controller right stick vertical
	}

	// rotate player to change look direction
	private void LookHorizontal()
	{
		Player.transform.Rotate(new Vector3(0.0f, Input.GetAxis("Mouse X") * movementSpeedHorizontal), Space.Self);
		// TODO: Controller right stick horizontal
	}
}
