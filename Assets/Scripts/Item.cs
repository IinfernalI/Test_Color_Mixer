using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Item : MonoBehaviour
    {
        [field:SerializeField] public ItemType Type { get; private set; }
        [field:SerializeField] public Color32 JuiceColor { get; private set; }

    }
}