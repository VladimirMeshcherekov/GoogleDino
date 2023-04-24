using UnityEngine;
using Zenject;

public class PlayerRunInstaller : MonoInstaller
{
    [SerializeField] private PlayerRun _playerRun;
    public override void InstallBindings()
    {
        Container.Bind<PlayerRun>().FromInstance(_playerRun).AsSingle().NonLazy();
    }
}