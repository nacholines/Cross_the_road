using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public Rigidbody2D _rigidbody;
    public float movementSpeed = -5f;
    public bool direction;

    public void SetDirection(bool dir)
    {
        direction = dir;
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.velocity = new Vector2(1 * movementSpeed, 0);
    }

    private void Update()
    {
        if (direction)
        {
            transform.position += Vector3.left * movementSpeed;
        }
        else
        {
            transform.position += Vector3.right * movementSpeed;
        }
    }
}
