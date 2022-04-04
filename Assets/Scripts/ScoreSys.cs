using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSys : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Score")
        {
            GamesManager.score += 1;
            Debug.Log("<color=red>Trigger enter</color>");
            collision.gameObject.GetComponent<EdgeCollider2D>().enabled = false;
            collision.gameObject.GetComponent<ChangeRing>().ispassed = true;
        }
    }
}
