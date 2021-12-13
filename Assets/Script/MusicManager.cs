using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; set; }

    public AudioSource backsound;
    // Start is called before the first frame update

    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonInGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ButtonMusicMute()
    {
        if (backsound.mute == false)
        {
            backsound.mute = true;
        }
        else
        {
            backsound.mute =false;
        }
    }
}
