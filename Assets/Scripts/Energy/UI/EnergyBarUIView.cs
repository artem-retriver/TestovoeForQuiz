using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class EnergyBarUIView : UIView<EnergyBarUIViewModel>
{
    [SerializeField] private TMP_Text energyText;
    [SerializeField] private Image progressBar;
    [SerializeField] private Button spendButton;

    private readonly CompositeDisposable _disposables = new CompositeDisposable();

    public override void Initialize()
    {
        _disposables.Add(ViewModel.Current.Subscribe(UpdateEnergy));
        _disposables.Add(ViewModel.SecondsToNext.Subscribe(UpdateProgress));

        spendButton.onClick.AddListener(OnSpendClicked);
    }

    public override void Release()
    {
        spendButton.onClick.RemoveListener(OnSpendClicked);

        _disposables.Dispose();
    }

    private void UpdateEnergy(int current)
    {
        energyText.text = $"{current} / {ViewModel.MaxEnergy}";
    }

    private void UpdateProgress(float progress)
    {
        progressBar.fillAmount = progress;
    }

    private void OnSpendClicked()
    {
        ViewModel.SpendTen();
    }
}