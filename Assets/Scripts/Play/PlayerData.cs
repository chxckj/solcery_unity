using System;
using System.Collections.Generic;

namespace Solcery
{
    [Serializable]
    public class PlayerData
    {
        public int PlayerId;
        public bool IsMe;
        public string Address;
        public bool IsActive;
        public int HP;
        public int Coins;
        public List<int> Attrs; // TODO: key = string?

        public PlayerStatus Status;
        public PlayerOutcome Outcome;
    }
}