using UnityEngine;

namespace CR18_Manifold
{
    public class LightingController : MonoBehaviour
    {
        public void SetFog(bool state)
        {
            RenderSettings.fog = state;
        }

        public void SetSkybox(Material sbMaterial)
        {
            RenderSettings.skybox = sbMaterial;
        }
    }
}