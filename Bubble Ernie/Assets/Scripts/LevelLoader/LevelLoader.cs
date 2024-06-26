using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Animator transitions;

    public static LevelLoader instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ChangeScene(int buildIndex)
    {
        StartCoroutine(LoadLevelCoroutine(buildIndex));
    }

    private IEnumerator LoadLevelCoroutine(int buildIndex)
    {
        transitions.SetTrigger("End");
        GameManager.Instance.Resume();
        yield return new WaitForSecondsRealtime(1.0f);
        SceneManager.LoadSceneAsync(buildIndex);
        transitions.SetTrigger("Start");
        if (buildIndex == 1) 
        {
            GameManager.Instance.InitGame();
        }  
    }

}
