using UnityEngine;

namespace FR.Tools.Selecting
{
    public interface ISelectable
    {
        public void HoverEnter();
        public void HoverExit();
        public void Select();
        public void Deselect();
    }
}