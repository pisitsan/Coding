using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public bool resetable;
    public GameObject door;
    public bool startOpen;

    bool firstTrigger = false;
    bool open = false;
    Animator doorAnim;

    // Start is called before the first frame update
    void Start()
    {
        doorAnim = door.GetComponent<Animator>();

        if(!startOpen)
        {
            open = true;
            doorAnim.SetTrigger("doorTrigger");

        }
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !firstTrigger)
        {
            if (!resetable) firstTrigger = true;
            doorAnim.SetTrigger("doorTrigger");
            open = !open;
        }
    }
}
