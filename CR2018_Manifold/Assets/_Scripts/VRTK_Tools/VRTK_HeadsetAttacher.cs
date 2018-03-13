using UnityEngine;
using VRTK;

namespace CR18_Manifold
{
    public class VRTK_HeadsetAttacher : MonoBehaviour
    {
        private bool _isAttached = false;
        protected virtual void Awake()
        {
            VRTK_SDKManager.instance.AddBehaviourToToggleOnLoadedSetupChange(this);
        }

        protected virtual void OnEnable()
        {
            if (!_isAttached)
            {
                var headset = VRTK_DeviceFinder.HeadsetTransform();
                if (headset)
                {
                    this.transform.SetParent(headset.transform);
                    this.transform.localPosition = Vector3.zero;
                    this.transform.localRotation = Quaternion.identity;
                    _isAttached = true;
                }
            }
        }

        protected virtual void OnDisable()
        {
            
        }

        protected virtual void OnDestroy()
        {
            VRTK_SDKManager.instance.RemoveBehaviourToToggleOnLoadedSetupChange(this);
        }
    }
}