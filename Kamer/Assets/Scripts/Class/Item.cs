using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Item : MonoBehaviour {

    [SerializeField] private Rigidbody _rb;

    private bool _isInteracting;

    [SerializeField] private float _velocity = 20000f;
    private Vector3 posDelta;

    [SerializeField] private float _rotation = 600f;
    private Quaternion rotationDelta;
    private float angle;
    private Vector3 axis;

    private ViveControllers _controller;

    private Transform _interactingPoint;

    // Use this for initialization
    void Start () {
        _rb = GetComponent<Rigidbody>();
        _interactingPoint = new GameObject().transform;
        _velocity /= _rb.mass;
        _rotation /= _rb.mass;
	}
	
	// Update is called once per frame
	void Update () {
        if (_controller && _isInteracting)
        {
            posDelta = _controller.transform.position - _interactingPoint.position;
            _rb.velocity = posDelta * _velocity * Time.fixedDeltaTime;

            rotationDelta = _controller.transform.rotation * Quaternion.Inverse(_interactingPoint.rotation);
            rotationDelta.ToAngleAxis(out angle, out axis);

            if (angle > 180) { angle -= 360; }

            if (angle < 5f)
                _rb.angularVelocity = Vector3.zero;
            else
                _rb.angularVelocity = (Time.fixedDeltaTime * angle * axis) * _rotation * Mathf.Abs(angle) / 180;
        }
    }

    /// <summary>
    /// Begin interaction with the gameobject.
    /// </summary>
    /// <param name="c">The controller we are using.</param>
    public void BeginInteraction(ViveControllers c)
    {
        // set private class variable equal to the parameter we have given
        _controller = c;

        // set position and rotation of the new gameObject
        _interactingPoint.position = c.transform.position;
        _interactingPoint.rotation = c.transform.rotation;

        // make sure it's a child of the gameobject which we are colliding with
        // so it moves and turns around with the controller
        _interactingPoint.SetParent(transform, true);
        _isInteracting = true;
    }

    /// <summary>
    /// End interaction with the gameobject.
    /// </summary>
    /// <param name="c">The controller we are using.</param>
    public void EndInteraction(ViveControllers c)
    {
        // when the controller we have given is equal to the controller
        // we have last used
        if(c == _controller)
        {
            // delete this value
            _controller = null;

            // stop interacting with any gameobject
            _isInteracting = false;
        }
    }

    /// <summary>
    /// Is the object we hit currently interacting with a controller?
    /// </summary>
    /// <returns>The state of interaction with the controller.</returns>
    public bool IsInteracting()
    {
        return _isInteracting;
    }
}
