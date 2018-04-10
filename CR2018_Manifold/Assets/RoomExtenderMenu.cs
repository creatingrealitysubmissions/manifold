using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK;

public class RoomExtenderMenu : MonoBehaviour
{
    public GameObject MenuObject;
    public VRTK_RoomExtender RoomExtender;
    public Slider slider;
    public Text ValueText;

    private bool IsOpen = false;

	void Start ()
	{
	    if (!RoomExtender) RoomExtender = FindObjectOfType<VRTK_RoomExtender>();
	    if (!slider) slider = GetComponentInChildren<Slider>();
	    if (MenuObject) MenuObject = this.gameObject;
        IsOpen = MenuObject.activeInHierarchy;
	    if (RoomExtender && slider)
	    {
	        slider.value = Mathf.InverseLerp(0f, 10f, RoomExtender.additionalMovementMultiplier);
            slider.onValueChanged.AddListener(SetExtenderValue);
	        ValueText.text = RoomExtender.additionalMovementMultiplier.ToString();
	    }
	}
	
	void Update ()
	{
	    if (Input.GetKeyDown(KeyCode.Escape))
	    {
	        if (IsOpen)
	        {
	            IsOpen = false;
                MenuObject.SetActive(IsOpen);
	        }
	        else
	        {
	            IsOpen = true;
	            MenuObject.SetActive(IsOpen);
            }
	    }
	}

    private void SetExtenderValue(float value)
    {
        Debug.Log("Value = " + value);
        float extenderValue = Mathf.Lerp(0f, 10f, value);//Mathf.InverseLerp(0f, 10f, value);
        Debug.Log("ExtValue = " + extenderValue);
        RoomExtender.additionalMovementMultiplier = extenderValue;
        ValueText.text = RoomExtender.additionalMovementMultiplier.ToString();
    }

}
