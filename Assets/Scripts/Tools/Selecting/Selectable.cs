using UnityEngine;

namespace FR.Tools.Selecting
{
    public class Selectable : MonoBehaviour
    {
        public bool IsSelected { get; private set; }

        public void BeginSelectSuccess()
        {
            OnBeginSelectSuccess();
        }

        public void ConfirmSelectSuccess()
        {
            IsSelected = true;
            OnConfirmSelectSuccess();
        }

        public void CancelSelectSuccess()
        {
            if (IsSelected) return;
            OnCancelSelectSuccess();
        }

        public void DeselectSuccess()
        {
            IsSelected = false;
            OnDeselectSuccess();
        }
        
        
        protected virtual void OnBeginSelectSuccess()
        {
            
        }

        protected virtual void OnConfirmSelectSuccess()
        {
            
        }
        
        protected virtual void OnCancelSelectSuccess()
        {
        }

        protected virtual void OnDeselectSuccess()
        {
        }
    }
}