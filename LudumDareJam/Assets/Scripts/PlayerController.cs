using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerController : MonoBehaviour{
    [SerializeField] private float moveSpeed;
    private GameEndController gameEndController;
    private Animator animator;
    private bool canMove;
    private bool isMovingRight;
    private bool isFacingRight;

    private Rigidbody2D rb;

    void Awake() {
        canMove = true;
        isFacingRight = true;
    }

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        gameEndController = FindFirstObjectByType<GameEndController>();
        animator = GetComponent<Animator>();
    }

    void Update(){
        HandleMovement();
        HandleAnims();
    }

    private void HandleMovement(){
        if(!canMove)
            return;

        Vector2 moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        rb.linearVelocity = moveDirection * moveSpeed;

        if(rb.linearVelocity.x > 0f){
            isMovingRight = true;
        }else if(rb.linearVelocity.x < 0f)
            isMovingRight = false;
        
        if(isMovingRight != isFacingRight)
            Flip();
    }

    private void HandleAnims(){
        if(rb.linearVelocity.x != 0f)
            animator.SetBool("isMovX", true);
        else
            animator.SetBool("isMovX", false);


        if(rb.linearVelocity.y > 0f)
            animator.SetBool("isMovUp", true);
        else if(rb.linearVelocity.y < 0f)
            animator.SetBool("isMovDown", true);
        else{
            animator.SetBool("isMovUp", false);
            animator.SetBool("isMovDown", false);
        }
           
    }

    void Flip(){
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

        isFacingRight = !isFacingRight;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Portal")){
            gameEndController.ChangeScene();
        }
    }
}