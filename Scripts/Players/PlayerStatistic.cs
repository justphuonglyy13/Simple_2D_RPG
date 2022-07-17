using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PLAYER_STATE
{
    Idle,
    Walk,
    Attack,
    Dash,
}

public class PlayerStatistic : MonoBehaviour
{
    [SerializeField]
    private float _HP;
    public float HP { 
        get { return _HP; } 
        set { 
            if (value >= 100) {
                _HP = 100;
            } else {
                _HP = value;
            }
        } 
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
    public PlayerStatistic(float HP, float attack, float defense, float speed, int level, int exp) {
        this.HP = HP;
        this.Attack = attack;
        this.Defense = defense;
        this.Speed = speed;
        this.Level = level;
        this.Exp = exp;
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
