using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleBot : EnemyStatistic, EnemyAction
{
    // THE ENEMY'S POSITION
    public Transform target;
    public Rigidbody2D enemyRigidBody;

    //THE ENEMY 
    public float chaseRadius;
    public float attackRadius;
    
    public Vector3 moveDirection;

    private float thurst = 8f;

    public float lastMovingTime;
    public float currentTime;
    public float lastAttackingTime;
    private Vector2 difference;

    private bool canDealDamage = true;

    public int randomIndex = new int();


    public SampleBot()
    {
        this.HP = 20;
        this.Attack = 8;
        this.Defense = 0;
        this.Speed = 3;
    }

    // Start is called before the first frame update
    void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = Time.time;

        if (this.CheckingDistance())
        {
            Vector3 direction = (target.position - transform.position);
            moveDirection = direction.normalized;
        }
        else
        {
            this.AutoMoving();

            //StartCoroutine(this.Attacking());
        }

        if (this.currentTime - this.lastAttackingTime >= 0.3333334f) {
            alreadyHasBeenCollided = false;
        }
    }

    void FixedUpdate()
    {
        if (alreadyHasBeenCollided == true) {
            enemyRigidBody.velocity = Vector2.zero;
            enemyRigidBody.AddForce(difference * thurst, ForceMode2D.Impulse);
            canDealDamage = false;
        } else {
            enemyRigidBody.velocity = moveDirection * Speed;
        }
    }

    public void AutoMoving()
    {
        // Vector3 botPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        if (lastMovingTime == 0f)
        {
            lastMovingTime = Time.time;
        }

        if (currentTime - lastMovingTime >= 1.5f || lastMovingTime == currentTime)
        {
            randomIndex = Random.Range(1, 17);      //Index random in the range from 1 to 16 (Integer)
            lastMovingTime = Time.time;
        }

        switch (randomIndex)
        {
            // Alpha = Pi       (Pi = 3.1415926)
            case 1:
                moveDirection = new Vector3(-1, 0, 0).normalized;
                transform.localScale = new Vector3(-1, 1, 1);
                break;
            // Alpha = 0        (Pi = 3.1415926)
            case 2:
                moveDirection = new Vector3(1, 0, 0).normalized;
                transform.localScale = new Vector3(1, 1, 1);
                break;
            // Alpha = Pi / 2   (Pi = 3.1415926)
            case 3:
                moveDirection = new Vector3(0, 1, 0).normalized;
                transform.localScale = new Vector3(1, 1, 1);
                break;
            // Alpha = -Pi / 2  (Pi = 3.1415926)
            case 4:
                moveDirection = new Vector3(0, -1, 0).normalized;
                transform.localScale = new Vector3(1, 1, 1);
                break;
            // Alpha = 3Pi / 4  (Pi = 3.1415926)
            case 5:
                moveDirection = new Vector3(-Mathf.Sqrt(1), Mathf.Sqrt(1), 0).normalized;
                transform.localScale = new Vector3(-1, 1, 1);
                break;
            // Alpha = -Pi / 4  (Pi = 3.1415926)
            case 6:
                moveDirection = new Vector3(Mathf.Sqrt(1), -Mathf.Sqrt(1), 0).normalized;
                transform.localScale = new Vector3(1, 1, 1);
                break;
            // Alpha = -3Pi / 4 (Pi = 3.1415926)
            case 7:
                moveDirection = new Vector3(-Mathf.Sqrt(1), -Mathf.Sqrt(1), 0).normalized;
                transform.localScale = new Vector3(-1, 1, 1);
                break;
            // Alpha = Pi / 4   (Pi = 3.1415926)
            case 8:
                moveDirection = new Vector3(Mathf.Sqrt(1), Mathf.Sqrt(1), 0).normalized;
                transform.localScale = new Vector3(1, 1, 1);
                break;
            // Alpha = Pi / 6   (Pi = 3.1415926)
            case 9:
                moveDirection = new Vector3((Mathf.Sqrt(3) / 2), (1 / 2), 0).normalized;
                transform.localScale = new Vector3(1, 1, 1);
                break;
            // Alpha = Pi / 3   (Pi = 3.1415926)
            case 10:
                moveDirection = new Vector3((1 / 2), (Mathf.Sqrt(3) / 2), 0).normalized;
                transform.localScale = new Vector3(1, 1, 1);
                break;
            // Alpha = 2Pi / 3  (Pi = 3.1415926)
            case 11:
                moveDirection = new Vector3(-(1 / 2), (Mathf.Sqrt(3) / 2), 0).normalized;
                transform.localScale = new Vector3(-1, 1, 1);
                break;
            // Alpha = 5Pi / 6  (Pi = 3.1415926)
            case 12:
                moveDirection = new Vector3(-(Mathf.Sqrt(3) / 2), (1 / 2), 0).normalized;
                transform.localScale = new Vector3(-1, 1, 1);
                break;
            // Alpha = -5Pi / 6 (Pi = 3.1415926)
            case 13:
                moveDirection = new Vector3(-(Mathf.Sqrt(3) / 2), -(1 / 2), 0).normalized;
                transform.localScale = new Vector3(-1, 1, 1);
                break;
            // Alpha = -2Pi / 3 (Pi = 3.1415926)
            case 14:
                moveDirection = new Vector3(-(1 / 2), -(Mathf.Sqrt(3) / 2), 0).normalized;
                transform.localScale = new Vector3(-1, 1, 1);
                break;
            // Alpha = -Pi / 3  (Pi = 3.1415926)
            case 15:
                moveDirection = new Vector3((1 / 2), -(Mathf.Sqrt(3) / 2), 0).normalized;
                transform.localScale = new Vector3(1, 1, 1);
                break;
            // Alpha = -Pi / 6  (Pi = 3.1415926)
            case 16:
                moveDirection = new Vector3((Mathf.Sqrt(3) / 2), -(1 / 2), 0).normalized;
                transform.localScale = new Vector3(1, 1, 1);
                break;
            default:
                Debug.Log("Enemy's auto-moving Engine doesn't work properly");
                break;
        }
    }


    public bool CheckingDistance()
    {
        if (Vector3.Distance(transform.position, target.position) <= chaseRadius && Vector3.Distance(transform.position, target.position) > attackRadius)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // DETECT IF THE ENEMY IS ATTACKED BY THE PLAYER
    public bool alreadyHasBeenCollided = false;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player Attack"))
        {
            if (alreadyHasBeenCollided == false)
            {
                alreadyHasBeenCollided = true;
                difference = new Vector2(transform.position.x - PlayerManager.player.transform.position.x, transform.position.y - PlayerManager.player.transform.position.y);

                this.HP -= (PlayerManager.player.Attack - this.Defense);
                Debug.Log("You've dealing [" + (PlayerManager.player.Attack - this.Defense) + "] DMG to the enemy!!!");
                this.CheckingHP();
                this.lastAttackingTime = Time.time;      
            }
        }
    }

    // ATTACK PATTERN OF THE ENEMY
    public void Attacking()
    {
        // if (Vector3.Distance(target.position, transform.position) <= attackRadius)
        // {
        //     if (this.currentTime - this.lastAttackingTime >= 1.5f || this.lastAttackingTime == 0)
        //     {
        //         if (Vector3.Distance(target.position, transform.position) <= attackRadius)
        //         {
        //             float dmgTaken = this.Attack - PlayerManager.player.Defense + this.SpecialAttacking();
        //             PlayerManager.player.HP -= dmgTaken;

        //             Debug.Log("Player: - " + dmgTaken + "HP");
        //             this.lastAttackingTime = Time.time;
        //         }
        //     }
        // }
        

    }

    public IEnumerator OnCollisionEnter2D(Collision2D collision)
    {
            if (collision.gameObject.CompareTag("Player"))
            {
                canDealDamage = true;   
                yield return new WaitForSeconds(1.5f);
                if (Vector3.Distance(target.position, transform.position) <= attackRadius && canDealDamage == true)
                {
                    float dmgTaken = this.Attack - PlayerManager.player.Defense + this.SpecialAttacking();
                    PlayerManager.player.HP -= dmgTaken;

                    Debug.Log("Player: - " + dmgTaken + "HP");
                    this.lastAttackingTime = Time.time;
                }
            }    
    }

    // SPECIAL ATTACK PATTERN OF THE ENEMY
    public int SpecialAttacking()
    {
        int sp = Random.Range(1, 13);

        if (sp == 7)
        {
            Debug.Log("Special attack of " + this.gameObject.ToString() + " has just casted!");
            return 10;
        }
        return 0;
    }

    // CHECKING IF THE ENEMY IS DEAD OR NOT
    public void CheckingHP()
    {
        if (this.HP <= 0)
        {
            Debug.Log("You've destroy an enemy");

            PlayerManager.player.Exp += 2;

            Destroy(gameObject);

            Debug.Log("You've got 2 EXP");
            Debug.Log(PlayerManager.player.Exp);
        }
    }
}
