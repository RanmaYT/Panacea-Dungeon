using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AtelierUI : MonoBehaviour
{
    [SerializeField] PlayerPoints playerPoints;
    [SerializeField] TextMeshProUGUI atelierText;

    public bool gameWon;

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(playerPoints.etherCount == 10 && playerPoints.shadowEtherCount == 20)
        {
            atelierText.SetText("Thank you, I'll do the Panacea right away");
            gameWon = true;
        }
       else
        {
            atelierText.SetText("You must go to the dungeon collect ether!!");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        atelierText.SetText(""); 
    }
}
