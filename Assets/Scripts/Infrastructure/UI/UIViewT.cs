public abstract class UIView<TVm> : UIView where TVm : IUIViewModel
{
    protected TVm ViewModel;

    public void Construct(TVm viewModel)
    {
        ViewModel = viewModel;
    }
}