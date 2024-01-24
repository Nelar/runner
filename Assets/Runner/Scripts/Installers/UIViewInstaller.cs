using Runner.UI;
using UnityEngine;
using Zenject;

namespace Runner.Installers
{
    public class UIViewInstaller : MonoInstaller
    {
        [SerializeField]
        VariableJoystick _joystick;
        [SerializeField]
        UIPauseView _pauseWindow;
        [SerializeField]
        UIInGameMenu _inGameMenu;

        public override void InstallBindings()
        {
            Container.Bind<VariableJoystick>().FromInstance(_joystick).AsSingle();
            Container.Bind<UIPauseView>().FromInstance(_pauseWindow).AsSingle();
            Container.Bind<UIInGameMenu>().FromInstance(_inGameMenu).AsSingle();
        }
    }
}
