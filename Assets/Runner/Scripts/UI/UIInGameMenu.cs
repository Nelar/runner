using Runner.Controllers;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Runner.UI
{
    public class UIInGameMenu : MonoBehaviour
    {
        [SerializeField]
        private Button _pauseBtn;

        [Inject]
        public void Init(PlayerController player, UIPauseView pauseWindow)
        {
            _pauseBtn.onClick.AddListener(() => {
                Time.timeScale = 0f;
                pauseWindow.Show();
            });            
        }
    }
}
