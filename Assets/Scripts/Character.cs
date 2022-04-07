using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Animations;

[System.Serializable]
public class Character {
    public string characterName;
    public Sprite characterSprite;
    public AnimatorController characterAnimator;
}
