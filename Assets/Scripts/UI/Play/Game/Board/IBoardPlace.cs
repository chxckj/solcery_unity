using UnityEngine;

namespace Solcery.UI
{
    public interface IBoardPlace
    {
        bool AreCardsFaceDown { get; }
        Transform GetCardsParent();
        Vector3 GetCardDestination(int cardId);
        Vector3 GetCardRotation(int cardId);
        Vector2 GetCardSize(int cardId);
        void OnCardArrival(int cardId);
    }
}
