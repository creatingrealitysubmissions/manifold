using UnityEngine;
using System.Collections;
using Leap.Unity.Space;

public class LeapHandHack : MonoBehaviour
{
    public LeapSpace leapSpace;
    // Use this for initialization
    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.5f);
        if (leapSpace)
        {
            
        }
    }
    
}
