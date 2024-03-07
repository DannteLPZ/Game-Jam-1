using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UILives : MonoBehaviour
{
    [SerializeField] private Sprite[] hearths;
    [SerializeField] private Image[] livesImageDisplay;
    [SerializeField] private PlayerController player;

    public void UpdateLives()
    {
        int lives = player.CurrentHealth;

        switch (lives)
        {
            case 3:
                foreach (Image images in livesImageDisplay)
                {
                    images.sprite = hearths[1];
                }
            break;

            case 2:
                livesImageDisplay[lives].sprite = hearths[0];
                for (int i = 0; i < lives; i++)
                {
                    livesImageDisplay[i].sprite = hearths[1];
                }

                break;

            case 1:
                livesImageDisplay[lives].sprite = hearths[0];
                for (int i = 0; i < lives; i++)
                {
                    livesImageDisplay[i].sprite = hearths[1];
                }
                break;
            
            case 0:
                livesImageDisplay[lives].sprite = hearths[0];
                for (int i = 0; i < lives; i++)
                {
                    livesImageDisplay[i].sprite = hearths[1];
                }
                break;
        }   
    }
}