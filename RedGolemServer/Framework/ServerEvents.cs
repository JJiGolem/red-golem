using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using RedGolemServer.Framework.Primitives;

namespace RedGolemServer.Framework
{
    public class ServerEvents : ServerScript
    {
        public static event OnEntityCreatedDelegate OnEntityCreatedEvent;
        public static event OnEntityCreatingDelegate OnEntityCreatingEvent;
        public static event OnEntityRemovedDelegate OnEntityRemovedEvent;
        public static event OnResourceListRefreshDelegate OnResourceListRefreshEvent;
        public static event OnResourceStartDelegate OnResourceStartEvent;
        public static event OnResourceStartingDelegate OnResourceStartingEvent;
        public static event OnResourceStopDelegate OnResourceStopEvent;
        public static event OnServerResourceStartDelegate OnServerResourceStartEvent;
        public static event OnServerResourceStopDelegate OnServerResourceStopEvent;
        public static event OnClientResourceStartDelegate OnClientResourceStartEvent;
        public static event OnClientResourceStopDelegate OnClientResourceStopEvent;
        public static event OnPlayerConnectDelegate OnPlayerConnectEvent;
        public static event OnPlayerDroppedDelegate OnPlayerDroppedEvent;
        public static event OnPlayerJoiningDelegate OnPlayerJoiningEvent;
        public static event OnPlayerLeftScopeDelegate OnPlayerLeftScopeEvent;
        public static event OnPlayerEnteredScopeDelegate OnPlayerEnteredScopeEvent;
        public static event OnPtFxEventDelegate OnPtFxEventEvent;
        public static event OnRemoveAllWeaponsEventDelegate OnRemoveAllWeaponsEventEvent;
        public static event OnStartProjectileEventDelegate OnStartProjectileEventEvent;
        public static event OnWeaponDamageEventDelegate OnWeaponDamageEventEvent;
        public static event OnGameEventTriggeredDelegate OnGameEventTriggeredEvent;
        public static event OnRespawnPlayerPedEventDelegate OnRespawnPlayerPedEventEvent;
        public static event OnPopulationPedCreatingDelegate OnPopulationPedCreatingEvent;
        public static event OnVehicleComponentControlEventDelegate OnVehicleComponentControlEventEvent;
        public static event OnRconCommandDelegate OnRconCommandEvent;

        public ServerEvents()
        {
            EventHandlers[EventNames.OnEntityCreated] += new Action<int>(OnEntityCreated);
            EventHandlers[EventNames.OnEntityCreating] += new Action<int>(OnEntityCreating);
            EventHandlers[EventNames.OnEntityRemoved] += new Action<int>(OnEntityRemoved);
            EventHandlers[EventNames.OnResourceListRefresh] += new Action(OnResourceListRefresh);
            EventHandlers[EventNames.OnResourceStart] += new Action<string>(OnResourceStart);
            EventHandlers[EventNames.OnResourceStarting] += new Action<string>(OnResourceStarting);
            EventHandlers[EventNames.OnResourceStop] += new Action<string>(OnResourceStop);
            EventHandlers[EventNames.OnServerResourceStart] += new Action<string>(OnServerResourceStart);
            EventHandlers[EventNames.OnServerResourceStop] += new Action<string>(OnServerResourceStop);
            EventHandlers[EventNames.OnClientResourceStart] += new Action<string>(OnClientResourceStart);
            EventHandlers[EventNames.OnClientResourceStop] += new Action<string>(OnClientResourceStop);
            EventHandlers[EventNames.OnPlayerConnect] += new Action<Player, string, dynamic, dynamic>(OnPlayerConnect);
            EventHandlers[EventNames.OnPlayerDropped] += new Action<Player, string>(OnPlayerDropped);
            EventHandlers[EventNames.OnPlayerJoining] += new Action<Player, string>(OnPlayerJoining);
            EventHandlers[EventNames.OnPlayerLeftScope] += new Action<dynamic>(OnPlayerLeftScope);
            EventHandlers[EventNames.OnPlayerEnteredScope] += new Action<dynamic>(OnPlayerEnteredScope);
            EventHandlers[EventNames.OnPtFxEvent] += new Action<int, dynamic>(OnPtFxEvent);
            EventHandlers[EventNames.OnRemoveAllWeaponsEvent] += new Action<int, dynamic>(OnRemoveAllWeaponsEvent);
            EventHandlers[EventNames.OnStartProjectileEvent] += new Action<int, dynamic>(OnStartProjectileEvent);
            EventHandlers[EventNames.OnWeaponDamageEvent] += new Action<int, dynamic>(OnWeaponDamageEvent);
            EventHandlers[EventNames.OnGameEventTriggered] += new Action<string, List<dynamic>>(OnGameEventTriggered);
            EventHandlers[EventNames.OnRespawnPlayerPedEvent] += new Action<Player, dynamic>(OnRespawnPlayerPedEvent);
            EventHandlers[EventNames.OnPopulationPedCreating] += new Action<float, float, float, uint, dynamic>(OnPopulationPedCreating);
            EventHandlers[EventNames.OnVehicleComponentControlEvent] += new Action<int, int, int, bool, bool, int>(OnVehicleComponentControlEvent);
            EventHandlers[EventNames.OnRconCommand] += new Action<string, List<object>>(OnRconCommand);

        }

