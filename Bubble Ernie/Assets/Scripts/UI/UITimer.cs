using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UITimer : MonoBehaviour
{
    [SerializeField] private TMP_Text uiTimer;

    public void UpdateTimer()
    {
        uiTimer.text = "TIME LEFT " + GameManager.Instance.TimeRemaining + " s";
    }
}
