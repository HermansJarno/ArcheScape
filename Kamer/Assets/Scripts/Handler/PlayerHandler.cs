using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _UIReference;
    [Space(UIManager._SPACE)]
    [SerializeField] private byte _seeDistance;

    private UIManager _uim;

    // use this for initialization
    void Awake()
    {
        _camera = GetComponent<Camera>();
        _uim = _UIReference.GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        See();
    }

    /// <summary>
    /// Determine if the user can interact with an object.
    /// </summary>
    private void See()
    {
        int x = Screen.width / 2, y = Screen.height / 2;

        Ray ray = _camera.GetComponent<Camera>().ScreenPointToRay(new Vector2(x, y));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _seeDistance))
        {
            Debug.Log(hit.transform.name);
            // when we hit an object that's interactable
            if (hit.transform.GetComponent<Item>() != null)
            {
                // Fade in the label
                _uim.FadeLabel(Color.white);

                // set the label's content to the name of the hitted object
                _uim.Label.text = hit.transform.name;

                // set the color of the crosshair to green
                _uim.SetCrosshairColor(_uim.Green);
            }
        }
        else // we didn't hit an object that's interactable
        {
            // only do this when the color of the crosshair is not pink
            if (_uim.Crosshair.color != _uim.Pink)
            {
                _uim.Crosshair.color = _uim.Pink;
            }

            // only do this when the label is visible
            if (_uim.Label.color != Color.clear)
            {
                _uim.FadeLabel(Color.clear);
            }
        }
    }
}