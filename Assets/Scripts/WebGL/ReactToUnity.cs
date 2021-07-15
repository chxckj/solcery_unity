using System;
using System.Collections.Generic;
using Solcery.Modules.Board;
using Solcery.Modules.Collection;
using Solcery.Modules.Wallet;
using Solcery.Utils;
using UnityEngine;
using Newtonsoft.Json;

namespace Solcery.WebGL
{
    public class ReactToUnity : Singleton<ReactToUnity>
    {
        public static Action<CardCreationSignData> OnCardCreationSignDataChanged;
        public static Action<CardCreationConfirmData> OnCardCreationConfirmDataChanged;

        public void SetWalletConnected(string data)
        {
            var connectionData = JsonUtility.FromJson<WalletConnectionData>(data);
            Wallet.Instance.Connection.IsConnected.Value = connectionData.IsConnected;
        }

        public void UpdateCollection(string collectionJson)
        {
            var collectionData = JsonConvert.DeserializeObject<CollectionData>(collectionJson);
            Collection.Instance?.UpdateCollection(collectionData.Prettify());
        }

        public void UpdateBoard(string boardJson)
        {
            var boardData = JsonConvert.DeserializeObject<BoardData>(boardJson);
            Board.Instance?.UpdateBoard(boardData.Prettify());
        }

        public void SetCardCreationSigned(string signJson)
        {
            var signData = JsonUtility.FromJson<CardCreationSignData>(signJson);
            OnCardCreationSignDataChanged?.Invoke(signData);
        }

        public void SetCardCreationConfirmed(string confirmJson)
        {
            var confirmData = JsonUtility.FromJson<CardCreationConfirmData>(confirmJson);
            OnCardCreationConfirmDataChanged?.Invoke(confirmData);
        }

#if UNITY_EDITOR
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Debug.Log("1");

                var boardData = new BoardData();

                boardData.CardTypes = new List<BoardCardType>()
                {
                    new BoardCardType() { Id = 0, Metadata = new CardMetadata() { Picture = 0, Name = "0", Coins = 0, Description = "Some longass description right here very very long so we can see how this font resizes"} },
                    new BoardCardType() { Id = 1, Metadata = new CardMetadata() { Picture = 1, Name = "1", Coins = 1, Description = "Some longass description right here very very long so we can see how this font resizes"} },
                    new BoardCardType() { Id = 2, Metadata = new CardMetadata() { Picture = 2, Name = "2", Coins = 2, Description = "Some longass description right here very very long so we can see how this font resizes"} },
                    new BoardCardType() { Id = 3, Metadata = new CardMetadata() { Picture = 3, Name = "3", Coins = 3, Description = "Some longass description right here very very long so we can see how this font resizes"} },
                    new BoardCardType() { Id = 4, Metadata = new CardMetadata() { Picture = 4, Name = "4", Coins = 4, Description = "Some longass description right here very very long so we can see how this font resizes"} },
                    new BoardCardType() { Id = 5, Metadata = new CardMetadata() { Picture = 5, Name = "5", Coins = 5, Description = "Some longass description right here very very long so we can see how this font resizes"} },
                    new BoardCardType() { Id = 6, Metadata = new CardMetadata() { Picture = 6, Name = "6", Coins = 6, Description = "Some longass description right here very very long so we can see how this font resizes"} },
                    new BoardCardType() { Id = 7, Metadata = new CardMetadata() { Picture = 7, Name = "7", Coins = 7, Description = "Some longass description right here very very long so we can see how this font resizes"} },
                };

