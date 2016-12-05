using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public Text ammoText;
  public Text scoreText;

  private int normalScore = 5;
  private int score = 0;
  private ScoreBuffID currentScoreBuff = ScoreBuffID.normal;

  public int Score
  {
    get { return score; }
    set
    {
      score = value;
      scoreText.text = "Score: " + score.ToString();
    }
  }

  public void UpdateScore()
  {
    switch (currentScoreBuff)
    {
      case ScoreBuffID.normal:
        score += normalScore;
        break;
      case ScoreBuffID.doubleScore:
        score += (normalScore * 2);
        break;
      case ScoreBuffID.trippleScore:
        score += (normalScore * 3);
        break;
      case ScoreBuffID.bonusScore:
        break;
      default:
        break;
    }
  }
}
