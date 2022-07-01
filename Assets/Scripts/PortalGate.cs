using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PortalGate : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            
            if (collision.gameObject.GetComponent<PlayerMovement>().keyScore == 5)
            {
                SceneManager.LoadScene("Chapter 2");
            }
        }
    }
}
