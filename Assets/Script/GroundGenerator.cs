using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour {

	public GameObject theGround;
	public Transform generationPoint;
	public float distanceBetween;

	private float groundWidth;

	public float distanceBetweenMin;
	public float distanceBetweenMax;

	//public GameObject[] theGrounds;
	private int groundSelector;
	private float[] groundWidths;

	public ObjectPooler[] theObjectPools;

	private float minHeight;
	public Transform maxHeightPoint;
	private float maxHeight;
	public float maxHeightChange;
	private float heightChange;

	private CoinGenerator theCoinGenerataor;
	public float randomCoinThresshold;

	private EnemyGenerator theEnemyGenerator;
	public float randomEnemyThresshold;

	private QuranGenerator theQuranGenerator;
	public float randomQuranThresshold;
	// Use this for initialization
	void Start () {
		//groundWidth = theGround.GetComponent<BoxCollider2D> ().size.x;	

		groundWidths = new float[theObjectPools.Length];

		for (int i = 0; i < theObjectPools.Length; i++) {
		
			groundWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D> ().size.x;	
		
		}

		minHeight = transform.position.y;
		maxHeight = maxHeightPoint.position.y;

		theCoinGenerataor = FindObjectOfType<CoinGenerator>();
		theEnemyGenerator = FindObjectOfType<EnemyGenerator>();
		theQuranGenerator = FindObjectOfType<QuranGenerator>();
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.x < generationPoint.position.x) {

			distanceBetween = Random.Range (distanceBetweenMin, distanceBetweenMax);

			groundSelector = Random.Range (0, theObjectPools.Length);
		
			heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);

			if (heightChange > maxHeight) {
			
				heightChange = maxHeight;
			} else if (heightChange < minHeight) {
			

				heightChange = minHeight;
			
			}

			transform.position = new Vector3 (transform.position.x + (groundWidths[groundSelector] / 2) + distanceBetween, heightChange, transform.position.z);



			//Instantiate (/*theGround*/ theGrounds[groundSelector], transform.position, transform.rotation);

			GameObject newGround =  theObjectPools[groundSelector].GetPooledObject ();
		
			newGround.transform.position = transform.position;
			newGround.transform.rotation = transform.rotation;
			newGround.SetActive (true);


			if(Random.Range(0f,100f)<randomCoinThresshold){
				theCoinGenerataor.SpawnCoins(new Vector3(transform.position.x, transform.position.y + Random.Range(2f,3f), transform.position.z ));
			}

			if (Random.Range(0f, 100f) < randomEnemyThresshold)
			{
				theEnemyGenerator.SpawnEnemy(new Vector3(transform.position.x+Random.Range(0.5f,1.5f), transform.position.y + 1f, transform.position.z));
			}
			if (Random.Range(0f, 100f) < randomQuranThresshold)
			{
				theQuranGenerator.SpawnQuran(new Vector3(transform.position.x, transform.position.y + Random.Range(3f,4f), transform.position.z));
			}


			transform.position = new Vector3 (transform.position.x + (groundWidths[groundSelector] / 2), transform.position.y, transform.position.z);

			
			
		}

	}
}