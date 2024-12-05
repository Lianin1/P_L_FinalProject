using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Team
{
    [CreateAssetMenu(menuName = "Team/NPC")]
    public class DataNPC : ScriptableObject
    {
        [Header("NPC AI 要分析的句子")]
        public string[] sentences;


    }
}