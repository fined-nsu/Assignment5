using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWords : MonoBehaviour
{
    WordDisplay display;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Word")
        {
            Debug.Log("Destroying: " + collision.gameObject.name);
            //Destroy(collision.gameObject);

        }
    }
}
