using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu
(
    fileName = "New Interactable",
    menuName = "Interactable (Scriptable Object)"
)]
public class Interactable : ScriptableObject
{
    [Tooltip("Displayed above the Interactable in the World Space, and in the dialogue window.")]
    public string displayName;
    public string interactionVerb;

    [Header("Dialogue Strings")]
    [TextArea(3,15)] public string[] interactableDialogue;
    [TextArea(3,15)] public string[] playerDialogue;
}
