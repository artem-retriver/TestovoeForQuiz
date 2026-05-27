public sealed class EnergyBarUIViewModel : IUIViewModel
{
    private readonly IEnergyService _energyService;
    private readonly EnergySettings _settings;

    public IReadOnlyReactiveValue<int> Current => _energyService.Current;
    public IReadOnlyReactiveValue<float> SecondsToNext => _energyService.SecondsToNext;

    public int MaxEnergy => _settings.MaxEnergy;

    public EnergyBarUIViewModel(IEnergyService energyService, EnergySettings settings)
    {
        _energyService = energyService;
        _settings = settings;
    }

    public void SpendTen()
    {
        _energyService.TrySpend(10);
    }
}