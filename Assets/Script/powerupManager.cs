using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerupManager : MonoBehaviour
{
    
    private bool doublePoints;
    // private bool safeMode;

    private bool powerupActive;
    private float powwerupLengthCounter;

    private ScoreManager theScoreManager;
    
    private float normalPointsPerSecond;
    

    // Start is called before the first frame update
    void Start()
    {
       theScoreManager = FindObjectOfType<ScoreManager>();

    }

    // Update is called once per frame
    void Update()
    {

        if(powerupActive){
            powwerupLengthCounter -= Time.deltaTime;

            if(doublePoints){
                theScoreManager.pointsPerSecond = normalPointsPerSecond * 2f; 
                theScoreManager.shouldDouble = true;
            }

            if(powwerupLengthCounter <= 0){

                theScoreManager.pointsPerSecond = normalPointsPerSecond;
                
                theScoreManager.shouldDouble = false;

                powerupActive = false;
            }
        }
        
    }
    public void ActivePowerup(bool points, float time){
        doublePoints = points;
        powwerupLengthCounter = time;

        normalPointsPerSecond = theScoreManager.pointsPerSecond;

        powerupActive = true;

    }
    
}
