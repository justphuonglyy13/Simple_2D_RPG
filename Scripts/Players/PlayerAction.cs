using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PlayerAction 
{
    public void MovingPlayer();

    public void AnimatingPlayer();

    public IEnumerator Attacking();

    public void LevelUp();

    public void CheckingHP();

    public IEnumerator SpecialAttacking();

}
