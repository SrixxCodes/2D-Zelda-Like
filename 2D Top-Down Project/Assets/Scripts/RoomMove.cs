using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomMove : MonoBehaviour
{
    public Vector2 cameraMinChange;
    public Vector2 cameraMaxChange;
    public Vector3 playerChange;
    private CameraMovement cam;
    public bool needText;
    public string placeName;
    public GameObject text;
    public Text placeText;


    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cam.minPos += cameraMinChange;
            cam.maxPos += cameraMaxChange;
            collision.transform.position += playerChange;
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
        yield return new WaitForSeconds(4f);
        text.SetActive(false);
    }

}
