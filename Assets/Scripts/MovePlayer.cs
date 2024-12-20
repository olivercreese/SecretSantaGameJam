using Unity.VisualScripting;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float runSpeed = 1;
    float horizontalInput;
    float verticalInput;
    bool facingRight;
    bool isAttack;
    bool isDash;

    Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        anim.SetFloat("Speed", Mathf.Abs(horizontalInput != 0 ? horizontalInput : verticalInput));
        if (Input.GetKeyDown(KeyCode.J))
        {
            isAttack = true;
            anim.SetTrigger("isJab");
        }
    
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isDash = true;
            anim.SetTrigger("isDash");
            onDash();
        }
        else if (Input.GetKeyUp(KeyCode.Space)) isDash = false;

        if (Input.GetKeyDown(KeyCode.K))
        {
            isAttack = true;
            anim.SetTrigger("isKICK");
        }
        
        
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.5f && !anim.IsInTransition(0)) isAttack = false;


        if (horizontalInput != 0 && !isAttack)
        {
            anim.SetBool("isRunning", true);
        }
        else anim.SetBool("isRunning", false);
        
        if (horizontalInput == 0 && verticalInput != 0 && !isAttack)
        {
            anim.SetBool("isShuffle", true);
        }
        else anim.SetBool("isShuffle", false);

    }

    
    private void FixedUpdate()
    {

        if ((horizontalInput != 0 || verticalInput != 0) && !isAttack)
        {
            Vector3 movement = new Vector3(horizontalInput * runSpeed, verticalInput * runSpeed, 0);
            transform.position = transform.position + movement * Time.deltaTime;
        }
        Flip(-horizontalInput);
    }
    

    private void onDash()
    {
        Vector3 dashVector = new Vector3(horizontalInput * runSpeed *  600, 0,0);
        transform.position = transform.position + dashVector * Time.deltaTime;
    }

    private void Flip(float horizontal)
    {
        if(horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}
