using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleBotHealthBar : HealthBar
{
    private SampleBotManager sampleBot;
    private Transform healthBarTransform;
    // Start is called before the first frame update
    protected override void Start() 
    {
        healthBarTransform = gameObject.GetComponent<Transform>();
        sampleBot = gameObject.GetComponentInParent<SampleBotManager>();
        this.getHP((float) sampleBot.HP, 20f);
        base.Start();
        if (sampleBot.IsFlipped == true) {
            healthBarTransform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else {
            healthBarTransform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    // Update is called once per frame
    protected override void Update()
    {
        this.getHP((float) sampleBot.HP, 20f);
        base.Update();   
        if (sampleBot.IsFlipped == true) {
            healthBarTransform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else {
            healthBarTransform.localScale = new Vector3(1f, 1f, 1f);
        } 
    }
}
