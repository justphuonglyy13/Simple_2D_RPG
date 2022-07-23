using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthBar : HealthBar
{
    private BossManager boss;
    private Transform healthBarTransform;

    private float maxHP;
    // Start is called before the first frame update
    protected override void Start() 
    {
        healthBarTransform = gameObject.GetComponent<Transform>();
        boss = gameObject.GetComponentInParent<BossManager>();
        maxHP = boss.HP;
        this.getHP((float) boss.HP, maxHP);
        base.Start();
        if (boss.IsFlipped == true) {
            healthBarTransform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else {
            healthBarTransform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    // Update is called once per frame
    protected override void Update()
    {
        this.getHP((float) boss.HP, maxHP);
        base.Update();   
        if (boss.IsFlipped == true) {
            healthBarTransform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else {
            healthBarTransform.localScale = new Vector3(1f, 1f, 1f);
        } 
    }
}
