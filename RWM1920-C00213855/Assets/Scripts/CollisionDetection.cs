using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public BombScript Bomb;
    public GameObject pp;
    private Vector3 originalPos;
    private void Start()
    {
        originalPos = pp.GetComponentInChildren<Transform>().position;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.gameObject.tag == "PressurePlate")
        {

            Debug.Log("Player collided with Pressure Plate");
            Bomb.SetActive(true);
            pp.GetComponent<AudioSource>().Play();
            Bomb.GetComponentInParent<Animator>().SetBool("Test", true);
            pp.GetComponentInChildren<Transform>().position -= new Vector3(0, 0.15f, 0);
        }


    }
}
