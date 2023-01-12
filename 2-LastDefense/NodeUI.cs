using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public Text upgradeCost;
    private Nodes target;
    public GameObject ui;
    public Button upgradeButton;
    public Text sellAmount;

    public void SetTarget(Nodes _target)
    {
        target = _target;

        transform.position = target.GetBuildPoistion();
        if (!target.isUpgraded)
        {
            upgradeCost.text = "$" + target.turretBluePrint.upgradeCost;
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "DONE";
            upgradeButton.interactable = false;
        }

        sellAmount.text = "$" + target.turretBluePrint.GetSellAmount();

        ui.SetActive(true);
    }
    public void Hide()
    {
        ui.SetActive(false);
    }
    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectedNode();
    }
    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectedNode();
    }
}