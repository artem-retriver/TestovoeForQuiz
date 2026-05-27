public interface IEnergyService : IService
{
    IReadOnlyReactiveValue<int> Current { get; }
    IReadOnlyReactiveValue<float> SecondsToNext { get; }

    bool TrySpend(int amount);
}