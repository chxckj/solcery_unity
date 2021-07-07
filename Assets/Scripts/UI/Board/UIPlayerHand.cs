using System.Collections.Generic;
using Solcery.WebGL;

namespace Solcery.UI.Play
{
    public class UIPlayerHand : UIHand
    {
        public void UpdateCards(List<BoardCardData> cards, bool isPlayer, bool isActive)
        {
            base.UpdateCards(cards, areButtonsInteractable: isPlayer);
        }

        protected override void OnCardCasted(int cardId)
        {
            UnityToReact.Instance.CallUseCard(cardId);
        }
    }
}