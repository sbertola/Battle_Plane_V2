using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public int hp = 3;
    [SerializeField] public int moves = 1;
    [SerializeField] public int unitNum = 0;

    public int GetHealth()
    {
        return hp;
    }

    public int GetMoves()
    {
        return moves;
    }

    public void TakeDamage(int dmg)
    {
        this.hp -= dmg;

        CheckIfDead();
    }

    private void CheckIfDead()
    {
        if(this.hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
