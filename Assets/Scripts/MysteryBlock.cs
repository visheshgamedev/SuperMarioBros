using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysteryBlock : MonoBehaviour
{
    [SerializeField] private Sprite emptyBlock;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.AddScore(100);
            GameManager.instance.AddCoin();
            gameObject.GetComponent<SpriteRenderer>().sprite = emptyBlock;
        }
    }
}