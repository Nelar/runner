using Runner.Controllers;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Runner.UI
{
    public class UIPauseView : MonoBehaviour
    {
        [SerializeField]
        private Button _playBtn;

        private void Awake() => Time.timeScale = 0f;

        [Inject]
        public void Init(PlayerController player)
        {
            _playBtn.onClick.AddListener(() => {
                Time.timeScale = 1f;
                gameObject.SetActive(false);
            });
        }

        public void Show() => gameObject.SetActive(true);        
    }
}
