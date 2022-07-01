using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Player"))
        {
            if (collision.gameObject.GetComponent<PlayerMovement>().life < 3)
            {
                collision.gameObject.GetComponent<PlayerMovement>().life++;
                Destroy(gameObject);
            }
            if (collision.gameObject.GetComponent<PlayerMovement>().life == 3)
            {
                 Destroy(gameObject);
            }
        }
    }
}
