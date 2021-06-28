using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Solcery.UI.Create.NodeEditor
{
    public class UIBrickNodeHighlighter : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Image highlighter = null;

        private Action _onHighlighted, _onDeHighlighted = null;

        public void Init(Action onHighlighted, Action onDeHighlighted)
        {
            _onHighlighted = onHighlighted;
            _onDeHighlighted = onDeHighlighted;
        }

        public void DeInit()
        {
            _onHighlighted = null;
            _onDeHighlighted = null;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _onHighlighted?.Invoke();
            HighlighVisuals(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _onDeHighlighted?.Invoke();
            HighlighVisuals(false);
        }

        private void HighlighVisuals(bool isActive)
        {
            highlighter.gameObject.SetActive(isActive);
        }
    }
}