using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 11f;
    private float movementX;
    private Rigidbody2D myBody;
    private SpriteRenderer myRenderer;
    private Animator animator;
    private string WALK_ANIMATION = "Walk";
    private void Awake() 
    {
        myBody = GetComponent<Rigidbody2D>();

        myRenderer = GetComponent<SpriteRenderer>();

        animator = GetComponent<Animator>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyBoard();
        AnimatePlayerMove();
    }

    void PlayerMoveKeyBoard()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * moveForce * Time.deltaTime;
    }

    void AnimatePlayerMove()
    {
        if (movementX > 0 ) {
            animator.SetBool(WALK_ANIMATION, true);
            myRenderer.flipX = false;
        } else if (movementX < 0 ) {
            animator.SetBool(WALK_ANIMATION, true);
            myRenderer.flipX = true;
        } else {
            animator.SetBool(WALK_ANIMATION, false);
        }
    }
}
