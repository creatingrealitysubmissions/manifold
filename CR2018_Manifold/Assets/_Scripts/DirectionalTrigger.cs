using UnityEngine;
using UnityEngine.Events;

namespace CR18_Manifold
{
    public class DirectionalTrigger : MonoBehaviour
    {
        public string TriggerTag = "Player";
        public UnityEvent OnEnterEvent;
        public UnityEvent OnEnterFrontEvent;
        public UnityEvent OnEnterBackEvent;
        public UnityEvent OnExitEvent;

        private GameObject cachedGameObject;

        private void OnTriggerEnter(Collider other)
        {
            if (!enabled) return;
            if (cachedGameObject) return;
            if (other.CompareTag(TriggerTag))
            {
                var go = other.attachedRigidbody ? other.attachedRigidbody.gameObject : other.gameObject;
                cachedGameObject = go;
                // Check normal of enter and trigger accordingly.
                var diff = go.transform.position - this.transform.position;
                var projDiff = Vector3.ProjectOnPlane(diff, Vector3.up);
                var projForward = Vector3.Project(projDiff, this.transform.forward).normalized;
                var dot = Vector3.Dot(this.transform.forward, projForward);
                //Debug.Log(dot);
                if (dot >= 0.7f)
                {
                    //Debug.Log("Front Enter");
                    OnEnterFrontEvent.Invoke();
                }
                else if (dot <= -0.7f)
                {
                    //Debug.Log("Back Enter");
                    OnEnterBackEvent.Invoke();
                }
                OnEnterEvent.Invoke();
            }

        }
        private void OnTriggerExit(Collider other)
        {
            if (!enabled) return;
            if (!cachedGameObject) return;
            if (other.CompareTag(TriggerTag))
            {
                var go = other.attachedRigidbody ? other.attachedRigidbody.gameObject : other.gameObject;
                if (go == cachedGameObject)
                {
                    //OnEnterEvent.Invoke();
                    cachedGameObject = null;
                }
            }
        }

        
    }
}