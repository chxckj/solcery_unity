using Solcery.Utils;
using Solcery.WebGL;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Solcery.UI.Create
{
    public class UICreatingCardPopup : Singleton<UICreatingCardPopup>
    {
        [SerializeField] private CardPictures cardPictures = null;
        [SerializeField] Canvas canvas = null;
        [SerializeField] private TextMeshProUGUI popupTitleText = null;
        [SerializeField] private TextMeshProUGUI cardNameText = null;
        [SerializeField] private TextMeshProUGUI cardDescriptionText = null;
        [SerializeField] private Image cardPictureImage = null;
        [SerializeField] private UICreatingCardPopupStatusPanel signTransactionStatus = null;
        [SerializeField] private UICreatingCardPopupStatusPanel confirmTransactionStatus = null;
        [SerializeField] private Button okButton = null;

        public void Open(CardMetadata cardMetadata)
        {
            canvas.enabled = true;

            if (popupTitleText != null) popupTitleText.text = "Creating card";
            if (cardNameText != null) cardNameText.text = cardMetadata.Name;
            if (cardDescriptionText != null) cardDescriptionText.text = cardMetadata.Description;
            if (cardPictureImage != null) cardPictureImage.sprite = cardPictures.GetSpriteByIndex(cardMetadata.Picture);

            signTransactionStatus?.SetState(UIStatusState.Waiting);
            confirmTransactionStatus?.SetState(UIStatusState.Waiting);

            ReactToUnity.OnCardCreationSignDataChanged += OnCardCreationSignDataChanged;
            ReactToUnity.OnCardCreationConfirmDataChanged += OnCardCreationConfirmDataChanged;

            okButton.onClick.AddListener(() => { Close(); });
        }

        private void Close()
        {
            ReactToUnity.OnCardCreationSignDataChanged -= OnCardCreationSignDataChanged;
            ReactToUnity.OnCardCreationConfirmDataChanged -= OnCardCreationConfirmDataChanged;

            okButton.onClick.RemoveAllListeners();
            canvas.enabled = false;
        }

        private void OnCardCreationSignDataChanged(CardCreationSignData signData)
        {
            signTransactionStatus?.SetState(signData.IsSigned ? UIStatusState.Success : UIStatusState.Fail);
            if (!signData.IsSigned && popupTitleText != null) popupTitleText.text = "Creation failed";
        }

        private void OnCardCreationConfirmDataChanged(CardCreationConfirmData confirmData)
        {
            confirmTransactionStatus?.SetState(confirmData.IsConfirmed ? UIStatusState.Success : UIStatusState.Fail);
            popupTitleText.text = confirmData.IsConfirmed ? "Card created" : "Creation failed";
        }
    }
}
