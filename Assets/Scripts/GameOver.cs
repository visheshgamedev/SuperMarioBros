using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public float delay = 5f;
    private void Update()
    {
        ChangeSceneWithDelay();
    }

    public void ChangeSceneWithDelay()
    {
        StartCoroutine(ChangeSceneAfterDelay());
    }

    private IEnumerator ChangeSceneAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        GameManager.instance.NewGame();
    }
}