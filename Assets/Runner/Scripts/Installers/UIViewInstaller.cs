using Runner.UI;
using UnityEngine;
using Zenject;

namespace Runner.Installers
{
    public class UIViewInstaller : MonoInstaller
    {
        [SerializeField]
        private DynamicJoystick _joystick;
        [SerializeField]
        private UIPauseView _pauseWindow;
        [SerializeField]
        private UIInGameMenu _inGameMenu;

        public override void InstallBindings()
        {
            Container.Bind<DynamicJoystick>().FromInstance(_joystick).AsSingle();
            Container.Bind<UIPauseView>().FromInstance(_pauseWindow).AsSingle();
            Container.Bind<UIInGameMenu>().FromInstance(_inGameMenu).AsSingle();
        }
    }
}
