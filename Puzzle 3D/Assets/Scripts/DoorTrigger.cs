using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    float lerpTime = 1f;
    float currentLerpTime;

    float moveDistance = 4f;

    Vector3 startPos;
    Vector3 endPos;

    public GameObject door;

    public bool isOpen = false;

    private void Start()
    {
        startPos = door.transform.position;
        endPos = door.transform.position + transform.up * moveDistance;
    }

    private void Update()
    {
        /* currentLerpTime += Time.deltaTime;
         if (currentLerpTime > lerpTime)
         {
             currentLerpTime = 0f;
         }
         float perc = currentLerpTime / lerpTime;
         door.transform.position = Vector3.Lerp(startPos, endPos, perc);*/
    }
    void OnTriggerEnter(Collider other)
    {
        if (!isOpen)
        {

            isOpen = true;
            door.transform.position = door.transform.position - Vector3.down * 4; // door.transform.position += new Vector3(0, -4, 0);
            Debug.Log("Is Opening");

            /*currentLerpTime += Time.deltaTime;
        if (currentLerpTime > lerpTime)
        {
            currentLerpTime = 0f;
        }
        float perc = currentLerpTime / lerpTime;
        door.transform.position = Vector3.Lerp(startPos, endPos, perc);*/



        }
    }
    /*void OnTriggerStay(Collider other)
    {
        door.transform.position = door.transform.position - Vector3.down * 4;
        isOpen = true;
    }*/

    void OnTriggerExit(Collider other)
    {
        if (isOpen == true)
        {
            isOpen = false;
            door.transform.position = door.transform.position + Vector3.down * 4;
            Debug.Log("Is Closing");
        }

    }
}


