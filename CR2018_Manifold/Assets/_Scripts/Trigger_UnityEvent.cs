using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CR18_Manifold
{
    public class Trigger_UnityEvent : MonoBehaviour
    {
        public UnityEvent OnEnterEvent;
        public UnityEvent OnExitEvent;

        public string TriggerTag = "Player";
        private GameObject cachedGameObject;

        private void OnTriggerEnter(Collider other)
        {
            if (cachedGameObject) return;
            if (other.CompareTag(TriggerTag))
            {
                cachedGameObject = other.attachedRigidbody ? other.attachedRigidbody.gameObject : other.gameObject;
                OnEnterEvent.Invoke();
            }

        }
        private void OnTriggerExit(Collider other)
        {
            if (!cachedGameObject) return;
            if (other.CompareTag(TriggerTag))
            {
                var go = other.attachedRigidbody ? other.attachedRigidbody.gameObject : other.gameObject;
                if (go == cachedGameObject)
                {
                    OnEnterEvent.Invoke();
                    cachedGameObject = null;
                }
            }
        }
    }

}

