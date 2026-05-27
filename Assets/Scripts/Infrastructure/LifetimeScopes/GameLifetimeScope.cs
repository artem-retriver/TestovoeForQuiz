using UnityEngine;
using VContainer;
using VContainer.Unity;

public sealed class GameLifetimeScope : LifetimeScope
{
    [SerializeField] private EnergySettings energySettings;
    [SerializeField] private EnergyBarUIView energyBarView;
    [SerializeField] private GameBootstrap gameBootstrap;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterInstance(energySettings);

        builder.Register<EnergyService>(Lifetime.Singleton).As<IEnergyService>();

        builder.Register<EnergyBarUIViewModel>(Lifetime.Singleton);

        builder.RegisterComponent(energyBarView);

        builder.RegisterComponent(gameBootstrap);
    }
}