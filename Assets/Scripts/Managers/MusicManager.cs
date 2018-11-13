using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{

    public AudioClip mainTheme;
    public AudioClip menuTheme;

    int sceneID;

    void Start()
    {
        //OnSceneLoaded(0);
    }

    void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        int newSceneID = SceneManager.GetActiveScene().buildIndex;
        print("SCENE ID: " + sceneID);
        print("NEW SCENE ID: " + newSceneID);
        if (newSceneID != sceneID)
        {
            sceneID = newSceneID;
            Invoke("PlayMusic", .2f);
        }
        else {
            sceneID = newSceneID;
            Invoke("PlayMusic", .2f);
        }
    }

    void PlayMusic()
    {
        print("PLAY!");
        AudioClip clipToPlay = null;

        if (sceneID == 0)
        {
            clipToPlay = menuTheme;
        }
        else if (sceneID == 1)
        {
            clipToPlay = mainTheme;
        }

        if (clipToPlay != null)
        {
            AudioManager.instance.PlayMusic(clipToPlay, 2);
            Invoke("PlayMusic", clipToPlay.length);
        }

    }

    void OnDisable()
    {
        Debug.Log("OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

}
