using UnityEngine;
using System.Collections;
using VRTK;

public class ScreenFadeController : MonoBehaviour
{
    public void ScreenFadeOut(float duration)
    {
        VRTK.VRTK_ScreenFade.Start(Color.black, duration);
    }
    public void ScreenFadeIn(float duration)
    {
        VRTK.VRTK_ScreenFade.Start(Color.clear, duration);
    }
}
