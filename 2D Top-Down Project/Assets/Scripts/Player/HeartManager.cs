using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;
    public FloatValue heartContainers;
    public FloatValue playerCurrentHealth;

    void Start()
    {
        InitHearts();
    }

    public void InitHearts()
    {
        for(int i = 0; i < heartContainers.initialValue; i ++)
        {
            hearts[i].gameObject.SetActive(true);
            hearts[i].sprite = fullHeart;
        } 
    }

    public void UpdateHearts()
    {
        float tempHealth = playerCurrentHealth.runTimeValue / 2;
        for (int i = 0; i < heartContainers.initialValue; i++)
        {
            if (i <= tempHealth - 1)
            {
                // Full Heart
                hearts[i].sprite = fullHeart;
            }
            else if (i >= tempHealth)
            {
                // Empty Heart
                hearts[i].sprite = emptyHeart;
            }
            else
            {
                // Half-Full Heart
                hearts[i].sprite = halfHeart;
            }
        }
    }

}
