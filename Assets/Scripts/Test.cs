using System;
using System.Collections.Generic;
using System.IO;
using ColorMine.ColorSpaces;
using ColorMine.ColorSpaces.Comparisons;
using Newtonsoft.Json;
using UnityEngine;

namespace DefaultNamespace
{
    public class Test : MonoBehaviour
    {
        public ItemType itemType;
        public Transform newTransform;
        private LevelProxy LP;

        public Color32 colorA;
        public Color32 colorB;
        public Color32 colorC;
        public Color32 result;
        private TestColor _testColor;

        public AssetItems assetItems;
        private double _colourDistance;
        public float _delta = 25f;
        public double _compare76;
        public double _compareCmc;
        public TextAsset _json;
        [SerializeField] private string _serializeObject;

        [ContextMenu("TestColorF")]
        public void TestColorF()
        {
            //var Delta = TestColor.LAB.GetDelta(colorA, colorB);

            //var AreSimilar=TestColor.LAB.AreSimilar (colorA, colorB,_delta);
            // Debug.Log($"{Delta} : {AreSimilar}");

            Rgb rgbA = new Rgb() { R = colorA.r, G = colorA.g, B = colorA.b };
            Rgb rgbB = new Rgb() { R = colorB.r, G = colorB.g, B = colorB.b };
            _compare76 = new Cie1976Comparison().Compare(rgbA, rgbB);
            _compareCmc = new CmcComparison().Compare(rgbA, rgbB);
            Debug.Log($"{_compare76:0.0000} : {_compareCmc:0.0000} {colorA}: {colorB}");
            //result = (Color.blue + Color.red) / 2;
            result = CombineColors(colorA, colorB, colorC);
        }

        public static Color CombineColors(params Color[] aColors)
        {
            Color result = new Color(0, 0, 0, 0);
            foreach (Color c in aColors)
            {
                result += c;
            }

            result /= aColors.Length;
            return result;
        }


        [ContextMenu("TestSerializeJson")]
        public void TestSerializeJson()
        {
            WinData winData = new WinData();
            winData.levelId = "level_1";
            winData.winColor = "00AC00";
            // winData.winMatch = new List<WinMatchItem>()
            // {
            //     new WinMatchItem() { count = 1, itemId = "Banana" },
            //     new WinMatchItem() { count = 1, itemId = "Orange" },
            // };
            
            Debug.Log($"{_serializeObject}");

            WinData level123123 = JsonConvert.DeserializeObject<WinData>(_serializeObject);
            Debug.Log($"{level123123}");

            string testLevelFile = Application.dataPath + "/Resources/test.json";
            using (StreamWriter file = File.CreateText(testLevelFile))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, winData);
            }
        }

        private string SerializeData()
        {
            WinData winData = new WinData();
            winData.levelId = "level_1";
            winData.winColor = "00AC00";
            // winData.winMatch = new List<WinMatchItem>()
            // {
            //     new WinMatchItem() { count = 1, itemId = "Banana" },
            //     new WinMatchItem() { count = 1, itemId = "Orange" },
            // };
            _serializeObject = JsonConvert.SerializeObject(winData);
            return _serializeObject;
        }

        public void SafePlayerPrefs()
        {
            string data = SerializeData();
            
            PlayerPrefs.SetString("MyData",data);
            PlayerPrefs.Save();
        }
 public void LoadPlayerPrefs()
        {
            if (PlayerPrefs.HasKey("MyData"))
            {
                string json = PlayerPrefs.GetString("MyData",string.Empty);
            }
            else
            {
                Debug.Log($"no have a key PlayerPrefs");
            }
        }

        [ContextMenu("TestDeserializeJson")]
        public void TestDeserializeJson()
        {
            
            string testJson = Application.dataPath + "/Resources/test.json";
            using (StreamReader r = new StreamReader(testJson))
            {
                string json = r.ReadToEnd();
                WinData level123123 = JsonConvert.DeserializeObject<WinData>(json);
                Debug.Log($"{level123123}");
            }
        }


        [ContextMenu("TestLP")]
        public void TestLP()
        {
            LP = new LevelProxy();
            Item item = LP.GetNewItem(itemType, newTransform);
            Debug.Log($"item: {item != null} ! == null");
        }

        [ContextMenu("SetValue")]
        public void SetValue()
        {
            var t = assetItems.GetAsset(ItemType.Apple);
            Debug.Log($"{t != null}");
        }
    }
}