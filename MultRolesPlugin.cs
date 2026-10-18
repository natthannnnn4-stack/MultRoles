using BepInEx;
using UnityEngine;

namespace MultRoles;

[BepInPlugin("nathan.multroles", "MultRoles", "1.0.0")]
public class MultRolesPlugin : BasePlugin
{
    public override void Load()
    {
        Log.LogInfo("MultRoles carregado!");
    }
}
