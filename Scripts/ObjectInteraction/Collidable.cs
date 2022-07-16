using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collidable : MonoBehaviour
{
    public ContactFilter2D contactFilter;
    public BoxCollider2D boxCollider;
    protected Collider2D[] hits = new Collider2D[10];

    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void Update()
    {
        boxCollider.OverlapCollider(contactFilter, hits);

        for (int i = 0; i < 10; i++)
        {
            if (hits[i] != null)
            {

                OnCollide(hits[i]);

                hits[i] = null;

            }
        }
    }

    protected virtual void OnCollide(Collider2D collider)
    {
        Debug.Log(collider.name);
    }
}
