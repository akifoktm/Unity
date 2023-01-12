using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBluePrint StandartTurret;
    public TurretBluePrint MissleLauncher;
    public TurretBluePrint LaserBeamer;
    BuildManager buildManager;
    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandartTurret()
    {
        Debug.Log("Standart Turret Se�ili");
        buildManager.SelectTurretToBuild(StandartTurret);
    }
    public void SelectMissileLauncher()
    {
        Debug.Log("Roketatar Se�ili");
        buildManager.SelectTurretToBuild(MissleLauncher);

    }
    public void SelectLaserBeamer()
    {
        Debug.Log("LaserBeamer Se�ili");
        buildManager.SelectTurretToBuild(LaserBeamer);
    }
}
