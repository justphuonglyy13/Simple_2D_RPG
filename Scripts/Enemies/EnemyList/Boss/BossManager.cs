using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : Boss, EnemyAction
{
    private ENEMY_STATE bossState = ENEMY_STATE.Idle;

    private Animator bossAnimator;

    public static BossManager boss;


    // Start is called before the first frame update
    void Start()
    {
        boss = this;
        enemyRigidBody = GetComponent<Rigidbody2D>();
        bossAnimator = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;

        this.Thurst = 4f;
    }

    // Update is called once per frame
    void Update()
    {
        this.CurrentTime = Time.time;

        if (this.CheckingDistance() && this.bossState != ENEMY_STATE.Attack)
        {
            Vector3 direction = (target.position - transform.position);
            this.MoveDirection = direction.normalized;
            this.AnimatingGoblin();
        }
        else if (this.bossState != ENEMY_STATE.Attack)
        {
            this.AutoMoving();
            this.AnimatingGoblin();
        }

        if (this.CurrentTime - this.LastAttackingTime >= 0.3333334f)
        {
            alreadyHasBeenCollided = false;
        }
    }

    void FixedUpdate()
    {
        if (alreadyHasBeenCollided == true)
        {
            enemyRigidBody.velocity = Vector2.zero;
            enemyRigidBody.AddForce(this.Difference * this.Thurst, ForceMode2D.Impulse);
        }
        else
        {
            enemyRigidBody.velocity = this.MoveDirection * Speed;
        }
    }

    public void AutoMoving()
    {
        if (this.bossState == ENEMY_STATE.Attack)
        {
            return;
        }
        
        this.bossState = ENEMY_STATE.Walk;
        this.MoveDirection = Vector3.Distance(transform.position, target.position) > 1f ? (target.position - transform.position).normalized : Vector3.zero;
        
        if (this.MoveDirection.x > 0) {
            transform.localScale = new Vector3(-5, 5, 1);
            this.IsFlipped = true;
        } else {
            transform.localScale = new Vector3(5, 5, 1);
            this.IsFlipped = false;
        }
    }

    public void AnimatingGoblin()
    {
        if (this.bossState != ENEMY_STATE.Attack)
        {
            this.bossAnimator.SetBool("isAttacking", false);
        }

        if (this.MoveDirection != Vector3.zero && this.bossState == ENEMY_STATE.Walk)
        {
            this.bossAnimator.SetBool("isMoving", true);
        }
        else if (this.bossState == ENEMY_STATE.Idle)
        {
            this.bossAnimator.SetBool("isMoving", false);
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

                this.HP -= (PlayerManager.player.Attack - this.Defense <= 0) ? 0 : PlayerManager.player.Attack - this.Defense;
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
        if (collision.gameObject.CompareTag("Player") && CanDealDamage == true)
        {
            this.CanDealDamage = false;

            this.bossAnimator.SetBool("isAttacking", true);
            this.bossState = ENEMY_STATE.Attack;
            this.MoveDirection = Vector3.zero;

            yield return null;

            this.bossAnimator.SetBool("isAttacking", false);
            yield return new WaitForSeconds(0.5f);
            if (Vector3.Distance(transform.position, target.position) <= this.AttackRadius) {
                
                float dmgTaken = this.Attack - PlayerManager.player.Defense + this.SpecialAttacking();
                PlayerManager.player.HP -= ((dmgTaken <= 0) ? 0 : dmgTaken);

                Debug.Log("Player: - " + dmgTaken + "HP");
            } 

            this.LastAttackingTime = Time.time;
            this.CanDealDamage = true;

            yield return new WaitForSeconds(0.25f);
            this.bossState = ENEMY_STATE.Idle;

        }

        if (collision.gameObject.CompareTag("Player Special Attack")) {
            this.HP -= (PlayerManager.player.Attack * 2 - this.Defense);
            Debug.Log("You've dealing [" + (PlayerManager.player.Attack * 2 - this.Defense) + "] DMG to the enemy!!!");
            this.CheckingHP();
        }
    }

    // SPECIAL ATTACK PATTERN OF THE ENEMY
    public int SpecialAttacking()
    {
        int sp = Random.Range(1, 13);

        if (sp == 7)
        {
            Debug.Log("Special attack of " + this.gameObject.ToString() + " has just casted!");
            return 30;
        }
        return 0;
    }

    // CHECKING IF THE ENEMY IS DEAD OR NOT
    public float CheckingHP()
    {
        if (this.HP <= 0)
        {
            Debug.Log("You've destroy an enemy");

            Destroy(this.gameObject);

            Debug.Log("You've win this game!!! VICTORY!!! CONGRATULATIONS!!!");
            Debug.Log(PlayerManager.player.Exp);
        }

        return this.HP;
    }

    //RANDOMLY DROP ITEM WHEN THE ENEMY IS DEAD
    public void DropItems()
    {
        
    }
}
