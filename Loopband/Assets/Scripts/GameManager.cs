using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public Text ammoText;
  public Text scoreText;
  public bool useAmmo = true;

	[SerializeField] private int ammo = 750;

	public int Ammo
	{
		get { return ammo; }
		set
		{
      if (useAmmo)
      {
        ammo = value;
        ammoText.text = "Ammo: " + ammo.ToString();
      }
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
