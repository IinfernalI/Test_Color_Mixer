using UnityEngine;

namespace DefaultNamespace
{
    public class ItemFabric
    {
        private AssetProvider _provider;
        public ItemFabric(AssetProvider assetProvider)
        {
            _provider = assetProvider;
        }

        public Item GetNewItem(ItemType type, Transform parent )
        {
            Item asset = _provider.GetAsset(type);
            Item item = Object.Instantiate(asset, parent);
            return item;
        }
    }
}