        private void OnEntityCreated(int handle)
        {
            OnEntityCreatedEvent?.Invoke(handle);
        }

        private void OnEntityCreating(int handle)
        {
            OnEntityCreatingEvent?.Invoke(handle);
        }

        private void OnEntityRemoved(int entity)
        {
            OnEntityRemovedEvent?.Invoke(entity);
        }

        private void OnResourceListRefresh()
        {
            OnResourceListRefreshEvent?.Invoke();
        }

        private void OnResourceStart(string resourceName)
        {
            OnResourceStartEvent?.Invoke(resourceName);
        }

        private void OnResourceStarting(string resourceName)
        {
            OnResourceStartingEvent?.Invoke(resourceName);
        }

        private void OnResourceStop(string resourceName)
        {
            OnResourceStopEvent?.Invoke(resourceName);
        }

        private void OnServerResourceStart(string resourceName)
        {
            OnServerResourceStartEvent?.Invoke(resourceName);
        }

        private void OnServerResourceStop(string resourceName)
        {
            OnServerResourceStopEvent?.Invoke(resourceName);
        }

        private void OnClientResourceStart(string resourceName)
        {
            OnClientResourceStartEvent?.Invoke(resourceName);
        }

        private void OnClientResourceStop(string resourceName)
        {
            OnClientResourceStopEvent?.Invoke(resourceName);
        }

        private void OnPlayerConnect([FromSource] Player player, string playerName, dynamic setKickReason, dynamic deferrals)
        {
            Action<string> _setKickReason = (reason) =>
            {
                setKickReason?.Invoke(reason);
            };

            OnPlayerConnectEvent?.Invoke(player, playerName, _setKickReason, new PlayerConnectDeferral(ref deferrals));
        }

        private void OnPlayerDropped([FromSource] Player player, string reason)
        {
            OnPlayerDroppedEvent?.Invoke(player, reason);
        }

        private void OnPlayerJoining([FromSource] Player player, string oldId)
        {
            OnPlayerJoiningEvent?.Invoke(player, oldId);
        }

        private void OnPlayerLeftScope(dynamic data)
        {
            // data.for - string
            // data.player - string
            Player target = API.GetPlayerName(data.@for);
            Player player = API.GetPlayerName(data.player);
            OnPlayerLeftScopeEvent?.Invoke(target, player);
        }

        private void OnPlayerEnteredScope(dynamic data)
        {
            // data.for - string
            // data.player - string
            Player target = API.GetPlayerName(data.@for);
            Player player = API.GetPlayerName(data.player);
            OnPlayerEnteredScopeEvent?.Invoke(target, player);
        }

        private void OnPtFxEvent(int sender, dynamic data)
        {
            //data { assetHash: number; axisBitset: number; effectHash: number; entityNetId: number; f100: number; f105: number; f106: number; f107: number; f109: boolean; f110: boolean; f111: boolean; f92: number; isOnEntity: boolean; offsetX: number; offsetY: number; offsetZ: number; posX: number; posY: number; posZ: number; rotX: number; rotY: number; rotZ: number; scale: number }
            Player player = Players[sender];
            OnPtFxEventEvent?.Invoke(player, new ParticleFxEventArgs(
                data.assetHash,
                data.axisBitset,
                data.effectHash,
                data.entityNetId,
                data.f100,
                data.f105,
                data.f106,
                data.f107,
                data.f109,
                data.f110,
                data.f111,
                data.f92,
                data.isOnEntity,
                data.offsetX,
                data.offsetY,
                data.offsetZ,
                data.posX,
                data.posY,
                data.posZ,
                data.rotX,
                data.rotY,
                data.rotZ,
                data.scale));
        }

        private void OnRemoveAllWeaponsEvent(int sender, dynamic data)
        {
            //data: { pedId: number }
            Player player = Players[sender];
            Ped ped = Ped.FromNetworkId(data.pedId) as Ped;
            OnRemoveAllWeaponsEventEvent?.Invoke(player, ped);
        }

