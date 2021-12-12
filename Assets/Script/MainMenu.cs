using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour

{
    public string namaScene1;
    public string namaScene2;
    // Start is called before the first frame update
    public void PlayGame(){
        Scene sceneIni = SceneManager.GetActiveScene();
        
        if(sceneIni.name != namaScene1)
        {
            SceneManager.LoadScene(namaScene1);
        }
       
   }
    public void BackToMenu()
    {
        Scene sceneIni = SceneManager.GetActiveScene();

        if (sceneIni.name != namaScene2)
        {
            SceneManager.LoadScene(namaScene2);

        }

    }
    public void ContinueGame(){
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
       
   }

   public void QuitGame(){
       Debug.Log("Quit!"); 
       Application.Quit();
   }
}
