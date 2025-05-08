using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image healthGlobe, manaGlobe;
    [SerializeField] private Slider xpSlider;
    [SerializeField] private PLayerHealth pLayerHealth;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthGlobe.fillAmount = pLayerHealth.GetHealthRatio();
    }
}
