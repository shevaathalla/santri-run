using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public ObjectPooler coinPool;
    public float distanceBetweenTasbih;
    
    public void SpawnCoins (Vector3 startPosition){
        GameObject coin1 =  coinPool.GetPooledObject();
        coin1.transform.position = startPosition;
        coin1.SetActive(true); 

        GameObject coin2 =  coinPool.GetPooledObject();
        coin2.transform.position = new Vector3 (startPosition.x - distanceBetweenTasbih, startPosition.y-1f, startPosition.z);
        coin2.SetActive(true); 

        GameObject coin3 =  coinPool.GetPooledObject();
        coin3.transform.position = new Vector3 (startPosition.x + distanceBetweenTasbih, startPosition.y-1f, startPosition.z);
        coin3.SetActive(true); 
    }
}
