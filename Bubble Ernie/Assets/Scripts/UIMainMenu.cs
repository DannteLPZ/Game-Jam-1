using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMainMenu : MonoBehaviour
{
    public void ItchPage() => Application.OpenURL("https://dannte9804.itch.io/");

    public void PlayGame()
    {
        LevelLoader.instance.ChangeScene(1);
    }
}
