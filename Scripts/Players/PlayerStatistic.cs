using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PLAYER_STATE
{
    Idle,
    Walk,
    Attack,
    Dash,
    Invulnerable
}

public class PlayerStatistic : MonoBehaviour
{
    [SerializeField]
    private float _HP;
    public float HP { 
        get { return _HP; } 
        set { _HP = value; } 
    }

    [SerializeField]
    private float _stamina;
    public float Stamina { 
        get { return _stamina; } 
        set { _stamina = value; } 
    }

    [SerializeField]
    private float _attack;
    public float Attack { 
        get { return _attack; } 
        set { _attack = value; } 
    }

    [SerializeField]
    private float _defense;
    public float Defense { 
        get { return _defense; } 
        set { _defense = value; } 
    }

    [SerializeField]
    private float _speed;
    public float Speed { 
        get { return _speed; } 
        set { _speed = value; } 
    }

    [SerializeField]
    private int _level;
    public int Level { 
        get { return _level; } 
        set { _level = value; } 
    }

    [SerializeField]
    private int _exp;
    public int Exp { 
        get { return _exp; } 
        set { _exp = value; } 
    }

    [SerializeField]
    private int _gold;
    public int Gold { 
        get { return _gold; } 
        set { _gold = value; } 
    }

    [SerializeField]
    public PlayerStatistic() {
        this.HP = 100;
        this.Stamina = 100;
        this.Attack = 5;
        this.Defense = 5;
        this.Speed = 5;
        this.Gold = 0;
        this.Exp = 0;
        this.Level = 1;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
