using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text scoreText;
	public Text highScoreText, pointTasbihText, quranText;

	public float scoreCount, poinCount, quranCount;
	public float highScoreCount;

	public float pointsPerSecond;

	public bool scoreIncreasing;

	public bool shouldDouble;

	// Use this for initialization
	void Start () {
		if(PlayerPrefs.GetFloat("HighScore") != 0)
        {
            highScoreCount = PlayerPrefs.GetFloat("HighScore");
        }
		if(PlayerPrefs.GetFloat("Poin") != 0 ){
            poinCount = PlayerPrefs.GetFloat("Poin");
        }
		if(PlayerPrefs.GetFloat("QuranLife") != 0)
        {
			quranCount = PlayerPrefs.GetFloat("QuranLife");
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
		quranText.text = "" + Mathf.Round(quranCount);

        scoreText.text = "" + Mathf.Round(scoreCount);
		PlayerPrefs.SetFloat("Score", scoreCount);

		highScoreText.text = "High Score : " + Mathf.Round(highScoreCount);
	}

	public void AddScore (int pointsToAdd){
		if(shouldDouble){
			pointsToAdd = pointsToAdd * 2;
		}
        poinCount += pointsToAdd;
        PlayerPrefs.SetFloat("Poin", poinCount);
    }
	public void AddQuranLife(int pointsToAdd)
	{
		quranCount += pointsToAdd;
		PlayerPrefs.SetFloat("QuranLife", quranCount);
	}

}
