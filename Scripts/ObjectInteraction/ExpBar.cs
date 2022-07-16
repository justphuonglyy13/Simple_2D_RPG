using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpBar : MonoBehaviour
{
    protected float hpPercent;
    protected Transform bar;
    private float _expOfGameObject;
    public float ExpOfGameObject { 
        get { return _expOfGameObject; } 
        set { _expOfGameObject = value; } 
    }

    private float _maxExpOfGameObject;
    public float MaxExpOfGameObject { 
        get { return _maxExpOfGameObject; } 
        set { _maxExpOfGameObject = value; } 
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        bar = transform.Find("Bar");
        hpPercent = (float) this.ExpOfGameObject / (float) this.MaxExpOfGameObject;
        bar.localScale = new Vector3(hpPercent, 1f);
    }

    // Update is called once per frame
    protected virtual void Update()
    {   
        bar = transform.Find("Bar");
        hpPercent = (float) this.ExpOfGameObject / (float) this.MaxExpOfGameObject;
        bar.localScale = new Vector3(hpPercent, 1f);
    }

    public void getEXP(float exp, float maxExp) {
        this.ExpOfGameObject = exp;
        this.MaxExpOfGameObject = maxExp;
    }
}
