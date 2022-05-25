using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Defeat : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject defeatPanel;

    void OnBecameInvisible(){
        playerPrefab.gameObject.SetActive(false);
        defeatPanel.gameObject.SetActive(true);
    }
}
