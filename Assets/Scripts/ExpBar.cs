using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    [SerializeField] private float maxExp;
    [SerializeField] private Player player;
    private float currentExp = 0;

    private Slider expSlider;

    private void Awake()
    {
        expSlider = GetComponent<Slider>();
        currentExp = maxExp;
    }

    private void Start()
    {
        expSlider.value = currentExp;
        expSlider.maxValue = maxExp;
    }

    // Update is called once per frame
    void Update()
    {

        if (currentExp != expSlider.value) {
            expSlider.value = currentExp;
        }

        if(currentExp == maxExp)
        {
            player.LevelUp();
            currentExp = 0;
        }
    }

    public void SetExp(float value)
    {
        currentExp += value;
    }
}
