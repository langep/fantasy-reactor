using UnityEngine;

namespace FR.Tools.Selecting
{
    public interface ISelectable
    {

        public void BeginSelectSuccess();

        public void ConfirmSelectSuccess();

        public void CancelSelectSuccess();

        public void DeselectSuccess();
    }
}