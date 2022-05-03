using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    private float waitForSeconds = 2f;

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAfterDie());
    }

    public void Quit()
    {
        Application.Quit();
    }

    private IEnumerator WaitAfterDie()
    {
        yield return new WaitForSeconds(waitForSeconds);
        SceneManager.LoadScene("Game Over");
    }
}
