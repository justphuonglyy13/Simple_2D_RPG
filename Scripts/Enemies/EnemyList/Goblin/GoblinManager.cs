using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinManager : Goblin, EnemyAction
{
    private ENEMY_STATE goblinState = ENEMY_STATE.Idle;

    private Animator goblinAnimator;

    [SerializeField]
    private GameObject[] randomDroppedItems;

    // Start is called before the first frame update
    void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody2D>();
        goblinAnimator = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;

        this.Thurst = 6f;
    }

    // Update is called once per frame
    void Update()
    {
        this.CurrentTime = Time.time;

        if (this.CheckingDistance() && this.goblinState != ENEMY_STATE.Attack)
        {
            Vector3 direction = (target.position - transform.position);
            this.MoveDirection = direction.normalized;
            this.AnimatingGoblin();
        }
        else if (this.goblinState != ENEMY_STATE.Attack)
        {
            this.AutoMoving();
            this.AnimatingGoblin();
        } 

        if (this.CurrentTime - this.LastAttackingTime >= 0.3333334f) {
            alreadyHasBeenCollided = false;
        }
    }

    void FixedUpdate()
    {
        if (alreadyHasBeenCollided == true) {
            enemyRigidBody.velocity = Vector2.zero;
            enemyRigidBody.AddForce(this.Difference * this.Thurst, ForceMode2D.Impulse);
            CanDealDamage = false;
        } else {
            enemyRigidBody.velocity = this.MoveDirection * Speed;
        }
    }

    public void AutoMoving()
    {
        if (this.goblinState == ENEMY_STATE.Attack) {
            return ;
        }
        if (this.LastMovingTime == 0f)
        {
            this.LastMovingTime = Time.time;
        }

        if (this.CurrentTime - this.LastMovingTime >= 2f || this.LastMovingTime == this.CurrentTime)
        {
            randomIndex = Random.Range(1, 19);      //Index random in the range from 1 to 18 (Integer)
            this.LastMovingTime = Time.time;
        }

        switch (randomIndex)
        {
            // Alpha = Pi       (Pi = 3.1415926)
            case 1:
                this.MoveDirection = new Vector3(-1, 0, 0).normalized;
                transform.localScale = new Vector3(-1, 1, 1);
                this.IsFlipped = true;
                this.goblinState = ENEMY_STATE.Walk;
                break;
            // Alpha = 0        (Pi = 3.1415926)
            case 2:
                this.MoveDirection = new Vector3(1, 0, 0).normalized;
                transform.localScale = new Vector3(1, 1, 1);
                this.IsFlipped = false;
                this.goblinState = ENEMY_STATE.Walk;
                break;
            // Alpha = Pi / 2   (Pi = 3.1415926)
            case 3:
                this.MoveDirection = new Vector3(0, 1, 0).normalized;
                transform.localScale = new Vector3(1, 1, 1);
                this.IsFlipped = false;
                this.goblinState = ENEMY_STATE.Walk;
                break;
            // Alpha = -Pi / 2  (Pi = 3.1415926)
            case 4:
                this.MoveDirection = new Vector3(0, -1, 0).normalized;
                transform.localScale = new Vector3(1, 1, 1);
                this.IsFlipped = false;
                this.goblinState = ENEMY_STATE.Walk;
                break;
            // Alpha = 3Pi / 4  (Pi = 3.1415926)
            case 5:
                this.MoveDirection = new Vector3(-Mathf.Sqrt(1), Mathf.Sqrt(1), 0).normalized;
                transform.localScale = new Vector3(-1, 1, 1);
                this.IsFlipped = true;
                this.goblinState = ENEMY_STATE.Walk;
                break;
            // Alpha = -Pi / 4  (Pi = 3.1415926)
            case 6:
                this.MoveDirection = new Vector3(Mathf.Sqrt(1), -Mathf.Sqrt(1), 0).normalized;
                transform.localScale = new Vector3(1, 1, 1);
                this.IsFlipped = false;
                this.goblinState = ENEMY_STATE.Walk;
                break;
            // Alpha = -3Pi / 4 (Pi = 3.1415926)
            case 7:
                this.MoveDirection = new Vector3(-Mathf.Sqrt(1), -Mathf.Sqrt(1), 0).normalized;
                transform.localScale = new Vector3(-1, 1, 1);
                this.IsFlipped = true;
                this.goblinState = ENEMY_STATE.Walk;
                break;
            // Alpha = Pi / 4   (Pi = 3.1415926)
            case 8:
                this.MoveDirection = new Vector3(Mathf.Sqrt(1), Mathf.Sqrt(1), 0).normalized;
                transform.localScale = new Vector3(1, 1, 1);
                this.IsFlipped = false;
                this.goblinState = ENEMY_STATE.Walk;
                break;
            // Alpha = Pi / 6   (Pi = 3.1415926)
            case 9:
                this.MoveDirection = new Vector3((Mathf.Sqrt(3) / 2), (1 / 2), 0).normalized;
                transform.localScale = new Vector3(1, 1, 1);
                this.IsFlipped = false;
                this.goblinState = ENEMY_STATE.Walk;
                break;
            // Alpha = Pi / 3   (Pi = 3.1415926)
            case 10:
                this.MoveDirection = new Vector3((1 / 2), (Mathf.Sqrt(3) / 2), 0).normalized;
                transform.localScale = new Vector3(1, 1, 1);
                this.IsFlipped = false;
                this.goblinState = ENEMY_STATE.Walk;
                break;
            // Alpha = 2Pi / 3  (Pi = 3.1415926)
            case 11:
                this.MoveDirection = new Vector3(-(1 / 2), (Mathf.Sqrt(3) / 2), 0).normalized;
                transform.localScale = new Vector3(-1, 1, 1);
                this.IsFlipped = true;
                this.goblinState = ENEMY_STATE.Walk;
                break;
            // Alpha = 5Pi / 6  (Pi = 3.1415926)
            case 12:
                this.MoveDirection = new Vector3(-(Mathf.Sqrt(3) / 2), (1 / 2), 0).normalized;
                transform.localScale = new Vector3(-1, 1, 1);
                this.IsFlipped = true;
                this.goblinState = ENEMY_STATE.Walk;
                break;
            // Alpha = -5Pi / 6 (Pi = 3.1415926)
            case 13:
                this.MoveDirection = new Vector3(-(Mathf.Sqrt(3) / 2), -(1 / 2), 0).normalized;
                transform.localScale = new Vector3(-1, 1, 1);
                this.IsFlipped = true;
                this.goblinState = ENEMY_STATE.Walk;
                break;
            // Alpha = -2Pi / 3 (Pi = 3.1415926)
            case 14:
                this.MoveDirection = new Vector3(-(1 / 2), -(Mathf.Sqrt(3) / 2), 0).normalized;
                transform.localScale = new Vector3(-1, 1, 1);
                this.IsFlipped = true;
                this.goblinState = ENEMY_STATE.Walk;
                break;
            // Alpha = -Pi / 3  (Pi = 3.1415926)
            case 15:
                this.MoveDirection = new Vector3((1 / 2), -(Mathf.Sqrt(3) / 2), 0).normalized;
                transform.localScale = new Vector3(1, 1, 1);
                this.IsFlipped = false;
                this.goblinState = ENEMY_STATE.Walk;
                break;
            // Alpha = -Pi / 6  (Pi = 3.1415926)
            case 16:
                this.MoveDirection = new Vector3((Mathf.Sqrt(3) / 2), -(1 / 2), 0).normalized;
                transform.localScale = new Vector3(1, 1, 1);
                this.IsFlipped = false;
                this.goblinState = ENEMY_STATE.Walk;
                break;
            case 17:
            case 18:
                this.MoveDirection = Vector3.zero;
                this.goblinState = ENEMY_STATE.Idle;
                break;
            default:
                Debug.Log("Enemy's auto-moving Engine doesn't work properly");
                break;
        }
    }

    public void AnimatingGoblin() {
        if (this.goblinState != ENEMY_STATE.Attack) {
            this.goblinAnimator.SetBool("isAttacking", false);
        }

        if (this.MoveDirection != Vector3.zero && this.goblinState == ENEMY_STATE.Walk) {
            this.goblinAnimator.SetBool("isMoving", true);
        } else if (this.goblinState == ENEMY_STATE.Idle) {
            this.goblinAnimator.SetBool("isMoving", false);
        }
    }


    // CHECKING DISTANCE
    public bool CheckingDistance()
    {
        if (Vector3.Distance(transform.position, target.position) <= this.ChaseRadius && Vector3.Distance(transform.position, target.position) > this.AttackRadius)
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
                this.Difference = new Vector2(transform.position.x - PlayerManager.player.transform.position.x, transform.position.y - PlayerManager.player.transform.position.y);

                this.HP -= (PlayerManager.player.Attack - this.Defense);
                Debug.Log("You've dealing [" + (PlayerManager.player.Attack - this.Defense) + "] DMG to the enemy!!!");
                this.CheckingHP();
                this.LastAttackingTime = Time.time;      
            }
        }
    }

    // ATTACK PATTERN OF THE ENEMY
    public void Attacking()
    {

    }

    public IEnumerator OnCollisionEnter2D(Collision2D collision)
    {
            if (collision.gameObject.CompareTag("Player"))
            {
                CanDealDamage = true;   
                yield return new WaitForSeconds(1f);
                if (Vector3.Distance(target.position, transform.position) <= this.AttackRadius && this.CanDealDamage == true && ((this.CurrentTime - this.LastAttackingTime) >= 0.75f || this.LastAttackingTime == 0f))
                {
                    
                    this.goblinAnimator.SetBool("isAttacking", true);
                    this.goblinState = ENEMY_STATE.Attack;
                    this.MoveDirection = Vector3.zero;

                    float dmgTaken = this.Attack - PlayerManager.player.Defense + this.SpecialAttacking();
                    PlayerManager.player.HP -= dmgTaken;

                    Debug.Log("Player: - " + dmgTaken + "HP");

                    this.LastAttackingTime = Time.time;
                    this.CanDealDamage = false;

                    yield return new WaitForSeconds(0.6666667f);
                    this.goblinState = ENEMY_STATE.Idle;
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
            return 15;
        }
        return 0;
    }

    // CHECKING IF THE ENEMY IS DEAD OR NOT
    public float CheckingHP()
    {
        if (this.HP <= 0)
        {
            Debug.Log("You've destroy an enemy");

            PlayerManager.player.Exp += 4;

            this.DropItems();
            Destroy(this.gameObject);

            Debug.Log("You've got 4 EXP");
            Debug.Log(PlayerManager.player.Exp);
        }

        return this.HP;
    }

    //RANDOMLY DROP ITEM WHEN THE ENEMY IS DEAD
    public void DropItems()
    {
        int drop = Random.Range(1, 101);
        if (drop % (3 + (int) (EnemyStatistic.hardness * 7/2)) == 0)
        {
            Instantiate(this.randomDroppedItems[Random.Range(0, randomDroppedItems.Length)], this.transform.position, Quaternion.identity);
        } 
    }
}

