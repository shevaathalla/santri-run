using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickuptasbih : MonoBehaviour
{
    public AudioClip pickUpSound;
    // Start is called before the first frame update
    public int scoreToGive;
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
            theScoreManager.AddScore(scoreToGive);
            gameObject.SetActive(false);
            AudioSource.PlayClipAtPoint(pickUpSound, transform.position);
            
        }
    }
}
