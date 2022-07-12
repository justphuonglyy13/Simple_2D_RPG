using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ENEMY_STATE
{
    Idle,
    Walk,
    Attack,
}

public class EnemyStatistic : MonoBehaviour
{
    [SerializeField]
    private float _HP;
    public float HP
    {
        get { return _HP; }
        set
        {
            if (value >= 20f)
            {
                _HP = 20f;
            }
            else
            {
                _HP = value;
            }
        }
    }

    private float _attack;
    public float Attack
    {
        get { return _attack; }
        set { _attack = value; }
    }

    private float _defense;
    public float Defense
    {
        get { return _defense; }
        set { _defense = value; }
    }

    private float _speed;
    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    public EnemyStatistic(float HP, float attack, float defense, float speed)
    {
        this.HP = HP;
        this.Attack = attack;
        this.Defense = defense;
        this.Speed = speed;
    }
}
