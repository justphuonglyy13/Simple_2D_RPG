using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExpBar : ExpBar
{
    // Start is called before the first frame update
    protected override void Start()
    {
        this.getEXP((float) PlayerManager.player.Exp, (float) (5 + (5 * (PlayerManager.player.Level - 1))));
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        this.getEXP((float) PlayerManager.player.Exp, (float) (5 + (5 * (PlayerManager.player.Level - 1))));
        base.Update();
    }
}
