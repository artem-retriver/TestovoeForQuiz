using System;
using System.Threading;
using UnityEngine;
using VContainer;

public sealed class GameBootstrap : MonoBehaviour
{
    [Inject] private IEnergyService _energyService;
    [Inject] private EnergyBarUIViewModel _viewModel;
    [Inject] private EnergyBarUIView _view;

    private CancellationTokenSource _cts;

    private async void Start()
    {
        try
        {
            _cts = new CancellationTokenSource();

            await _energyService.InitializeAsync(_cts.Token);

            _view.Construct(_viewModel);
            _view.Initialize();
        }
        catch (Exception exception)
        {
            Debug.LogException(exception);
        }
    }

    private async void OnDestroy()
    {
        try
        {
            _view?.Release();

            _cts?.Cancel();

            if (_energyService != null)
            {
                await _energyService.ReleaseAsync(CancellationToken.None);
            }

            _cts?.Dispose();
        }
        catch (Exception exception)
        {
            Debug.LogException(exception);
        }
    }
}