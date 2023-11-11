using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundButton : MonoBehaviour
{
    public GameObject[] Activate;

    bool Activated = false;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && Activated == false)
        {
            GetComponent<Animator>().Play("Activate");

            for (int i = 0; i < Activate.Length; i++)
            {
                Activate[i].GetComponent<Animator>().Play("Activate");
            }
        }
    }

}
