using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text ScoreValue;
    [SerializeField] private Text CoinsValue;
    [SerializeField] private Text LivesValue;

    private void Start()
    {
        ScoreValue.text = GameManager.instance.score.ToString();
        CoinsValue.text = GameManager.instance.coins.ToString();
        LivesValue.text = GameManager.instance.lives.ToString();
    }
}