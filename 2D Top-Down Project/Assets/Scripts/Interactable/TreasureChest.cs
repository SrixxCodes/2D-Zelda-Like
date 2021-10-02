using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : Dialog
{
    public Item contents;
    public bool isOpen;
    public Inventory inventory;
    public Signals raiseItem;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact") && playerInRange)
        {
            if (!isOpen)
            {
                OpenChest();
            }
            else
            {
                ChestAlreadyOpen();
            }
        }
    }

    public void OpenChest()
    {
        // Dialog window on
        dialogBox.SetActive(true);
        // dialog text = context text
        dialogText.text = contents.itemDescription;
        // Add contents to the inventory
        inventory.AddItem(contents); 
        inventory.currentItem = contents;
        // Raise signal for player to animate
        raiseItem.Raise();
        // Raise context clue
        context.Raise();
        // Set chest to be opened
        isOpen = true;
        anim.SetBool("opened", true);
    }

    public void ChestAlreadyOpen()
    {
            // Dialog window off
            dialogBox.SetActive(false);
            // Raise signal to the player to stop
            raiseItem.Raise();
            playerInRange = false;
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger && !isOpen)
        {
            playerInRange = true;
            context.Raise();
        }
    }

    public override void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger && !isOpen)
        {
            playerInRange = false;
            context.Raise();
        }
    }

}
