using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CitizenFX.Core;
using RedGolemServer.Framework.Primitives;

namespace RedGolemServer.Framework
{
    public delegate Task OnEntityCreatedDelegate(int handle);
    public delegate Task OnEntityCreatingDelegate(int handle);
    public delegate Task OnEntityRemovedDelegate(int entity);

    public delegate Task OnResourceListRefreshDelegate();
    public delegate Task OnResourceStartDelegate(string resourceName);
    public delegate Task OnResourceStartingDelegate(string resourceName);
    public delegate Task OnResourceStopDelegate(string resourceName);
    public delegate Task OnServerResourceStartDelegate(string resourceName);
    public delegate Task OnServerResourceStopDelegate(string resourceName);
    public delegate Task OnClientResourceStartDelegate(string resourceName);
    public delegate Task OnClientResourceStopDelegate(string resourceName);

    public delegate Task OnPlayerConnectDelegate([FromSource] Player player, string playerName, Action<string> setKickReason, PlayerConnectDeferral deferrals);
    public delegate Task OnPlayerDroppedDelegate([FromSource] Player player, string reason);
    public delegate Task OnPlayerJoiningDelegate([FromSource] Player player, string oldId);
    public delegate Task OnPlayerLeftScopeDelegate([FromSource] Player target, [FromSource] Player player);
    public delegate Task OnPlayerEnteredScopeDelegate([FromSource] Player target, [FromSource] Player player);

    public delegate Task OnPtFxEventDelegate(Player sender, ParticleFxEventArgs args);

    public delegate Task OnRemoveAllWeaponsEventDelegate(Player sender, Ped target);
    public delegate Task OnStartProjectileEventDelegate(Player sender, ProjectileEventArgs args);
    public delegate Task OnWeaponDamageEventDelegate(Player sender, WeaponDamageEventArgs args);

    public delegate Task OnGameEventTriggeredDelegate(string eventName, List<dynamic> args);
    public delegate Task OnRespawnPlayerPedEventDelegate([FromSource] Player player, Vector3 respawnPosition);

    public delegate Task OnPopulationPedCreatingDelegate(float posX, float posY, float posZ, uint model, PopulationPedCreatingSetters setters);
    public delegate Task OnVehicleComponentControlEventDelegate(int vehicleGlobalId, int pedGlobalId, int componentIndex, bool request, bool componentIsSeat, int pedInSeat);

    public delegate Task OnRconCommandDelegate(string command, object[] arguments);

}
