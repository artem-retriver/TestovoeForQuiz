using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

public sealed class EnergyService : IEnergyService
{
    private readonly EnergySettings _settings;

    private readonly ReactiveValue<int> _current;
    private readonly ReactiveValue<float> _secondsToNext;

    private CancellationTokenSource _cts;

    public IReadOnlyReactiveValue<int> Current => _current;

    public IReadOnlyReactiveValue<float> SecondsToNext => _secondsToNext;

    public EnergyService(EnergySettings settings)
    {
        _settings = settings;

        _current = new ReactiveValue<int>(0);
        _secondsToNext = new ReactiveValue<float>(0f);
    }

    public UniTask InitializeAsync(CancellationToken cancellationToken)
    {
        _cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);

        RunRegenLoopAsync(_cts.Token).Forget();

        return UniTask.CompletedTask;
    }

    public UniTask ReleaseAsync(CancellationToken cancellationToken)
    {
        _cts?.Cancel();
        _cts?.Dispose();
        _cts = null;

        return UniTask.CompletedTask;
    }

    public bool TrySpend(int amount)
    {
        if (amount <= 0)
        {
            return false;
        }

        if (_current.Value < amount)
        {
            return false;
        }

        _current.Value -= amount;

        return true;
    }

    private async UniTaskVoid RunRegenLoopAsync(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            if (_current.Value >= _settings.MaxEnergy)
            {
                _secondsToNext.Value = 0f;

                await UniTask.WaitUntil(
                    () => _current.Value < _settings.MaxEnergy,
                    cancellationToken: cancellationToken);
            }

            float elapsed = 0f;

            while (elapsed < _settings.RegenSeconds)
            {
                cancellationToken.ThrowIfCancellationRequested();

                elapsed += Time.deltaTime;

                float normalized = Mathf.Clamp01(elapsed / _settings.RegenSeconds);

                _secondsToNext.Value = normalized;

                await UniTask.Yield(PlayerLoopTiming.Update, cancellationToken);
            }

            int nextValue = Mathf.Min(_current.Value + 1, _settings.MaxEnergy);

            _current.Value = nextValue;
            _secondsToNext.Value = 0f;
        }
    }
}