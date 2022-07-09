using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PlayerAttack
{
    public IEnumerator Attacking();
    
    public IEnumerator SpecialAttacking();
}
