using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UnityEngine;

namespace DefaultNamespace
{
    public class WinLevelManager
    {
        public WinData GetLevel(string json)
        {
            //WinData level = JsonConverter<>.<WinData>(json);
            WinData level = JsonConvert.DeserializeObject<WinData>(json);
            return level;
        }

    }

    [Serializable]
    public class WinMatchItem
    {
        //[JsonConverter(typeof(StringEnumConverter))]
        [field: SerializeField] 
        public ItemType itemId { get; set; }
        [field: SerializeField] 
        public int count { get; set; }
    }

    [Serializable]
    public class WinData
    {
        public string levelId { get; set; }
        public string winColor { get; set; }
        public List<WinMatchItem> winMatch { get; set; }

    }

    [Serializable]
    public class WinData2
    {
        [field: SerializeField] public string levelId { get; set; }

        [field: SerializeField] public Color winColor { get; set; }
        [field: SerializeField] public List <WinMatchItem > winMatch { get; set; }


        /*public class Root
        {
            public WinData WinData { get; set; }
        }*/





    }
}