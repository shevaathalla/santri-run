using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public ObjectPooler enemyPool;
    // Start is called before the first frame update
    public void SpawnEnemy(Vector3 startPosition)
    {
        GameObject coin1 = enemyPool.GetPooledObject();
        coin1.transform.position = startPosition;
        coin1.SetActive(true);
    }
}
