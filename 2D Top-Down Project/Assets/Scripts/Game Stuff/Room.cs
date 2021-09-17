using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public GameObject virtualCamera;

    public virtual void OnTriggerEnter2D(Collider2D collision)  
    {
        if(collision.CompareTag("Player") && !collision.isTrigger)
        {
            virtualCamera.SetActive(true);
        }
    }

    public virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            virtualCamera.SetActive(false);
        }
    }
}
