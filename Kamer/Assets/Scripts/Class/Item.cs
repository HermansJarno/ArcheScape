using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Item : MonoBehaviour {

    [SerializeField] private AudioClip _audio;
    [Space(UIManager._SPACE)]
    [SerializeField] private float _velocity = 20000f;
    [SerializeField] private float _rotation = 600f;

    private Rigidbody _rb;
    private Transform _interactingPoint;
    private GameObject _audioReference;
    private AudioSource _audioSource;

    private bool _isInteracting;

    private Vector3 posDelta;

    private Quaternion rotationDelta;
    private float angle;
    private Vector3 axis;

    private ViveControllers _controller;

    /// <summary>
    /// The clip the gameobject should play when colliding with an other gameobject.
    /// </summary>
    public AudioClip Clip { set { _audio = value; } }

    void Awake()
    {
        _audioReference = GameObject.FindGameObjectWithTag(Collections.Tags.AudioManager.ToString());
        _audioSource = _audioReference.GetComponent<AudioSource>();
        _audioSource.mute = true;
    }

    // Use this for initialization
    void Start () {
        _rb = GetComponent<Rigidbody>();
        _interactingPoint = transform.FindChild(Collections.Tags.InteractionPoint.ToString());
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
        _audioSource.mute = false;

        // set private class variable equal to the parameter we have given
        _controller = c;

        // set position and rotation of the new gameObject
        _interactingPoint.position = c.transform.position;
        _interactingPoint.rotation = c.transform.rotation;

        if(_interactingPoint.transform.parent.tag == Collections.Tags.Flashlight.ToString())
        {
            // if the gameobject is a flashlight, make it a child of the controller
            _interactingPoint.transform.parent.SetParent(c.transform, true);
        }
        
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
        if (c.transform.FindChild("Zaklamp") != null)
        {
            c.transform.FindChild("Zaklamp").parent = GameObject.Find("Flashlight").transform;
        }

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

    private void OnCollisionEnter()
    {
        _audioSource.PlayOneShot(_audio);
    }
}