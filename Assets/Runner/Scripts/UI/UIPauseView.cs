using UnityEngine;
using UnityEngine.UI;

namespace Runner.UI
{
    public class UIPauseView : MonoBehaviour
    {
        [SerializeField]
        private Button _playBtn;        

        void Awake()
        {
            _playBtn.onClick.AddListener(() => {
                Time.timeScale = 1f;
                gameObject.SetActive(false);
            });
        }

        public void Show() => gameObject.SetActive(true);        
    }
}
