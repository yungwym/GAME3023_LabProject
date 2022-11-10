using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    [Range(0, 10)]
    public float moveSpeed = 5.0f;

    [SerializeField] Animator playerAnimator;

    //Input Actions
    private PlayerControlsScript playerControls;

    private bool b_PlayerIsMoving;


    private void Awake()
    {
        //Enable player controls 
        playerControls = new PlayerControlsScript();
        playerControls.PlayerControls.Enable();

        //Get animator
        playerAnimator = GetComponent<Animator>();
    }

    private void OnDisable()
    {
        playerControls.PlayerControls.Disable();
    }


    // Update is called once per frame
    void Update()
    {

        CheckMovementAndDetectInputForPlayer();
    }


    private void CheckMovementAndDetectInputForPlayer()
    {
        //Check whether player is currently moving 
        if (!b_PlayerIsMoving)
        {
            //Get input from user 
            Vector2 inputVector = playerControls.PlayerControls.Movement.ReadValue<Vector2>();

            //Restricts movement to one axis 
            if (inputVector.x != 0) inputVector.y = 0;

            //Check if input has value, needed for Coroutine 
            if (inputVector != Vector2.zero)
            {
                //Set DirectionX and Y float for animator 
                playerAnimator.SetFloat("DirectionX", inputVector.x);
                playerAnimator.SetFloat("DirectionY", inputVector.y);

                //Set new targetPostion with added user input 
                Vector3 targetPosition = new Vector3(transform.position.x + inputVector.x, transform.position.y + inputVector.y, transform.position.z);

                //Call coroutine and move to targetPosition 
                StartCoroutine(MovePlayerCharacter(targetPosition));
            }
        }

        //Set IsWalking Bool for Walk Animation
        playerAnimator.SetBool("PlayerIsWalking", b_PlayerIsMoving);
    }

    private IEnumerator MovePlayerCharacter(Vector3 targetPos)
    {
        b_PlayerIsMoving = true;

        while (Vector3.Distance(targetPos, transform.position) > Mathf.Epsilon)
        {
            //Move player character towards target position 
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
        b_PlayerIsMoving = false;
    }
}