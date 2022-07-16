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

    // THE ENEMY'S POSITION
    protected Transform target;
    protected Rigidbody2D enemyRigidBody;

    //THE ENEMY
    [SerializeField] 
    private float chaseRadius;
    public float ChaseRadius
    {
        get { return chaseRadius; }
        set { chaseRadius = value; }
    }
    [SerializeField]
    private float attackRadius;
    public float AttackRadius
    {
        get { return attackRadius; }
        set { attackRadius = value; }
    }
    
    private Vector3 moveDirection;
    public Vector3 MoveDirection
    {
        get { return moveDirection; }
        set { moveDirection = value; }
    }

    // KNOCKBACK FORCE
    private float thurst;
    public float Thurst
    {
        get { return thurst; }
        set { thurst = value; }
    }

    private float lastMovingTime;
    public float LastMovingTime
    {
        get { return lastMovingTime; }
        set { lastMovingTime = value; }
    }
    private float currentTime;
    public float CurrentTime
    {
        get { return currentTime; }
        set { currentTime = value; }
    }
    private float lastAttackingTime;
    public float LastAttackingTime
    {
        get { return lastAttackingTime; }
        set { lastAttackingTime = value; }
    }
    private Vector2 difference;
    public Vector2 Difference
    {
        get { return difference; }
        set { difference = value; }
    }

    private bool canDealDamage = true;
    public bool CanDealDamage {
        get {return canDealDamage;}
        set {canDealDamage = value;}
    }

    private bool isFlipped = false;
    public bool IsFlipped {
        get {return isFlipped;}
        set {isFlipped = value;}
    }

    protected int randomIndex = new int();

    public EnemyStatistic(float HP, float attack, float defense, float speed)
    {
        this.HP = HP;
        this.Attack = attack;
        this.Defense = defense;
        this.Speed = speed;
    }
}
