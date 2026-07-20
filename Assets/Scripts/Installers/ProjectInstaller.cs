using UnityEngine;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    [SerializeField] private Transform _playerTransform;


    public override void InstallBindings()
    {
        Container.Bind<PlayerHealth>().AsSingle();
        var playerHealth = Container.Resolve<PlayerHealth>();
        var playerContext = new PlayerContext(_playerTransform, playerHealth);

        Container.Bind<PlayerContext>().FromInstance(playerContext).AsSingle();
    }
}
