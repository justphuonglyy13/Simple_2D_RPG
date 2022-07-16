using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Player, PlayerAction
{
    // Static player which is initialized only once at the start of the game.
    public static PlayerManager player;

    // THE TRANSFORM OF THE PLAYER.
    private Vector3 movement;
    private Vector3 moveDirection;

    // THE CURRENT STATE OF THE PLAYER.
    private PLAYER_STATE currentPlayerState = PLAYER_STATE.Walk;

    // GET OTHER COMPONENTS.
    protected Rigidbody2D myRigidBody;
    private Animator myAnimator;
    private RaycastHit2D hit;

    // TIME ATTRIBUTES.
    [SerializeField]
    private float currentTime;   
    [SerializeField]
    private float dashAmount = 5f;
    [SerializeField]
    private float dashCooldown = 3f;
    [SerializeField]
    private float lastDashTime = 0f;
    //[SerializeField]
    private float lastSpecialAttackingTime = 0f;

    // LOGICAL ATTRIBUTES TO CHECK WHETHER THE PLAYER IS TRYING TO DO SOMETHING OR NOT.
    [SerializeField]
    private bool isDashButtonDown = false;

    // Start is called before the first frame update
    public void Start()
    {
        player = this;
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Update()
    {
        // Calculate the current time using Time.time
        this.currentTime = Time.time;

        // Move the player
        this.MovingPlayer();

        // Attacking
        if (Input.GetKeyDown(KeyCode.J) && currentPlayerState != PLAYER_STATE.Attack)
        {
            StartCoroutine(Attacking());
        } else if (Input.GetKeyDown(KeyCode.L) && currentPlayerState != PLAYER_STATE.Attack) {
            StartCoroutine(SpecialAttacking());    
        } else if (currentPlayerState == PLAYER_STATE.Walk)
        {
            this.AnimatingPlayer();
        }

        // Dashing
        if (Input.GetKeyDown(KeyCode.K))
        {
            if ((currentTime - lastDashTime >= dashCooldown || lastDashTime == 0f) && this.currentPlayerState != PLAYER_STATE.Attack)
                isDashButtonDown = true;
        }

        //Updating the level of the player
        this.LevelUp(); 

        //Checking whether the HP of the player is 0
        this.CheckingHP();
    }

    // APPLY PHYSICAL MOVEMENT TO THE PLAYER
    public void FixedUpdate()
    {
        if (this.currentPlayerState == PLAYER_STATE.Idle) {
            myRigidBody.velocity = Vector3.zero;
            return ;
        }

        myRigidBody.velocity = moveDirection * this.Speed;

        if (isDashButtonDown)
        {
            Vector3 dashPosition = transform.position + moveDirection * dashAmount;

            RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, moveDirection, dashAmount);

            // Detect whether the raycast hit something or not
            if (raycastHit2D.collider != null)
            {
                dashPosition = raycastHit2D.point;
            }

            myRigidBody.MovePosition(dashPosition);
            isDashButtonDown = false;
            lastDashTime = Time.time;
        }
    }

    // MOVING THE PLAYER USING KEYS ON THE KEYBOARD
    public void MovingPlayer() {
        // Reset the 3D Vector movement
        movement = new Vector3();

        /*
         * USE A, W, S, D TO MOVE THE PLAYER
         *  -> A: Move Left
         *  -> W: Move Up
         *  -> S: Move Down
         *  -> D: Move Right
         */

        if (Input.GetKey(KeyCode.W))
        {
            movement.y = 1f;            // (x, y) = (0, 1)
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement.y = -1f;           // (x, y) = (0, -1)
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement.x = -1f;           // (x, y) = (-1, 0)
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement.x = 1f;            // (x, y) = (1, 0)
        }

        moveDirection = new Vector3(movement.x, movement.y, 0f).normalized;         // Vector2(x, y) = 1. cos(theta) = x / sqrt(x^2 + y^2)
    }

    // ANIMATE THE PLAYER
    public void AnimatingPlayer()
    {
        if (moveDirection != Vector3.zero)
        {
            myAnimator.SetFloat("movementX", movement.x);
            myAnimator.SetFloat("movementY", movement.y);
            myAnimator.SetBool("isMoving", true);
        }
        else
        {
            myAnimator.SetBool("isMoving", false);
        }
    }

    // ATTACKING ANIMATION SIMULATOR
    public IEnumerator Attacking()
    {
        myAnimator.SetBool("isAttacking", true);
        currentPlayerState = PLAYER_STATE.Attack;

        yield return null;

        myAnimator.SetBool("isAttacking", false);
        yield return new WaitForSeconds(.666667f);

        currentPlayerState = PLAYER_STATE.Walk;
    } 

    // UPDATE THE LEVEL OF THE PLAYER
    public void LevelUp()
    {
        int threshold = 5;
        if (this.Exp >= 5 + (threshold * (this.Level - 1))) {
            this.Exp -= 5 + (threshold * (this.Level - 1));
            this.HP += 10;
            this.Attack += 1;
            this.Level++;
            Debug.Log("Level up! Now your level is " + this.Level);
        }
    }

    // CHECK THE HEALTH POWER OF THE PLAYER
    public void CheckingHP(){
        if (this.HP <= 0) {
            Destroy(this.gameObject);
            Debug.Log("GAME OVER!!!!!!");
        }
    }

    public IEnumerator SpecialAttacking() {
        if (currentTime - lastSpecialAttackingTime < 5f)  {
            yield break;
        }
        myAnimator.SetBool("isAttacking", true);
        currentPlayerState = PLAYER_STATE.Attack;

        yield return null;
        myAnimator.SetBool("isAttacking", false);
        yield return new WaitForSeconds(.6666667f);

        currentPlayerState = PLAYER_STATE.Walk;
        lastSpecialAttackingTime = Time.time;
    }
}
