using EPOOutline;
using UnityEngine;

namespace FR.Tools.Juice
{
    public class Outline: MonoBehaviour
    {
        [SerializeField] private Outlinable _outlinable;

        public void SetOutlinable(Outlinable outlinable)
        {
            _outlinable = outlinable;
        }

        public void SetColor(Color color)
        {
            _outlinable.OutlineParameters.Color = color;
        }

        public void Show()
        {
            _outlinable.enabled = true;
        }

        public void Hide()
        {
            _outlinable.enabled = false;
        }
        
        
    }
}