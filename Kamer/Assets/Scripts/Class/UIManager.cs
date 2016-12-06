using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public const byte _SPACE = 10;
    private const float _FADETIME = 10;

    [Header("Image setup")]
    [SerializeField] private RawImage _crosshair;
    [SerializeField] private Color _pink = new Color(0.982f, 0.0509f, 0.4039f, 1f), _green = new Color(0.0509f, 0.8666f, 0.4117f, 1f);
    [Header("Text setup")]
    [SerializeField] private Text _label;
    [SerializeField] private Text _timer;
    [SerializeField] private Text _info;
    [Header("Button setup")]
    [SerializeField] private Button _startbttn;
    [SerializeField] private Button _quitbttn;

    /// <summary>
    /// The crosshair on the screen.
    /// </summary>
    public RawImage Crosshair { get { return _crosshair; } }
    /// <summary>
    /// Shows the name of the object.
    /// </summary>
    public Text Label { get { return _label; } }
    /// <summary>
    /// The info the player gets at the beginning of the game.
    /// </summary>
    public Text Info { get { return _info; } }
    /// <summary>
    /// The timer which holds the time the user has left.
    /// </summary>
    public Text Timer { get { return _timer; } }
    /// <summary>
    /// The initial color of the crosshair.
    /// </summary>
    public Color Pink { get { return _pink; } }
    /// <summary>
    /// The color of the crosshair when it detects an item.
    /// </summary>
    public Color Green { get { return _green; } }
    /// <summary>
    /// The start button from the main menu.
    /// </summary>
    public Button Start { get { return _startbttn; } }
    /// <summary>
    /// The quit button from the main menu.
    /// </summary>
    public Button Quit { get { return _quitbttn; } }

    /// <summary>
    /// Give functionality to the buttons in the game.
    /// </summary>
    public void ButtonSetup()
    {
        _startbttn.onClick.AddListener(() => LevelManager.LoadScene(Collections.Scenes.StartRoomScene.ToString()));
        _quitbttn.onClick.AddListener(() => Application.Quit());
    }

    /// <summary>
    /// Change the color of the crosshair.
    /// </summary>
    /// <param name="c">The color it should change into.</param>
    public void SetCrosshairColor(Color c)
    {
        _crosshair.color = c;
    }

    /// <summary>
    /// Reset the text of the information labels.
    /// </summary>
    public void ResetLabel()
    {
        _label.text = "";
    }

    /// <summary>
    /// Fade the information labels on the screen to a specific color.
    /// </summary>
    /// <param name="c">The color the labels should turn into.</param>
    public void FadeLabel(Color c)
    {
        _label.color = Color.Lerp(_label.color, c, _FADETIME * Time.deltaTime);
    }
    
    /// <summary>
    /// Let the user know he has to escape the room.
    /// </summary>
    public void ActivateInfo()
    {
        _info.gameObject.SetActive(true);
        _timer.gameObject.SetActive(true);
    }
}
