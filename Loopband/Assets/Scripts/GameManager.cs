using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public Text ammoText;
  public Text scoreText;

	[SerializeField] private int ammo = 15;

	public int Ammo
	{
		get { return ammo; }
		set
		{
			ammo = value;
			ammoText.text = "Ammo: " + ammo.ToString();
		}
	}

  private int score = 0;

  public int Score
  {
    get { return score; }
    set
    {
      score = value;
      scoreText.text = "Score: " + score.ToString();
    }
  }
}
