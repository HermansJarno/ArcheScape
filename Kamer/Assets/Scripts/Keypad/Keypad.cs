using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class Keypad
{

    private byte _numberOfTries;
    private Transform instance;
    private const byte MAXNUMTRIES = 3;

    [SerializeField]
    private string _password;
    [SerializeField]
    private Button[] _buttons = new Button[12];

    /// <summary>
    /// Constructor for the Keypad.
    /// </summary>
    /// <param name="obj">The transform needed to be instatiated.</param>
    /// <param name="parent">The parent to which the object should be attached.</param>
    public Keypad(Transform obj, Transform parent)
    {
        _password = "12345";
        instance = InstantiateNewKeypad(obj, parent);
        GetButtons(instance);
    }

    public Transform transform
    {
        get { return instance; }
    }

    public byte NumberOfTries
    {
        get { return _numberOfTries; }
    }

    public string Password
    {
        get { return _password; }
    }

    public Button[] Buttons
    {
        get { return _buttons; }
    }

    private Transform InstantiateNewKeypad(Transform obj, Transform parent)
    {
        Transform inst = Object.Instantiate(obj);
        inst.name = "Keypad";
        inst.SetParent(parent, false);

        return inst;
    }

    /// <summary>
    /// Gets the buttons from a keypad and puts them into the buttons array.
    /// </summary>
    /// <param name="obj">The instantiated keypad.</param>
    private void GetButtons(Transform obj)
    {
        Text display = obj.GetChild(0).GetComponentInChildren<Image>().GetComponentInChildren<Text>();
        int childCount = obj.GetChild(1).childCount;

        for (byte i = 0; i < childCount; i++)
        {
            byte currentIndex = i;
            _buttons[i] = obj.GetChild(1).GetChild(i).GetComponent<Button>();

            if (_buttons[i].name.ToUpper() == "CL")
            {
                _buttons[i].onClick.AddListener(() => display.text = string.Empty);
                
            }
            else if (_buttons[i].name.ToUpper() == "ENTER")
            {
                _buttons[i].onClick.AddListener(() => CheckResult(display.text));
            }
            else
            {
                _buttons[i].onClick.AddListener(() => display.text += _buttons[currentIndex].name);
            }
        }
    }

    /// <summary>
    /// Checks if the input of the player was correct.
    /// </summary>
    /// <param name="input">The user's input.</param>
    private void CheckResult(string input)
    {
        if (input == _password)
        {
            Debug.Log("Correct!");
            Object.Destroy(transform);
        }
        else
        {
            Debug.Log("False!");

            if (_numberOfTries < MAXNUMTRIES)
            {
                _numberOfTries++;
            }
            else
            {
                Debug.Log("YOU LOSE!");
                Object.Destroy(transform);
            }
        }
    }
}