using UnityEngine;

namespace FR.Tools.Selecting
{
    public class Selectable : MonoBehaviour
    {
        public bool IsSelected { get; private set; }

        public void BeginSelect(bool success)
        {
            OnBeginSelect(success);
        }

        public void ConfirmSelect(bool success)
        {
            IsSelected = true;
            OnConfirmSelect(success);
        }

        public void CancelSelect(bool success)
        {
            OnCancelSelect(success);
        }

        public void Deselect(bool success)
        {
            IsSelected = false;
            OnDeselect(success);
        }
        
        
        protected virtual void OnBeginSelect(bool success)
        {
            
        }

        protected virtual void OnConfirmSelect(bool success)
        {
            
        }
        
        protected virtual void OnCancelSelect(bool success)
        {
        }

        protected virtual void OnDeselect(bool success)
        {
        }
    }
}