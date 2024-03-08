using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }    //Singleton
    int gameplayTime;
    private float timeRemaining;
    public float TimeRemaining => timeRemaining;
    [SerializeField] private GameEvent onTimerUpdate;
    [SerializeField] private GameEvent onGamePause;
    [SerializeField] private GameEvent onGameResume;
    [SerializeField] private GameEvent onLoseGame;

    private bool isPause = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }

    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPause)
            {
                isPause = true;
                Pause();
            }
            else if (isPause) {
                isPause = false;
                Resume();
            }
            
        }
    }

    IEnumerator GameplayCountdown()
    {
        timeRemaining = gameplayTime;
        while (timeRemaining > 0)
        {
            yield return new WaitForSeconds(1f);
            timeRemaining--;
            onTimerUpdate.Invoke();
            if (timeRemaining < 1)
            {
                Time.timeScale = 0.0f;
                onLoseGame.Invoke();
            } 
        }
    }

    public void InitGame()
    {
        StopAllCoroutines();
        gameplayTime = 150;
        StartCoroutine(GameplayCountdown());
    }

    public void Pause()
    {
        Time.timeScale = 0.0f;
        onGamePause.Invoke(); 
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        onGameResume.Invoke(); 
    }

    public void GameOver()
    {
        //Cerrar la puerta y que se inunde todo para que pierda el jugador
        Debug.Log("El jugador perdio");
    }

}
