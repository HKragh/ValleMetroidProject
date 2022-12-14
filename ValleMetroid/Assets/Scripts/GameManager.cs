using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public enum GameState
{
    None = 0,
    Menu = 1,
    Play = 2,
    Death = 3,
    End = 4,
}

public class GameManager : MonoBehaviour
{
    public KeyCode reloadKey;

    public static GameManager instance;
    public GameState gameState;

    public AudioSource audioSource;
    public AudioSource loopableSource;
    public AudioSource healthPickupSource;

    public void Awake()
    {
        instance = this;
        double dspNow = AudioSettings.dspTime + 1;
        audioSource.PlayScheduled(dspNow);
        //StartCoroutine(PlayEngineSound());
        loopableSource.PlayScheduled(dspNow + audioSource.clip.length);
    }

    public void StartGame()
    {
        gameState = GameState.Play;

        //audioSource.Play();
    }

    public void Update()
    {
        if(Input.GetKeyDown(reloadKey))
        {
            SceneManager.LoadScene(1);
        }
    }

    public void HealthPickupSound()
    {
        healthPickupSource.Play();
    }

    public void ReloadGame()
    {
       gameState = GameState.Death;

       Invoke("ReloadNow", 3);
    }

    void ReloadNow()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}