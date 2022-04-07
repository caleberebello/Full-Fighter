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
    private Animator playerAnimator;

    private void Awake()
    {
        mover = GetComponent<PlayerMoviment>();
        playerAnimator = gameObject.GetComponent<Animator>();
    }

    public void InitializePlayer(PlayerConfiguration pc)
    {
        playerConfig = pc;
        //I put it inside this If Statement to avoid Errors/Warnings but its not 100% necessary
        if(playerAnimator.gameObject.activeSelf)
        {
            playerAnimator.runtimeAnimatorController = pc.PlayerAnimator;
        }
        //playerAnimator = pc.PlayerAnimator;
    }
}
