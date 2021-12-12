using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuranGenerator : MonoBehaviour
{

     public ObjectPooler Quranpooler;
    public void SpawnQuran(Vector3 startPosition)
    {
        GameObject coin1 = Quranpooler.GetPooledObject();
        coin1.transform.position = startPosition;
        coin1.SetActive(true);
    }
}