                boardData.Cards = new List<BoardCardData>() {
                    new BoardCardData() { CardId = 0, CardPlace = CardPlace.Nowhere, CardType = 0},
                    new BoardCardData() { CardId = 1, CardPlace = CardPlace.Hand1, CardType = 1},
                    new BoardCardData() { CardId = 2, CardPlace = CardPlace.Hand2, CardType = 2},
                    new BoardCardData() { CardId = 3, CardPlace = CardPlace.DrawPile1, CardType = 3},
                    new BoardCardData() { CardId = 4, CardPlace = CardPlace.DrawPile2, CardType = 4},
                    new BoardCardData() { CardId = 5, CardPlace = CardPlace.Shop, CardType = 5},
                    new BoardCardData() { CardId = 6, CardPlace = CardPlace.DrawPile2, CardType = 6},
                    new BoardCardData() { CardId = 2, CardPlace = CardPlace.Hand2, CardType = 3},
                    new BoardCardData() { CardId = 2, CardPlace = CardPlace.Hand2, CardType = 3},
                    new BoardCardData() { CardId = 2, CardPlace = CardPlace.Hand2, CardType = 4},
                    new BoardCardData() { CardId = 2, CardPlace = CardPlace.Hand2, CardType = 4},
                    new BoardCardData() { CardId = 2, CardPlace = CardPlace.Hand2, CardType = 5},
                    new BoardCardData() { CardId = 2, CardPlace = CardPlace.PlayedThisTurn, CardType = 4},
                    new BoardCardData() { CardId = 2, CardPlace = CardPlace.PlayedThisTurn, CardType = 4},
                    new BoardCardData() { CardId = 2, CardPlace = CardPlace.PlayedThisTurn, CardType = 5},
                    new BoardCardData() { CardId = 2, CardPlace = CardPlace.PlayedThisTurn, CardType = 4},
                    new BoardCardData() { CardId = 2, CardPlace = CardPlace.PlayedThisTurn, CardType = 4},
                    new BoardCardData() { CardId = 2, CardPlace = CardPlace.PlayedThisTurn, CardType = 5},
                    new BoardCardData() { CardId = 2, CardPlace = CardPlace.Deck, CardType = 5},
                    new BoardCardData() { CardId = 2, CardPlace = CardPlace.Deck, CardType = 4},
                    new BoardCardData() { CardId = 2, CardPlace = CardPlace.Deck, CardType = 4},
                    new BoardCardData() { CardId = 2, CardPlace = CardPlace.Deck, CardType = 5},
                    new BoardCardData() { CardId = 7, CardPlace = CardPlace.PlayedThisTurnTop, CardType = 7},
                };

                boardData.Players = new List<PlayerData>() {
                    // new PlayerData() { IsMe = false, IsActive = true, HP = 15, Coins = 36 },
                    new PlayerData() { IsMe = true, IsActive = true, HP = 7, Coins = 12 }
                };

                Board.Instance?.UpdateBoard(boardData.Prettify());
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Debug.Log("2");

                var boardData = new BoardData();

                boardData.CardTypes = new List<BoardCardType>()
                {
                    new BoardCardType() { Id = 0, Metadata = new CardMetadata() { Picture = 10, Name = "10", Coins = 0} },
                    new BoardCardType() { Id = 1, Metadata = new CardMetadata() { Picture = 11, Name = "11", Coins = 1} },
                    new BoardCardType() { Id = 2, Metadata = new CardMetadata() { Picture = 12, Name = "12", Coins = 2} },
                    new BoardCardType() { Id = 3, Metadata = new CardMetadata() { Picture = 13, Name = "13", Coins = 3} },
                    new BoardCardType() { Id = 4, Metadata = new CardMetadata() { Picture = 14, Name = "14", Coins = 4} },
                };

                boardData.Cards = new List<BoardCardData>() {
                    new BoardCardData() { CardId = 0, CardPlace = CardPlace.Nowhere, CardType = 0},
                    new BoardCardData() { CardId = 1, CardPlace = CardPlace.Hand1, CardType = 1},
                    new BoardCardData() { CardId = 2, CardPlace = CardPlace.Hand2, CardType = 2},
                    new BoardCardData() { CardId = 3, CardPlace = CardPlace.DrawPile1, CardType = 3},
                    new BoardCardData() { CardId = 4, CardPlace = CardPlace.DrawPile2, CardType = 4},
                    new BoardCardData() { CardId = 5, CardPlace = CardPlace.Shop, CardType = 4},
                    new BoardCardData() { CardId = 6, CardPlace = CardPlace.DrawPile2, CardType = 3},
                    new BoardCardData() { CardId = 7, CardPlace = CardPlace.Hand2, CardType = 3},
                    new BoardCardData() { CardId = 8, CardPlace = CardPlace.Hand2, CardType = 3},
                    new BoardCardData() { CardId = 9, CardPlace = CardPlace.Hand2, CardType = 4},
                    new BoardCardData() { CardId = 10, CardPlace = CardPlace.Hand2, CardType = 4},
                    new BoardCardData() { CardId = 11, CardPlace = CardPlace.Hand2, CardType = 5},
                    new BoardCardData() { CardId = 12, CardPlace = CardPlace.Hand2, CardType = 3},
                    new BoardCardData() { CardId = 13, CardPlace = CardPlace.Hand2, CardType = 4},
                    new BoardCardData() { CardId = 14, CardPlace = CardPlace.Hand2, CardType = 4},
                    new BoardCardData() { CardId = 15, CardPlace = CardPlace.Hand2, CardType = 5},
                    new BoardCardData() { CardId = 16, CardPlace = CardPlace.Hand1, CardType = 3},
                    new BoardCardData() { CardId = 17, CardPlace = CardPlace.Hand1, CardType = 4},
                    new BoardCardData() { CardId = 18, CardPlace = CardPlace.Hand1, CardType = 4},
                    new BoardCardData() { CardId = 19, CardPlace = CardPlace.Hand1, CardType = 5},
                    new BoardCardData() { CardId = 20, CardPlace = CardPlace.PlayedThisTurn, CardType = 4},
                    new BoardCardData() { CardId = 20, CardPlace = CardPlace.PlayedThisTurn, CardType = 4},
                    new BoardCardData() { CardId = 20, CardPlace = CardPlace.PlayedThisTurn, CardType = 4},
                    // new BoardCardData() { CardId = 20, CardPlace = CardPlace.PlayedThisTurnTop, CardType = 4},
                };

