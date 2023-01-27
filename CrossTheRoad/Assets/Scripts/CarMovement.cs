using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public Rigidbody2D _rigidbody;
    public float movementSpeed = 1000f;
    public bool direction;
    SpriteRenderer spi;

    public void SetDirection(bool dir)
    {
        direction = dir;
        spi = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        if (_rigidbody == null)
        {
            Debug.LogError("Rigidbody2D component not found on " + gameObject.name);
        }
        else
        {
            _rigidbody.velocity = new Vector2(1 * movementSpeed, 0);
        }

        //_rigidbody.velocity = new Vector2(1 * movementSpeed, 0);
    }

    private void FixedUpdate()
    {
        if(_rigidbody != null)
        {
            if (direction)
            {
                transform.position += Vector3.left * movementSpeed;
            }
            else
            {
                transform.position += Vector3.right * movementSpeed;
                spi.flipY = true;
            }
        }
    }
}
