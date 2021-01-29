namespace WPF.MVVM
{
    // interfejs dla klasy odpowiadającej za powiązanie viewmodelu z widokiem
    public interface IWindowService
    {
        // wyświetlanie okna niemodalnego
        void Show(IViewModel viewModel);

        // wyświetlanie okna modalnego
        void ShowDialog(IViewModel viewModel);
    }
}
