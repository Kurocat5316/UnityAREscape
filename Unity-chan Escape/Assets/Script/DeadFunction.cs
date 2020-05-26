using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadFunction : MonoBehaviour
{
    TileManager manager;

    void Start()
    {
    }



    private void OnTriggerEnter(Collider other)
    {
        if (manager == null)
        {
            Debug.Log("We had no manager, so we are finding one.");
            manager = GameObject.Find("TieManager").GetComponent<TileManager>();
        }

        if (other.gameObject.tag == "Player")
        {
            manager.GameOver();
        }
    }
}
