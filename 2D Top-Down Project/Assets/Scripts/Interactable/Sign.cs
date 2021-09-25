using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    public GameObject dialogBox;
    public GameObject question;
    public Text dialogText;
    public string dialog;
    public bool playerInRange;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Interact") && playerInRange)
        {
            if(dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
                question.SetActive(true);
            }
            else
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
                question.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            playerInRange = true;

            if (question.activeInHierarchy)
            {
                question.SetActive(false);
            }
            else
            {
                question.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            playerInRange = false;
            dialogBox.SetActive(false);
            question.SetActive(false);
        }
    }

}
