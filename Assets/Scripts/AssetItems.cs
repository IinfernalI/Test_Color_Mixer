using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "AssetItems", menuName = "ScriptableObjects/StaticData/AssetItems")]
    public class AssetItems : ScriptableObject
    {
        [SerializeField] private List<Item> itemList;

        public Item GetAsset(ItemType type)
        {
            Item item = itemList.FirstOrDefault(i => i.Type == type);

            if (item == null)
            {
                Debug.LogError($"cannot find asset {type}");
            }
            return item;
           
        }

    }
}