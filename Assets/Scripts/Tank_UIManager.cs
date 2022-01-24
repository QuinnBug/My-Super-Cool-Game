using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tank_UIManager : MonoBehaviour
{
    public Slider hpSlider;
    public Image ammoIndicator;
    public Text speedometer;
    public Text ammoCount;
    public Image reloadingSymbol;

    private SquareHealth tankHealth;
    private SquareMovement tankMovement;
    private TankTurret tankTurret;

    // Start is called before the first frame update
    void Start()
    {
        tankHealth = GetComponent<SquareHealth>();
        tankMovement = GetComponent<SquareMovement>();
        tankTurret = GetComponentInChildren<TankTurret>();

        hpSlider.maxValue = tankHealth.startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        hpSlider.value = tankHealth.GetHealth();

        //speedometer.text = tankMovement.GetSpeed();
        speedometer.text = GameManager.Instance.score.ToString();

        ammoIndicator.enabled = !tankTurret.reloading;
        ammoIndicator.fillAmount = tankTurret.GetAmmoPercent();

        ammoCount.enabled = !tankTurret.reloading;
        ammoCount.text = tankTurret.GetAmmo().ToString();

        reloadingSymbol.enabled = tankTurret.reloading;
    }
}
