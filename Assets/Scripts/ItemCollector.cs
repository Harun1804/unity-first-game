using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int fruits = 0;
    [SerializeField] private Text scoreText;
    [SerializeField] private AudioSource collectSfx;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fruit"))
        {
            collectSfx.Play();
            Destroy(collision.gameObject);
            fruits++;
            scoreText.text = "Scores : "+fruits;
        }      
    }
}
