using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text scoreText;
	public Text highScoreText, pointTasbihText;

	public float scoreCount, poinCount;
	public float highScoreCount;

	public float pointsPerSecond;

	public bool scoreIncreasing;

	// Use this for initialization
	void Start () {
		if(PlayerPrefs.GetFloat("HighScore") != 0)
        {
            highScoreCount = PlayerPrefs.GetFloat("HighScore");
        }
		if(PlayerPrefs.GetFloat("Poin") != 0 ){
            poinCount = PlayerPrefs.GetFloat("Poin");
        }
	}
	
	// Update is called once per frame
	void Update () {

		if (scoreIncreasing) {
			scoreCount += pointsPerSecond * Time.deltaTime;
		} 
		if (scoreCount > highScoreCount) {
		
			highScoreCount = scoreCount;
			PlayerPrefs.SetFloat ("HighScore", highScoreCount);
		}

		
		pointTasbihText.text = "" + Mathf.Round(poinCount);

        scoreText.text = "" + Mathf.Round(scoreCount);
		PlayerPrefs.SetFloat("Score", scoreCount);

		highScoreText.text = "High Score : " + Mathf.Round(highScoreCount);
	}

	public void AddScore (int pointsToAdd){
        poinCount += pointsToAdd;
        PlayerPrefs.SetFloat("Poin", poinCount);
    }

	public float getScore()
    {
		scoreCount = PlayerPrefs.GetFloat("Score");
		return scoreCount;
	}
}
