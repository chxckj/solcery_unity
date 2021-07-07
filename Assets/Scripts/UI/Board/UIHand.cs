using System.Collections.Generic;
using UnityEngine;

namespace Solcery.UI.Play
{
    public abstract class UIHand : MonoBehaviour
    {
        [SerializeField] private GameObject cardPrefab = null;
        [SerializeField] private Transform content = null;

        private List<UIBoardCard> _cardsInHand;

        protected void UpdateCards(List<BoardCardData> cards, bool areButtonsInteractable)
        {
            DeleteAllCards();

            if (cards == null)
                return;

            foreach (var cardData in cards)
            {
                var card = Instantiate(cardPrefab, content).GetComponent<UIBoardCard>();
                card.Init(cardData, areButtonsInteractable, OnCardCasted);

                _cardsInHand.Add(card);
            }
        }

        protected abstract void OnCardCasted(int cardId);

        public void DeleteAllCards()
        {
            if (_cardsInHand != null && _cardsInHand.Count > 0)
            {
                for (int i = _cardsInHand.Count - 1; i >= 0; i--)
                {
                    _cardsInHand[i].DeInit();
                    DestroyImmediate(_cardsInHand[i].gameObject);
                }
            }

            _cardsInHand = new List<UIBoardCard>();
        }
    }
}