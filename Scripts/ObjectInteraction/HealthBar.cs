using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    protected float hpPercent;
    protected Transform bar;
    private float _hpOfGameObject;
    public float HPOfGameObject { 
        get { return _hpOfGameObject; } 
        set { _hpOfGameObject = value; } 
    }

    private float _maxHpOfGameObject;
    public float MaxHPOfGameObject { 
        get { return _maxHpOfGameObject; } 
        set { _maxHpOfGameObject = value; } 
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        bar = transform.Find("Bar");
        hpPercent = (float) this.HPOfGameObject / (float) this.MaxHPOfGameObject;
        bar.localScale = new Vector3(hpPercent, 1f);
    }

    // Update is called once per frame
    protected virtual void Update()
    {   
        bar = transform.Find("Bar");
        hpPercent = (float) this.HPOfGameObject / (float) this.MaxHPOfGameObject;
        bar.localScale = new Vector3(hpPercent, 1f);
    }

    public void getHP(float hp, float maxHP) {
        this.HPOfGameObject = hp;
        this.MaxHPOfGameObject = maxHP;
    }
}
