using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fruit : MonoBehaviour
{
    private int score = 0;

    [SerializeField] private Text scoreText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("fruit"))
        {
            Destroy(collision.gameObject);
            score+=23;
            scoreText.text = "Score:" + score;
        }
    }
}
