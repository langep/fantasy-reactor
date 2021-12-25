using System.Collections.Generic;

namespace FR.Tools.Selecting
{
    public class Selection
    {
        protected readonly HashSet<Selectable> selection = new HashSet<Selectable>();

        public virtual bool TryAdd(Selectable selectable)
        {
            if (!CanAdd(selectable)) return false;
            selection.Add(selectable);
            return true;
        }

        public virtual bool TryRemove(Selectable selectable)
        {
            return CanRemove(selectable) && selection.Remove(selectable);
        }
        
        public virtual bool CanAdd(Selectable selectable)
        {
            return true;
        }
        
        public virtual bool CanRemove(Selectable selectable)
        {
            return true;
        }
        
        public IEnumerable<Selectable> GetAll()
        {
            return selection;
        }

        public bool IsEmpty()
        {
            return selection.Count == 0;
        }
        
        public bool Contains(Selectable selectable)
        {
            return selection.Contains(selectable);
        }
    }
}