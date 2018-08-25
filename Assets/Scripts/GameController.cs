using UnityEngine;

public class GameController : MonoBehaviour
{
	[SerializeField]
	private Vector3 defaultGravityDirection = new Vector3(0.0f, -1f, 0.0f);

	[SerializeField]
	private float defaultGravityForce = 9.81f;

	[SerializeField]
	private float defaultTimeScale = 1.0f;

	// Use this for initialization
	void Start ()
	{
		Physics.gravity = defaultGravityDirection * defaultGravityForce;
		Time.timeScale = defaultTimeScale;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
