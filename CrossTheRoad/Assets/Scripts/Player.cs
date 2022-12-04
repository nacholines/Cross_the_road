using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManager gameManager;
    

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetGameManager(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
            gameManager.RestartGame();
        }
    }
}
