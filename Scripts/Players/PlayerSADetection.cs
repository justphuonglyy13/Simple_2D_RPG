using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSADetection: MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision) {       
        Destroy(this.gameObject);
    }
    
}
