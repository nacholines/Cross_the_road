using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private Player player;
    public SpawnManager spawnManager;
    private int gameLosses = 0;
    public TextMeshProUGUI deathsText;
    public TextMeshProUGUI winText;
    public bool canDie = true;

    void Start()
    {
        RestartGame();
    }

    public void RestartGame()
    {
        if (player)
        {
            Destroy(player.gameObject);
        }
        if(canDie)
        {
            gameLosses++;
            deathsText.text = "Deaths: " + gameLosses.ToString();
            StartCoroutine(CanDie());
        }
    }

    private IEnumerator CanDie()
    {
        canDie = false;
        yield return new WaitForSeconds(0.1f);
        player = spawnManager.SpawnPlayer();
        player.SetGameManager(this);
        canDie = true;
    }

    public void WinGame()
    {
        Debug.Log("ganastes!");
        Destroy(player.gameObject);
        winText.text = "You win!";
    }
}
