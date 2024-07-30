using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EtherBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetEther(int ether)
    {
        slider.value = ether;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

}
