using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitTrigger : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private PlayerPoints playerPoints;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(playerPoints.shadowEtherCount == 20 && playerPoints.etherCount == 10)
        {
            player.transform.position = new Vector3(-7, 0.2f, 0);
        }
    }
}
