using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject victoryScreen;

    [SerializeField] AtelierUI atelier;
    [SerializeField] PlayerHealth playerHealth;

    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        gameOverScreen.SetActive(false);
        victoryScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth.health <= 0)
        {
            gameOver = true;
            StartCoroutine(GameOverScreenShow());
        }

        if(atelier.gameWon)
        {
            StartCoroutine(Victory());
        }
    }

    IEnumerator GameOverScreenShow()
    {
        yield return new WaitForSeconds(1f);
        gameOverScreen.SetActive(true);
    }

    IEnumerator Victory()
    {
        yield return new WaitForSeconds(2f);
        victoryScreen.SetActive(true);
    }
}
