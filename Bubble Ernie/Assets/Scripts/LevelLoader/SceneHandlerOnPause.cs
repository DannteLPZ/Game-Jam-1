using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneHandlerOnPause : MonoBehaviour
{
    public void ChangeScene(int scene)
    {
        LevelLoader.instance.ChangeScene(scene);
    }
}
