using System;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Solcery.UI
{
    public class UIPile : UIHand
    {
        [SerializeField] private TextMeshProUGUI cardsCountText = null;

        private int _currentCardsCount;

        public new void Clear()
        {
            if (cardsCountText != null) cardsCountText.text = string.Empty;
            base.Clear();
        }

        public void UpdateWithDiff(GameContent gameContent, CardPlaceDiff cardPlaceDiff, int cardsCount)
        {
            // TODO: count +- count here from each diff
            if (_currentCardsCount != cardsCount || (cardPlaceDiff != null && ((cardPlaceDiff.Arrived != null && cardPlaceDiff.Arrived.Count > 0) || (cardPlaceDiff.Departed != null && cardPlaceDiff.Departed.Count > 0))))
                SetCardsCountText(cardsCount).Forget();

            _currentCardsCount = cardsCount;

            base.UpdateWithDiff(gameContent, cardPlaceDiff, false, true, false, true, true);
        }

        private async UniTaskVoid SetCardsCountText(int newCardsCount)
        {
            if (cardsCountText != null)
            {
                if (newCardsCount <= 0)
                    cardsCountText.text = string.Empty;
                else
                {
                    cardsCountText.gameObject?.SetActive(false);
                    await UniTask.Delay(TimeSpan.FromSeconds(0.5f));
                    if (cardsCountText != null)
                    {
                        cardsCountText.text = newCardsCount.ToString();
                        cardsCountText.gameObject?.SetActive(true);
                    }
                }
            }
        }

        // protected override void OnCardCasted(int cardId)
        // {

        // }
    }
}