using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CursorDetection : MonoBehaviour
{

    private GraphicRaycaster gr;
    private PointerEventData pointerEventData = new PointerEventData(null);
    public Transform currentCharacter;
    public Transform token;
    public bool hasToken;
    // Start is called before the first frame update
    void Start()
    {
        gr = GetComponentInParent<GraphicRaycaster>();
    }

    // Update is called once per frame
    void Update()
    {

        //CONFIRM
        if (Input.GetButtonDown("Fire1"))
        {
            if (currentCharacter != null)
            {
                TokenFollow(false);
            }
        }

        //CANCEL
        if (Input.GetButtonDown("Fire2"))
        {
            TokenFollow(true);
        }

        if (hasToken)
        {
            token.position = transform.position;
        }

        pointerEventData.position = Camera.main.WorldToScreenPoint(transform.position);
        List<RaycastResult> results = new List<RaycastResult>();
        gr.Raycast(pointerEventData, results);


        if(hasToken)
        {
            if (results.Count > 0)
            {
                Transform raycastCharacter = results[0].gameObject.transform;
                if (raycastCharacter != currentCharacter)
                {
                    if (currentCharacter != null)
                    {
                        currentCharacter.Find("selectedBorder").GetComponent<Image>().color = Color.clear;
                    }
                    SetCurrentCharacter(raycastCharacter);
                }
            }
        }
        
        else {
            if (currentCharacter != null)
            {
                currentCharacter.Find("selectedBorder").GetComponent<Image>().color = Color.clear;
                SetCurrentCharacter(null);
            }
        }
    }

    void SetCurrentCharacter(Transform t)
    {
        currentCharacter = t;
        if(t != null)
        {
            t.Find("selectedBorder").GetComponent<Image>().color = Color.white;
        }
    }

    void TokenFollow (bool trigger)
    {
        hasToken = trigger;
    }
}