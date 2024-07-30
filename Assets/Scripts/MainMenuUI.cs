using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] AudioSource clickSound;
    int index;

    public void StartButton()
    {
        index = 2;
        StartCoroutine(WaitTime());
    }

    public void GuideButton()
    {
        index = 1;
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
