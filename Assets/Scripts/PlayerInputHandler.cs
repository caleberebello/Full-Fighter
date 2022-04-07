using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerConfiguration playerConfig;
    private PlayerMoviment mover;

    [SerializeField]
    private SpriteRenderer playerSprite;


    private void Awake()
    {
        var mover = GetComponent<PlayerMoviment>();
    }

    public void InitializePlayer(PlayerConfiguration pc)
    {
        playerConfig = pc;
        playerSprite.sprite = pc.PlayerSprite;
    }
}
