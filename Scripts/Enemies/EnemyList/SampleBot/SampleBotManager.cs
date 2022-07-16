using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleBotManager : SampleBot, EnemyAction
{
    // Start is called before the first frame update
    void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;

        this.Thurst = 8f;
    }

    // Update is called once per frame
    void Update()
    {
        this.CurrentTime = Time.time;

        if (this.CheckingDistance())
        {
            Vector3 direction = (target.position - transform.position);
            this.MoveDirection = direction.normalized;
        }
        else
        {
            this.AutoMoving();
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
        if (this.LastMovingTime == 0f)
        {
            this.LastMovingTime = Time.time;
        }

        if (this.CurrentTime - this.LastMovingTime >= 1.5f || this.LastMovingTime == this.CurrentTime)
        {
            randomIndex = Random.Range(1, 17);      //Index random in the range from 1 to 16 (Integer)
            this.LastMovingTime = Time.time;
        }

        switch (randomIndex)
        {
            // Alpha = Pi       (Pi = 3.1415926)
            case 1:
                this.MoveDirection = new Vector3(-1, 0, 0).normalized;
                transform.localScale = new Vector3(-1, 1, 1);
                this.IsFlipped = true;
                break;
            // Alpha = 0        (Pi = 3.1415926)
            case 2:
                this.MoveDirection = new Vector3(1, 0, 0).normalized;
                transform.localScale = new Vector3(1, 1, 1);
                this.IsFlipped = false;
                break;
            // Alpha = Pi / 2   (Pi = 3.1415926)
            case 3:
                this.MoveDirection = new Vector3(0, 1, 0).normalized;
                transform.localScale = new Vector3(1, 1, 1);
                this.IsFlipped = false;
                break;
            // Alpha = -Pi / 2  (Pi = 3.1415926)
            case 4:
                this.MoveDirection = new Vector3(0, -1, 0).normalized;
                transform.localScale = new Vector3(1, 1, 1);
                this.IsFlipped = false;
                break;
            // Alpha = 3Pi / 4  (Pi = 3.1415926)
            case 5:
                this.MoveDirection = new Vector3(-Mathf.Sqrt(1), Mathf.Sqrt(1), 0).normalized;
                transform.localScale = new Vector3(-1, 1, 1);
                this.IsFlipped = true;
                break;
            // Alpha = -Pi / 4  (Pi = 3.1415926)
            case 6:
                this.MoveDirection = new Vector3(Mathf.Sqrt(1), -Mathf.Sqrt(1), 0).normalized;
                transform.localScale = new Vector3(1, 1, 1);
                this.IsFlipped = false;
                break;
            // Alpha = -3Pi / 4 (Pi = 3.1415926)
            case 7:
                this.MoveDirection = new Vector3(-Mathf.Sqrt(1), -Mathf.Sqrt(1), 0).normalized;
                transform.localScale = new Vector3(-1, 1, 1);
                this.IsFlipped = true;
                break;
            // Alpha = Pi / 4   (Pi = 3.1415926)
            case 8:
                this.MoveDirection = new Vector3(Mathf.Sqrt(1), Mathf.Sqrt(1), 0).normalized;
                transform.localScale = new Vector3(1, 1, 1);
                this.IsFlipped = false;
                break;
            // Alpha = Pi / 6   (Pi = 3.1415926)
            case 9:
                this.MoveDirection = new Vector3((Mathf.Sqrt(3) / 2), (1 / 2), 0).normalized;
                transform.localScale = new Vector3(1, 1, 1);
                this.IsFlipped = false;
                break;
            // Alpha = Pi / 3   (Pi = 3.1415926)
            case 10:
                this.MoveDirection = new Vector3((1 / 2), (Mathf.Sqrt(3) / 2), 0).normalized;
                transform.localScale = new Vector3(1, 1, 1);
                this.IsFlipped = false;
                break;
            // Alpha = 2Pi / 3  (Pi = 3.1415926)
            case 11:
                this.MoveDirection = new Vector3(-(1 / 2), (Mathf.Sqrt(3) / 2), 0).normalized;
                transform.localScale = new Vector3(-1, 1, 1);
                this.IsFlipped = true;
                break;
            // Alpha = 5Pi / 6  (Pi = 3.1415926)
            case 12:
                this.MoveDirection = new Vector3(-(Mathf.Sqrt(3) / 2), (1 / 2), 0).normalized;
                transform.localScale = new Vector3(-1, 1, 1);
                this.IsFlipped = true;
                break;
            // Alpha = -5Pi / 6 (Pi = 3.1415926)
            case 13:
                this.MoveDirection = new Vector3(-(Mathf.Sqrt(3) / 2), -(1 / 2), 0).normalized;
                transform.localScale = new Vector3(-1, 1, 1);
                this.IsFlipped = true;
                break;
            // Alpha = -2Pi / 3 (Pi = 3.1415926)
            case 14:
                this.MoveDirection = new Vector3(-(1 / 2), -(Mathf.Sqrt(3) / 2), 0).normalized;
                transform.localScale = new Vector3(-1, 1, 1);
                this.IsFlipped = true;
                break;
            // Alpha = -Pi / 3  (Pi = 3.1415926)
            case 15:
                this.MoveDirection = new Vector3((1 / 2), -(Mathf.Sqrt(3) / 2), 0).normalized;
                transform.localScale = new Vector3(1, 1, 1);
                this.IsFlipped = false;
                break;
            // Alpha = -Pi / 6  (Pi = 3.1415926)
            case 16:
                this.MoveDirection = new Vector3((Mathf.Sqrt(3) / 2), -(1 / 2), 0).normalized;
                transform.localScale = new Vector3(1, 1, 1);
                this.IsFlipped = false;
                break;
            default:
                Debug.Log("Enemy's auto-moving Engine doesn't work properly");
                break;
        }
    }


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
                yield return new WaitForSeconds(2.125f);
                if (Vector3.Distance(target.position, transform.position) <= this.AttackRadius && this.CanDealDamage == true)
                {
                    float dmgTaken = this.Attack - PlayerManager.player.Defense + this.SpecialAttacking();
                    PlayerManager.player.HP -= dmgTaken;

                    Debug.Log("Player: - " + dmgTaken + "HP");
                    this.LastAttackingTime = Time.time;
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
    public float CheckingHP()
    {
        if (this.HP <= 0)
        {
            Debug.Log("You've destroy an enemy");

            PlayerManager.player.Exp += 2;

            Destroy(gameObject);

            Debug.Log("You've got 2 EXP");
            Debug.Log(PlayerManager.player.Exp);
        }

        return this.HP;
    }
}
