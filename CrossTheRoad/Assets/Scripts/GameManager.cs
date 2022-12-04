using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Player player;
    public SpawnManager spawnManager;
    // Start is called before the first frame update
    void Start()
    {
        RestartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartGame()
    {
        player = spawnManager.SpawnPlayer();
        player.SetGameManager(this);
    }
}
