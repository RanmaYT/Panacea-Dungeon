using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] EnemyCollision enemyCol;
    [SerializeField] SpriteRenderer enemySR;
    [SerializeField] Animator enemyAnim;

    private Transform target;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        enemyAnim.SetBool("AfterPlayer", enemyCol.afterPlayer);
        if(target != null)
        {
            Flip();
        }
    }

    void Flip()
    {
        Vector2 movePos = target.position - transform.position;

        if(movePos.x > 0)
        {
            enemySR.flipX = true;
        }

        else
        {
            enemySR.flipX = false;
        }
    }
}
