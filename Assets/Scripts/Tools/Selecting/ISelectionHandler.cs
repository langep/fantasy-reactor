namespace FR.Tools.Selecting
{
    public interface ISelectionHandler<TSelectable> where TSelectable : ISelectable
    {
        public void OnHoverEnter(TSelectable cell);
        public void OnHoverExit(TSelectable cell);
        public void OnSelect(TSelectable cell);
        public void OnDeselect(TSelectable cell);
    }
}