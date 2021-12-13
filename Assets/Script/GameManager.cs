using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public Transform groundGenerator;
	private Vector3 groundStartPoint;

	public PlayerController thePlayer;
	private Vector3 playerStartPoint;

	private GroundDestroyer[] groundList;

	private ScoreManager theScoreManager;

	public GameObject gameOverMenu;

	public string namaScene;

	public AudioSource backsound;
	public GameObject sound;


	// Use this for initialization
	void Start () {
		groundStartPoint = groundGenerator.position;
		playerStartPoint = thePlayer.transform.position;

		theScoreManager = FindObjectOfType<ScoreManager> ();
	}

	public void BackSoundOn()
    {
		sound.SetActive(true);
		backsound.Play();
    }
	
	public void BackSoundOff()
    {
		sound.SetActive(false);
		backsound.Stop();
    }
	// Update is called once per frame
	void Update () {
		
	}

	public void RestartGame(){
		theScoreManager.scoreIncreasing = false;
		thePlayer.gameObject.SetActive(false);
		//StartCoroutine ("RestartGameCo");

		gameOverMenu.SetActive(true);

		//Scene sceneIni = SceneManager.GetActiveScene();

		//if (sceneIni.name != namaScene)
		//{
		//	SceneManager.LoadScene(namaScene);
		//}
	}

    public void Reset()
    {
		groundList = FindObjectsOfType<GroundDestroyer>();
		for (int i = 0; i < groundList.Length; i++)
		{

			groundList[i].gameObject.SetActive(false);
		}

		thePlayer.transform.position = playerStartPoint;
		groundGenerator.position = groundStartPoint;
		thePlayer.gameObject.SetActive(true);

		theScoreManager.scoreCount = 0;
		theScoreManager.scoreIncreasing = true;
		gameOverMenu.SetActive(false);
	}

 //   public IEnumerator RestartGameCo(){
	
	//	theScoreManager.scoreIncreasing = false;
	//	thePlayer.gameObject.SetActive (false);
	//	yield return new WaitForSeconds (0.5f);
	//	groundList = FindObjectsOfType<GroundDestroyer> ();
	//	for(int i = 0; i < groundList.Length; i++){

	//		groundList[i].gameObject.SetActive(false);
	//	}

	//	thePlayer.transform.position = playerStartPoint;
	//	groundGenerator.position = groundStartPoint;
	//	thePlayer.gameObject.SetActive (true);

	//	theScoreManager.scoreCount = 0;
	//	theScoreManager.scoreIncreasing = true;
	//}
}
