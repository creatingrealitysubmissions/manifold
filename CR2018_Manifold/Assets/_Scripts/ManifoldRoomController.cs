using UnityEngine;
using UnityEngine.Events;

namespace CR18_Manifold
{
    public class ManifoldRoomController : MonoBehaviour
    {
        public bool IsEnabled = false;
        public UnityEvent OnEnableRoom;
        public UnityEvent OnDisableRoom;

        void Start()
        {
            SetRoomEnabled(IsEnabled);
        }

        public void EnableRoom()
        {
            if (IsEnabled) return;
            SetRoomEnabled(true);
        }

        public void DisableRoom()
        {
            if(!IsEnabled) return;
            SetRoomEnabled(false);
        }

        public void ToggleRoom()
        {
            SetRoomEnabled(!IsEnabled);
        }

        public void SetRoomEnabled(bool state)
        {
            
            IsEnabled = state;
            if (IsEnabled)
            {
                OnEnableRoom.Invoke();
            }
            else
            {
                OnDisableRoom.Invoke();
            }
        }
    }
}