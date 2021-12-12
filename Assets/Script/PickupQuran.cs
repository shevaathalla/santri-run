using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupQuran : MonoBehaviour
{
    // Start is called before the first frame update
    public int Quranpoint;
    private ScoreManager theScoreManager;   
    void Start()
    {
        theScoreManager = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.name == "Pemain"){
            theScoreManager.AddQuranLife(Quranpoint);
            gameObject.SetActive(false);
        }
    }
}
