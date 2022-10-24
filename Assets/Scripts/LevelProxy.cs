using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class LevelProxy
    {
        private ItemFabric _itemFabric;
        private PoolObject _poolObject;
        private AssetProvider _assetProvider;

        private List<Item> _itemOnScene = new List<Item>();

        public LevelProxy()
        {
            _assetProvider = new AssetProvider();
            _itemFabric = new ItemFabric(_assetProvider);
            _poolObject = new PoolObject();
        }


        public WinData2 GetScene(string sceneID) => 
            _assetProvider.GetLevel(sceneID);

        public Item GetNewItem(ItemType type, Transform parent = null)
        {
            if ( _poolObject.TryGet(type, out Item item))
            {
                item.transform.parent = parent;
                
            }
            else
            {
                item = _itemFabric.GetNewItem(type, parent);
            }
            _itemOnScene.Add(item);
            
            return item;
        }
        
        
        
    }
}