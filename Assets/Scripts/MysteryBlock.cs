using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysteryBlock : MonoBehaviour
{
    [SerializeField] private Sprite emptyBlock;

    private AudioSource coinAudioSource;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        coinAudioSource = GetComponent<AudioSource>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && this.enabled == true)
        {
            GameManager.instance.AddScore(100);
            GameManager.instance.AddCoin();
            coinAudioSource.Play();
            gameObject.GetComponent<SpriteRenderer>().sprite = emptyBlock;
            this.enabled = false;
        }
    }
}