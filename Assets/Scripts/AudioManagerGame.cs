using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerGame : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] AtelierUI atelier;

    [SerializeField] AudioSource gameMusic;
    [SerializeField] AudioSource gameOverMusic;
    [SerializeField] AudioSource gameVictoryMusic;

    bool playedOnce;

    // Update is called once per frame
    void Update()
    {
        if(gameManager.gameOver && !playedOnce) 
        {
            StartCoroutine(GameoverWaitTime());
        }

        if(atelier.gameWon && !playedOnce) 
        {
            StartCoroutine(VictoryWaitTime());
        }
    }

    IEnumerator VictoryWaitTime()
    {
        playedOnce = true;
        yield return new WaitForSeconds(2f);
        gameMusic.Stop();
        gameVictoryMusic.Play();
    }

    IEnumerator GameoverWaitTime()
    {
        playedOnce = true;
        yield return new WaitForSeconds(1f);
        gameMusic.Stop();
        gameOverMusic.Play();
    }
}
