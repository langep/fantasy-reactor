using System.Collections.Generic;

namespace FR.Tools.Selecting
{
    public class Selector<TSelection> where TSelection : Selection, new()
    {
        
        private TSelection _selection = new TSelection();

        public void BeginSelect(Selectable selectable)
        {
            var success = _selection.CanAdd(selectable);
            selectable.BeginSelect(success);
        }

        public void ConfirmSelect(Selectable selectable)
        {
            var success = _selection.TryAdd(selectable);
            selectable.ConfirmSelect(success);
        }

        public void CancelSelect(Selectable selectable)
        {
            selectable.CancelSelect(true);
        }

        public void Deselect(Selectable selectable)
        {
            var success = _selection.TryRemove(selectable);
            selectable.Deselect(success);
        }
        
        public IEnumerable<Selectable> GetAll()
        {
            return _selection.GetAll();
        }

        public bool IsEmpty()
        {
            return _selection.IsEmpty();
        }
        
        public bool Contains(Selectable selectable)
        {
            return _selection.Contains(selectable);
        }
    }
}