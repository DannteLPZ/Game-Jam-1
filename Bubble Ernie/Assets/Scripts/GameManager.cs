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
    [SerializeField] private GameEvent onGameStart;
    [SerializeField] private GameEvent onGameResume;
    private int mainSceneID = 0;
    private int menuSceneID = 1;

    private bool isPause = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        gameplayTime = 120;
        StartCoroutine(GameplayCountdown());
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
            //Debug.Log(timeRemaining);
        }
    }

    public void InitGame()
    {
        SceneManager.LoadScene(mainSceneID);
        onGameStart.Invoke();
        StartCoroutine(GameplayCountdown());
    }

    public void Pause()
    {
        onGamePause.Invoke(); 
    }

    public void Resume()
    {
        onGameResume.Invoke(); 
    }

    public void GameOver()
    {
        //Cerrar la puerta y que se inunde todo para que pierda el jugador
        Debug.Log("El jugador perdio");
    }

}
