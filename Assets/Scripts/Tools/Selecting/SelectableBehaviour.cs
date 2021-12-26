using UnityEngine;

namespace FR.Tools.Selecting
{
    public class SelectableBehaviour : MonoBehaviour, ISelectable
    {
        public virtual void BeginSelectSuccess() { }

        public virtual void ConfirmSelectSuccess() { }

        public virtual void CancelSelectSuccess() { }
        
        public virtual void DeselectSuccess() { }
    }
}