using UnityEngine;

public class PlayerController : MonoBehaviour
{
	// if the player is on the ground, then it is true
	private bool isGrounded = true;

	[SerializeField]
	private float movementSpeed = 5.0f;

	// Sprint variables
	[SerializeField]
	private float sprintSpeed = 8.0f;
	private bool isSprinting = false;

	[SerializeField]
	private float jumpVelocity = 5.0f;

	// required components
	private Rigidbody myRigidbody;
	private ConstantForce myConstantForce;

	// Use this for initialization
	void Start ()
	{
		// initialise required components
		myRigidbody = GetComponent<Rigidbody>();
		myConstantForce = GetComponent<ConstantForce>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		isGrounded = CheckGrounded();
		GetInput();
		Move();
		ApplyGravity();
	}

	private void GetInput()
	{
		// check if player wants character to sprint
		if (Input.GetButtonDown("Sprint"))
		{
			isSprinting = true;
		}
		else if (Input.GetButtonUp("Sprint"))
		{
			isSprinting = false;
		}

		// check if player wants character to jump
		if (Input.GetButtonDown("Jump"))
		{
			Jump();
		}
	}

	private void Jump()
	{
		// don't jump if in the air
		if (!isGrounded)
			return;

		// keep x-z velocity but change jump velocity
		myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, jumpVelocity, myRigidbody.velocity.z);
	}

	private void Move()
	{
		// don't change velocity if in the air
		if (!isGrounded)
			return;

		// create and assign the movement based on input
		Vector3 motion = new Vector3(
		motion.x = Input.GetAxis("Horizontal"),
		0.0f,
		motion.z = Input.GetAxis("Vertical"));

		// adjust speed if sprinting or not
		if (isSprinting)
		{
			motion *= sprintSpeed;
		}
		else
		{
			motion *= movementSpeed;
		}
		
		// keep vertical velocity
		motion.y = myRigidbody.velocity.y;
		Vector3 newVelocity = transform.TransformVector(motion);
		// assign x-z movemnt to rigidbody velocity
		myRigidbody.velocity = newVelocity;
	}

	// check if player is touching the floor
	private bool CheckGrounded()
	{
		// raycast down to see if touching the floor
		float RayLength = 0.11f;
		// temporary variable to store the hit
		RaycastHit Hit;
		return Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z),
			Vector3.down, out Hit, RayLength);
	}

	// use constant foce to apply downward gravity even if physics gravity is facing another direction
	private void ApplyGravity()
	{
		myConstantForce.force = Vector3.down * 9.81f * myRigidbody.mass;
	}
}
