using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryUI : MonoBehaviour
{
    [SerializeField] AudioSource clickSound;
    int index;

    public void RestartButton()
    {
        index = 2;
        StartCoroutine(WaitTime());
    }

    public void MainMenuButton()
    {
        index = 0;
        StartCoroutine(WaitTime());
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    IEnumerator WaitTime()
    {
        clickSound.Play();
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(index);
    }
}
