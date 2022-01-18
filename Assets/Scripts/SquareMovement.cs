using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareMovement : MonoBehaviour
{
    public float speed;
    private Vector2 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        moveDirection = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        MovementInputs();

        this.transform.position += new Vector3(moveDirection.x, moveDirection.y) * speed * Time.deltaTime;
    }

    private void MovementInputs()
    {
        moveDirection = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            moveDirection.y += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection.y += -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection.x += 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection.x += -1;
        }
    }

    public bool IsMoving()
    {
        return moveDirection != Vector2.zero;
    }
}
