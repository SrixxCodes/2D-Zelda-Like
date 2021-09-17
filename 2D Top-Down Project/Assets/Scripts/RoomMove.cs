using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomMove : MonoBehaviour
{
    public bool needText;
    public string placeName;
    public GameObject text;
    public Text placeText;
    public float waitTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (needText)
            {
                StartCoroutine(placeNameCo());
            }

        }
    }

    private IEnumerator placeNameCo()
    {
        text.SetActive(true);
        placeText.text = placeName;
        yield return new WaitForSeconds(waitTime);
        text.SetActive(false);
    }

}
