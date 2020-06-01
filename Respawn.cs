using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    Animator Anim;
    public void Start()
    {
        Anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnpoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        player.transform.position = respawnpoint.transform.position;
        //Anim.SetBool("Death", true);
    }

}
