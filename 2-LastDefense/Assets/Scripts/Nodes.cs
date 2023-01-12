using UnityEngine.EventSystems;
using UnityEngine;

public class Nodes : MonoBehaviour
{
    public Color hoverColor;
    public Color NotEnoughMoneyColor;
    public Vector3 positionOffset;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBluePrint turretBluePrint;
    [HideInInspector]
    public bool isUpgraded = false;

    private Renderer rend;
    private Color startColor;


    public Vector3 GetBuildPoistion()
    {
        return transform.position + positionOffset;
    }
    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }
    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = NotEnoughMoneyColor;
        }

    }
    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }
        if (!buildManager.CanBuild)
            return;
        BuildTurret(buildManager.GetTurretToBuild());
    }
    void BuildTurret(TurretBluePrint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Yetersiz bakiye");
            return;
        }
        PlayerStats.Money -= blueprint.cost;

        Debug.Log("Taret inþa et! Kalan paran:" + PlayerStats.Money);

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPoistion(), Quaternion.identity);
        turret = _turret;

        turretBluePrint = blueprint;

        GameObject effect = (GameObject)Instantiate(buildManager.BuildEffect, GetBuildPoistion(), Quaternion.identity);
        Destroy(effect, 5f);
    }
    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBluePrint.upgradeCost)
        {
            Debug.Log("Yetersiz bakiye");
            return;
        }
        PlayerStats.Money -= turretBluePrint.upgradeCost;

        Destroy(turret);

        GameObject _turret = (GameObject)Instantiate(turretBluePrint.upgradedPrefab, GetBuildPoistion(), Quaternion.identity);
        turret = _turret;

        isUpgraded = true;

        GameObject effect = (GameObject)Instantiate(buildManager.BuildEffect, GetBuildPoistion(), Quaternion.identity);
        Destroy(effect, 5f);
    }
    public void SellTurret()
    {
        PlayerStats.Money += turretBluePrint.GetSellAmount();
        Destroy(turret);
        turretBluePrint = null;

        GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPoistion(), Quaternion.identity);
        Destroy(effect, 5f);
    }
}

