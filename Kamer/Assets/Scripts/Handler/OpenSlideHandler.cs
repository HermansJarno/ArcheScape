using UnityEngine;

public class OpenSlideHandler : MonoBehaviour {

    /// <summary>
    /// The beginposition of the slide.
    /// </summary>
    [SerializeField] private Vector3 _beginPosition;
    /// <summary>
    /// The distance a slide can take.
    /// </summary>
    [SerializeField] private float _slideUntilDistanceReached = 5f;

	// Use this for initialization
	void Start () {
        _beginPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(_beginPosition, transform.position) >= _slideUntilDistanceReached)
        {
            return;
        }
	}
}
