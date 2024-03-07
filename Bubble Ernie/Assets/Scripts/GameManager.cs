using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }    //Singleton
    int gameplayTime;
    private float timeRemaining;
    public float TimeRemaining => timeRemaining;

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
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    IEnumerator GameplayCountdown()
    {
        float timeRemaining = gameplayTime;
        while (timeRemaining > 0)
        {
            //enviar valor a UI
            yield return new WaitForSeconds(1f);
            timeRemaining--;
        }
        // El temporizador termina, aqui ponemos los eventos del game over 
    }

    public void InitGame()
    {
        //esto se ejecuta cuando se le da a "Play"
        StartCoroutine(GameplayCountdown());
    }

    public void Pause()
    {

    }

    public void GameOver()
    {
        //Cerrar la puerta y que se inunde todo para que pierda el jugador
        Debug.Log("El jugador perdio");
    }

}
