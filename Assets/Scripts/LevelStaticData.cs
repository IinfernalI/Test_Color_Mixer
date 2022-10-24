using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "LevelStaticData", menuName = "ScriptableObjects/StaticData/LevelStaticData")]
    public class LevelStaticData : ScriptableObject
    {
        [SerializeField] public List<WinData2> Levels ;
    }
}