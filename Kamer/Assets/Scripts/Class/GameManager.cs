using UnityEngine;

[RequireComponent(typeof(UIManager))]
public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Gameobject on which the UIManager component is attached to.
    /// </summary>
    [SerializeField] private GameObject _UIReference;
    /// <summary>
    /// The amount of hours of gameplay.
    /// </summary>
    [Space(UIManager._SPACE)]
    [SerializeField] private int _hours;
    /// <summary>
    /// The amount of minuters of gameplay.
    /// </summary>
    [SerializeField] private int _minutes;
    /// <summary>
    /// The amount of seconds of gameplay.
    /// </summary>
    [SerializeField] private byte _seconds;

    /// <summary>
    /// Total amount of time in seconds.
    /// </summary>
    private int _time;

    private UIManager _uim;

    void Awake()
    {
        _uim = GetComponent<UIManager>();

        if(LevelManager.GetCurrentSceneName == Collections.Scenes.MenuScene.ToString())
        {
            _uim.ButtonSetup();
        }
    }

    // Use this for initialization
    void Start()
    {
        ComputeTimeInSeconds();
        _uim.Timer.text = string.Format("{0:00}:{1:00}:{2:00}", _hours, _minutes, _seconds);
    }

    // Update is called once per frame
    void Update()
    {
        CountDown();
    }

    /// <summary>
    /// Computes the total time in seconds.
    /// </summary>
    private void ComputeTimeInSeconds()
    {
        int hours, minutes;

        // compute the amount of seconds from the hours parameter
        // 1 hour = 3600 seconds
        hours = (_hours * 3600);

        // compute the amount of seconds from the minutes parameter
        minutes = (_minutes * 60);

        // compute the total amount of seconds 
        _time = (hours + minutes + _seconds);
    }

    /// <summary>
    /// Counts the timer down to zero.
    /// </summary>
    private void CountDown()
    {
        int passedTime;
        int hours = 0, minutes = 0, seconds = 0;

        passedTime = (int)(_time - Time.time);

        if (passedTime > 0)
        {
            // first compute the total amount of minutes from the given time
            minutes = (passedTime / 60);
            // compute from the minutes the amount of hours
            hours = (minutes / 60);

            #region Comment
            // the amount of minutes is then the amount of minutes subtracted by the amount of hours multiplied by 60
            // e.g. 121 minutes = 2 hours and 1 minute
            // we calculate the amount of hours from the minutes, which is 121 / 60 ~ 2
            // to get the rest of the minutes, we subtract the amount of minutes in the amount of hours from the total amount of minutes
            // --> 2 hours = 120 minutes; subtract this from 121, we get 1
            #endregion
            minutes = (minutes - (hours * 60));

            // the amount of seconds is the rest of the division of the total amount of seconds divided by 60
            seconds = (byte)(passedTime % 60);
        }

        // show the amount of time in the scene
        _uim.Timer.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
    }
}