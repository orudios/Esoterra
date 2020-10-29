using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(
    fileName = "NPC file",
    menuName = "NPC Files Archive")]
public class NPC : ScriptableObject
{
    public string npcName;
    [TextArea(3,15)]
    public string[] npcDialogue;
    [TextArea(3,15)]
    public string[] playerDialogue;
}
