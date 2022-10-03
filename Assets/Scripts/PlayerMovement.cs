using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    [Range(0, 10)]
    public float moveSpeed = 5.0f; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");

        Vector3 currentPosition = transform.position;

        transform.position = currentPosition + new Vector3(xInput, yInput, 0) * moveSpeed * Time.deltaTime;
    }
}
