using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private TurretBluePrint turretToBuild;
    public GameObject standardTurretPrefab;
    public GameObject MissileLauncherPrefab;
    public GameObject LaserBeamerPrefab;
    private Nodes selectedNode;
    public NodeUI nodeUI;
    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public GameObject BuildEffect;
    public GameObject sellEffect;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Buraya inþaa edilmez.");
            return;
        }
        instance = this;
    }
    public void SelectTurretToBuild(TurretBluePrint turret)
    {
        turretToBuild = turret;
        DeselectedNode();
    }

    public void SelectNode(Nodes node)
    {
        if (selectedNode == node)
        {
            DeselectedNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }
    public void DeselectedNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }
    public TurretBluePrint GetTurretToBuild()
    {
        return turretToBuild;
    }
}
