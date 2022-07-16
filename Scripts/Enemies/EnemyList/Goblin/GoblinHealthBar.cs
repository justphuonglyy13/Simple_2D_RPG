using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinHealthBar : HealthBar
{
    private GoblinManager goblin;
    private Transform healthBarTransform;
    // Start is called before the first frame update
    protected override void Start() 
    {
        healthBarTransform = gameObject.GetComponent<Transform>();
        goblin = gameObject.GetComponentInParent<GoblinManager>();
        this.getHP((float) goblin.HP, 20f);
        base.Start();
        if (goblin.IsFlipped == true) {
            healthBarTransform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else {
            healthBarTransform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    // Update is called once per frame
    protected override void Update()
    {
        this.getHP((float) goblin.HP, 20f);
        base.Update();   
        if (goblin.IsFlipped == true) {
            healthBarTransform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else {
            healthBarTransform.localScale = new Vector3(1f, 1f, 1f);
        } 
    }
}
