using UnityEngine;
using UnityEngine.Rendering.Universal; // Light2D

public class LightLinker : MonoBehaviour
{
    [Header("Referanslar")]
    public LightCycleManager cycle; // sahnedeki LightCycleManager
    public Light2D globalLight;     // sahnedeki Global Light 2D
    public Light2D playerLight;     // Player alt�ndaki Point Light 2D

    [Header("Kapal� Durum (ke�if)")]
    public float globalOffIntensity = 0.1f;
    public float playerOffOuter = 4.0f;

    [Header("A��k Durum (tam ayd�nl�k)")]
    public float globalOnIntensity = 1.0f;
    public float playerOnOuter = 0.1f; // neredeyse yok

    [Header("Yumu�atma")]
    public float smooth = 6f; // 0 = anl�k, 6 = h�zl� yumu�ak

    void Reset()
    {
        // Sahneye eklendi�inde otomatik bulmay� dener
        if (!cycle) cycle = Object.FindFirstObjectByType<LightCycleManager>();
        if (!globalLight) globalLight = Object.FindFirstObjectByType<Light2D>();
    }

    void Update()
    {
        if (!cycle) return;

        // hedef de�erleri se�
        float targetGlobal = cycle.LightsOn ? globalOnIntensity : globalOffIntensity;
        float targetRadius = cycle.LightsOn ? playerOnOuter : playerOffOuter;

        // yumu�atma (lerp)
        if (globalLight)
            globalLight.intensity = Mathf.Lerp(globalLight.intensity, targetGlobal, smooth * Time.deltaTime);

        if (playerLight)
            playerLight.pointLightOuterRadius = Mathf.Lerp(playerLight.pointLightOuterRadius, targetRadius, smooth * Time.deltaTime);
    }
}

