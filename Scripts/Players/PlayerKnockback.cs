using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKnockback : MonoBehaviour
{
    [SerializeField]
    private float thrust;
    [SerializeField]
    private float knockBackTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.CompareTag("Enemy")) {
            Rigidbody2D enemy = collider.gameObject.GetComponent<Rigidbody2D>();

            if (enemy != null) {    
                Vector2 difference = (enemy.transform.position - transform.position).normalized * thrust;
                enemy.AddForce(difference, ForceMode2D.Impulse);
                StartCoroutine(KnockCoroutine(enemy));
            }
        }
    } 

    private IEnumerator KnockCoroutine(Rigidbody2D enemy) {
        if (enemy != null) {
            yield return new WaitForSeconds(knockBackTime);
            enemy.velocity = Vector2.zero;
        }
    }
}
