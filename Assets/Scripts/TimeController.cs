using UnityEngine;

public class TimeController : MonoBehaviour {
	// Min and Max time scale
	[SerializeField]
	private float maxTimeScale = 2.0f;
	[SerializeField]
	private float minTimeScale = 0.5f;
	[SerializeField]
	private float timeScaleStep = 0.5f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void AdjustTime (float TimeAxis, bool isScrollWheel) {
		float newTimeScale = Time.timeScale;

		if (isScrollWheel) {
			newTimeScale += TimeAxis;
		} else {
			newTimeScale += TimeAxis * timeScaleStep;
		}

		if (newTimeScale >= maxTimeScale) {
			newTimeScale = maxTimeScale;
		} else if (newTimeScale <= minTimeScale) {
			newTimeScale = minTimeScale;
		}

		Time.timeScale = newTimeScale;
	}
}