        private void OnStartProjectileEvent(int sender, dynamic data)
        {
            //data: { commandFireSingleBullet: boolean; effectGroup: number; firePositionX: number; firePositionY: number; firePositionZ: number; initialPositionX: number; initialPositionY: number; initialPositionZ: number; ownerId: number; projectileHash: number; targetEntity: number; throwTaskSequence: number; unk10: number; unk11: number; unk12: number; unk13: number; unk14: number; unk15: number; unk16: number; unk3: number; unk4: number; unk5: number; unk6: number; unk7: number; unk9: number; unkX8: number; unkY8: number; unkZ8: number; weaponHash: number }
            Player player = Players[sender];
            OnStartProjectileEventEvent?.Invoke(player, new ProjectileEventArgs(
                data.commandFireSingleBullet,
                data.effectGroup,
                data.firePositionX,
                data.firePositionY,
                data.firePositionZ,
                data.initialPositionX,
                data.initialPositionY,
                data.initialPositionZ,
                data.ownerId,
                data.projectileHash,
                data.targetEntity,
                data.throwTaskSequence,
                data.unk10,
                data.unk11,
                data.unk12,
                data.unk13,
                data.unk14,
                data.unk15,
                data.unk16,
                data.unk3,
                data.unk4,
                data.unk5,
                data.unk6,
                data.unk7,
                data.unk9,
                data.unkX8,
                data.unkY8,
                data.unkZ8,
                data.weaponHash));
        }

        private void OnWeaponDamageEvent(int sender, dynamic data)
        {
            //data: { actionResultId: number; actionResultName: number; damageFlags: number; damageTime: number; damageType: number; f104: number; f112: boolean; f112_1: number; f120: number; f133: boolean; hasActionResult: boolean; hasImpactDir: boolean; hasVehicleData: boolean; hitComponent: number; hitEntityWeapon: boolean; hitGlobalId: number; hitGlobalIds: number[]; hitWeaponAmmoAttachment: boolean; impactDirX: number; impactDirY: number; impactDirZ: number; isNetTargetPos: boolean; localPosX: number; localPosY: number; localPosZ: number; overrideDefaultDamage: boolean; parentGlobalId: number; silenced: boolean; suspensionIndex: number; tyreIndex: number; weaponDamage: number; weaponType: number; willKill: boolean }
            Player player = Players[sender];
            OnWeaponDamageEventEvent?.Invoke(player, new WeaponDamageEventArgs(
                data.actionResultId,
                data.actionResultName,
                data.damageFlags,
                data.damageTime,
                data.damageType,
                data.f104,
                data.f112,
                data.f112_1,
                data.f120,
                data.f133,
                data.hasActionResult,
                data.hasImpactDir,
                data.hasVehicleData,
                data.hitComponent,
                data.hitEntityWeapon,
                data.hitGlobalId,
                data.hitGlobalIds,
                data.hitWeaponAmmoAttachment,
                data.impactDirX,
                data.impactDirY,
                data.impactDirZ,
                data.isNetTargetPos,
                data.localPosX,
                data.localPosY,
                data.localPosZ,
                data.overrideDefaultDamage,
                data.parentGlobalId,
                data.silenced,
                data.suspensionIndex,
                data.tyreIndex,
                data.weaponDamage,
                data.weaponType,
                data.willKill));
        }

        private void OnGameEventTriggered(string eventName, List<dynamic> args)
        {
            OnGameEventTriggeredEvent?.Invoke(eventName, args);
        }

        private void OnRespawnPlayerPedEvent([FromSource] Player player, dynamic data)
        {
            Vector3 position = new Vector3(data.posX, data.posY, data.posZ);
            OnRespawnPlayerPedEventEvent?.Invoke(player, position);
        }

        private void OnPopulationPedCreating(float posX, float posY, float posZ, uint model, dynamic setters)
        {
            OnPopulationPedCreatingEvent?.Invoke(posX, posY, posZ, model, new PopulationPedCreatingSetters(ref setters));
        }

        private void OnVehicleComponentControlEvent(int vehicleGlobalId, int pedGlobalId, int componentIndex, bool request, bool componentIsSeat, int pedInSeat)
        {
            OnVehicleComponentControlEventEvent?.Invoke(vehicleGlobalId, pedGlobalId, componentIndex, request, componentIsSeat, pedInSeat);
        }

        private void OnRconCommand(string command, List<object> args)
        {
            OnRconCommandEvent?.Invoke(command, args.ToArray());
        }
    }
}
