using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public BombScript Bomb;
    public GameObject pp;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.gameObject.tag == "PressurePlate")
        {
            Debug.Log("Player collided with Pressure Plate");
            Bomb.SetActive(true);
            pp.GetComponent<AudioSource>().Play();
            Bomb.GetComponentInParent<Animator>().SetBool("Test", true);
        }
    }
}
