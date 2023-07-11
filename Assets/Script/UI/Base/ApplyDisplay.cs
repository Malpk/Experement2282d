public class ApplyDisplay : UIMenu
{
    public event System.Action OnApply;

    public void Aplly()
    {
        OnApply?.Invoke();
        Hide();
    }

}
