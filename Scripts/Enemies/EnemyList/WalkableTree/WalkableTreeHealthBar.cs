using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkableTreeHealthBar : HealthBar
{
    private WalkableTree walkableTree;
    private Transform healthBarTransform;
    // Start is called before the first frame update
    protected override void Start() 
    {
        healthBarTransform = gameObject.GetComponent<Transform>();
        walkableTree = gameObject.GetComponentInParent<WalkableTreeManager>();
        this.getHP((float) walkableTree.HP, 20f);
        base.Start();
        if (walkableTree.IsFlipped == true) {
            healthBarTransform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else {
            healthBarTransform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    // Update is called once per frame
    protected override void Update()
    {
        this.getHP((float) walkableTree.HP, 20f);
        base.Update();   
        if (walkableTree.IsFlipped == true) {
            healthBarTransform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else {
            healthBarTransform.localScale = new Vector3(1f, 1f, 1f);
        } 
    }
}
