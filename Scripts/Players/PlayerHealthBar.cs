using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBar : HealthBar
{
    // Start is called before the first frame update
    protected override void Start()
    {
        this.getHP((float) PlayerManager.player.HP, 100f);
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        this.getHP((float) PlayerManager.player.HP, 100f);
        base.Update();
    }
}
