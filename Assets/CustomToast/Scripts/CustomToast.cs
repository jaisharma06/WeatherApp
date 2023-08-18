using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Toast
{
    public class CustomToast : MonoBehaviour
    {
        [SerializeField] private Text m_messageText;
        [SerializeField] private float m_showPos = 520f;
        [SerializeField] private float m_hidePos = -520f;
        [SerializeField] private float m_speed = 1f;

        private Vector2 _workspace;
        private RectTransform _rectTransform;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            HideImmediately();
        }

        public void Show(string message, float duration = 7f)
        {
            CancelInvoke(nameof(Hide));
            m_messageText.text = message;
            Slide(m_hidePos, m_showPos);
            Invoke(nameof(Hide), duration);
        }

        private void Hide()
        {
            Slide(m_showPos, m_hidePos);
        }

        private void HideImmediately()
        {
            _workspace = _rectTransform.anchoredPosition;
            _workspace.y = m_hidePos;
            _rectTransform.anchoredPosition = _workspace;
        }

        private Coroutine _slideCoroutine;
        private void Slide(float initialPos, float targetPos)
        {
            if(_slideCoroutine != null )
            {
                StopCoroutine( _slideCoroutine );
            }

            _slideCoroutine = StartCoroutine(IE_Slide(initialPos, targetPos));
        }

        private IEnumerator IE_Slide(float initialPos, float targetPos)
        {
            _workspace = _rectTransform.anchoredPosition;
            _workspace.y = initialPos;
            _rectTransform.anchoredPosition = _workspace;
            while(Mathf.Abs(_workspace.y - targetPos) >= 0.01f)
            {
                _workspace.y = Mathf.MoveTowards(_workspace.y, targetPos, Time.deltaTime * m_speed * 100);
                _rectTransform.anchoredPosition = _workspace;
                yield return null;
            }

            _workspace.y = targetPos;
            _rectTransform.anchoredPosition = _workspace;
        }
    }

}
