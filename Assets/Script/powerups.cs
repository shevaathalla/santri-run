using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerups : MonoBehaviour
{
    // Start is called before the first frame update
    public bool doublePoints;
    // public bool safeMode;

    public float powerupLength;
    public AudioClip pickUpSound;
    
    private powerupManager thePowerUpManager;
    void Start()
    {
         thePowerUpManager = FindObjectOfType<powerupManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


     void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.name == "Pemain"){
            thePowerUpManager.ActivePowerup(doublePoints, powerupLength);
            AudioSource.PlayClipAtPoint(pickUpSound, transform.position);
            gameObject.SetActive(false);
        }
    }
}
