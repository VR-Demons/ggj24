using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class VolumeController : MonoBehaviour
{
    public Volume volume;
    private ColorAdjustments colorAdjustments;
    void Start()
    {
        volume = GetComponent<Volume>();
        volume.profile.TryGet(out colorAdjustments);
        Saturate();
    }
    public void Saturate()
    {
        colorAdjustments.saturation.value = 0f;
    }
    public void Desaturate()
    {
        colorAdjustments.saturation.value = -100f;
    }
    public void SaturateaLittle()
    {
        colorAdjustments.saturation.value = colorAdjustments.saturation.value + 13f;
    }
}
