namespace FR.Tools.Selecting
{
    public interface ISelectionHandler<TCell>
    {
        public void BeginSelectSuccess(TCell cell);

        public void ConfirmSelectSuccess(TCell cell);

        public void CancelSelectSuccess(TCell cell);

        public void DeselectSuccess(TCell cell);
    }
}