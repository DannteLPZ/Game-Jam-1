using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMainMenu : MonoBehaviour
{
    public void ItchPage(string url) => Application.OpenURL(url);

    public void PlayGame()
    {
        LevelLoader.instance.ChangeScene(1);
    }
}
