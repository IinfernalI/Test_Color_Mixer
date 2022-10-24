using System;
using System.Linq;

namespace DefaultNamespace
{
    public class AssetProvider
    {
        private const string Assetitems = "AssetItems";
        private const string LevelStaticData = "LevelStaticData";
        private AssetItems _assetItems;
        private LevelStaticData _levelStaticData;

        public AssetProvider()
        {
            _assetItems = UnityEngine.Resources.Load<AssetItems>(Assetitems);
            _levelStaticData = UnityEngine.Resources.Load<LevelStaticData>(LevelStaticData);
        }


        public Item GetAsset(ItemType type) =>
            _assetItems.GetAsset(type);


        public WinData2 GetLevel(string levelId) =>
            _levelStaticData.Levels.FirstOrDefault(i => i.levelId == levelId) ?? throw new NullReferenceException($"{_levelStaticData.Levels} is null");
    }
}