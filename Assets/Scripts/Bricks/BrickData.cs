using System;
using System.Linq;
using System.Collections.Generic;

namespace Solcery
{
    public class BrickData
    {
        public bool IsValid()
        {
            if (Slots.Length == 0)
                return true;
            else
            {
                var areSlotsValid = true;

                foreach (var slot in Slots)
                {
                    if (slot == null)
                        return false;
                    else
                    {
                        if (!slot.IsValid())
                            areSlotsValid = false;
                    }

                }

                return areSlotsValid;
            }
        }

        public int Type = -1;
        public int Subtype = -1;
        public int Object = 0;

        public bool HasField = false;
        public int IntField = 0;
        public string StringField = null;
        public bool HasObjectSelection = false;

        public BrickData[] Slots;

        public BrickData(BrickConfig config)
        {
            Type = (int)config.Type;
            Subtype = BrickConfigs.GetSubtypeIndex(config.Type, config.Subtype);

            HasField = config.HasField;
            HasObjectSelection = config.HasObjectSelection;

            Slots = new BrickData[config.Slots.Count];
        }

        public void SerializeToBytes(ref List<byte> buffer)
        {
            buffer.AddRange(BitConverter.GetBytes(Type).ToList<byte>());
            buffer.AddRange(BitConverter.GetBytes(Subtype).ToList<byte>());
            if (HasObjectSelection)
                buffer.AddRange(BitConverter.GetBytes(Object).ToList<byte>());
            if (HasField)
                buffer.AddRange(BitConverter.GetBytes(IntField).ToList<byte>());
            foreach (BrickData child in Slots)
                child?.SerializeToBytes(ref buffer);
        }

        public int GetDepth()
        {
            if (Slots == null || Slots.Length == 0)
            {
                // UnityEngine.Debug.Log("1");
                return 1;
            }

            var maxDepth = 1;

            foreach (var slot in Slots)
            {
                if (slot == null)
                {
                    // UnityEngine.Debug.Log("2");
                    continue;
                }

                var slotDepth = slot.GetDepth();

                if ((slotDepth + 1) > maxDepth)
                    maxDepth = 1 + slotDepth;
            }

            return maxDepth;
        }
    }

}
