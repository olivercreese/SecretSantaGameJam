using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public int runSpeed = 1;
    float horizontalInput;
    float verticalInput;
    bool facingRight;
    bool isJab;

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJab = true;
            anim.SetBool("isJab",isJab);
        }
        else if (Input.GetKeyUp(KeyCode.Space)) isJab = false;
    }

    private void FixedUpdate()
    {
       if ((horizontalInput != 0 || horizontalInput != 0) && !isJab)
       {
            Vector3 movement = new Vector3(horizontalInput * runSpeed, verticalInput * runSpeed, 0);
            transform.position = transform.position + movement * Time.deltaTime;
       }
       Flip(-horizontalInput);
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