                boardData.Players = new List<PlayerData>() {
                    new PlayerData() { IsMe = false, IsActive = true, HP = 6, Coins = 88 },
                    new PlayerData() { IsMe = true, IsActive = false, HP = 19, Coins = 4 }
                };

                Board.Instance?.UpdateBoard(boardData.Prettify());
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Debug.Log("3");
                Board.Instance?.UpdateBoard(null);
            }

            if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                var collectionData = new CollectionData();

                collectionData.CardTypes = new List<CollectionCardType>() {
                    new CollectionCardType() { MintAddress = "1", Metadata = new CardMetadata() { Picture = 1, Coins = 1, Name = "1", Description = "1"}},
                    new CollectionCardType() { MintAddress = "2", Metadata = new CardMetadata() { Picture = 2, Coins = 2, Name = "2", Description = "2"}},
                    new CollectionCardType() { MintAddress = "3", Metadata = new CardMetadata() { Picture = 3, Coins = 3, Name = "3", Description = "3"}},
                };

                Collection.Instance?.UpdateCollection(collectionData);
            }

            if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                var collectionData = new CollectionData();

                collectionData.CardTypes = new List<CollectionCardType>() {
                    new CollectionCardType() { MintAddress = "1", Metadata = new CardMetadata() { Picture = 1, Coins = 1, Name = "1", Description = "1"}},
                    new CollectionCardType() { MintAddress = "2", Metadata = new CardMetadata() { Picture = 2, Coins = 2, Name = "2", Description = "2"}},
                    new CollectionCardType() { MintAddress = "3", Metadata = new CardMetadata() { Picture = 3, Coins = 3, Name = "3", Description = "3"}},
                    new CollectionCardType() { MintAddress = "4", Metadata = new CardMetadata() { Picture = 4, Coins = 4, Name = "4", Description = "4"}},
                    new CollectionCardType() { MintAddress = "5", Metadata = new CardMetadata() { Picture = 5, Coins = 5, Name = "5", Description = "5"}},
                    new CollectionCardType() { MintAddress = "6", Metadata = new CardMetadata() { Picture = 6, Coins = 6, Name = "6", Description = "6"}},
                    new CollectionCardType() { MintAddress = "7", Metadata = new CardMetadata() { Picture = 7, Coins = 7, Name = "7", Description = "7"}},
                    new CollectionCardType() { MintAddress = "8", Metadata = new CardMetadata() { Picture = 8, Coins = 8, Name = "8", Description = "8"}},
                    new CollectionCardType() { MintAddress = "9", Metadata = new CardMetadata() { Picture = 9, Coins = 9, Name = "9", Description = "9"}},
                };

                Collection.Instance?.UpdateCollection(collectionData);
            }

            if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                var collectionData = new CollectionData();

                collectionData.CardTypes = new List<CollectionCardType>() {
                    new CollectionCardType() { MintAddress = "1",  Metadata = new CardMetadata() { Picture = 1, Coins = 1, Name = "1", Description = "1"}},
                    new CollectionCardType() { MintAddress = "2", Metadata = new CardMetadata() { Picture = 2, Coins = 2, Name = "2", Description = "2"}},
                    new CollectionCardType() { MintAddress = "3", Metadata = new CardMetadata() { Picture = 3, Coins = 3, Name = "3", Description = "3"}},
                    new CollectionCardType() { MintAddress = "4", Metadata = new CardMetadata() { Picture = 4, Coins = 4, Name = "4", Description = "4"}},
                };

                Collection.Instance?.UpdateCollection(collectionData);
            }
        }
#endif
    }
}
