using System;
using System.Collections.Generic;

namespace Solcery
{
    [Serializable]
    public class GameDisplay
    {
        public List<PlaceDisplayData> PlaceDisplayDatas = new List<PlaceDisplayData>();

        [NonSerialized] [Newtonsoft.Json.JsonIgnore] public bool HasBeenProcessed;
        [NonSerialized] [Newtonsoft.Json.JsonIgnore] public Dictionary<int, PlaceDisplayData> DisplayDataByPlaceId;

        public GameDisplay Prettify()
        {
            CreateDisplayDataDictionary();

            return this;
        }

        private void CreateDisplayDataDictionary()
        {
            DisplayDataByPlaceId = new Dictionary<int, PlaceDisplayData>();

            foreach (var displayData in PlaceDisplayDatas)
            {
                var placeId = displayData.PlaceId;

                if (DisplayDataByPlaceId.ContainsKey(placeId))
                    DisplayDataByPlaceId[placeId] = displayData;
                else
                    DisplayDataByPlaceId.Add(placeId, displayData);
            }
        }
    }
}