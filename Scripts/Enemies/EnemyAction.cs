using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface EnemyAction
{
    public void AutoMoving();
    public bool CheckingDistance();
    public void Attacking();
    public int SpecialAttacking();
    public float CheckingHP();
}
