using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerConfigurationManager : MonoBehaviour
{
    private List<PlayerConfiguration> playerConfigs;

    [SerializeField]
    private int MaxPlayers = 2;

    public static PlayerConfigurationManager Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.Log("Singleton - Tentando criar outra instância do Singleton");
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
            playerConfigs = new List<PlayerConfiguration>();
        }
    }

    public List<PlayerConfiguration> GetPlayerConfigs()
    {
        return playerConfigs;
    }

    public void SetPlayerSprite(int index, Sprite sprite)
    {
        playerConfigs[index].PlayerSprite = sprite;
    }

    public void ReadyPlayer(int index) 
    {
        playerConfigs[index].isReady = true;
        if(playerConfigs.Count == MaxPlayers && playerConfigs.All(p => p.isReady == true))
        {
            SceneManager.LoadScene("Cenário");
        }
    }

    public void HandlePlayerJoin(PlayerInput pi) 
    {
        Debug.Log("Player Joined " + pi.playerIndex);
        if(!playerConfigs.Any(p => p.PlayerIndex == pi.playerIndex))
        {
            pi.transform.SetParent(transform);
            playerConfigs.Add(new PlayerConfiguration(pi));
        }
    }
}

    public class PlayerConfiguration 
    {
    public PlayerConfiguration(PlayerInput pi) 
    {
        PlayerIndex = pi.playerIndex;
        Input = pi;
    }
    public PlayerInput Input { get; set; }
    public int PlayerIndex { get; set; }
    public bool isReady { get; set; }
    public Sprite PlayerSprite { get; set; }
}
