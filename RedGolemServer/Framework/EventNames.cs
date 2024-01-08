namespace RedGolemServer.Framework
{
    internal class EventNames
    {
        public const string OnEntityCreated = "entityCreated";
        public const string OnEntityCreating = "entityCreating";
        public const string OnEntityRemoved = "entityRemoved";

        public const string OnResourceListRefresh = "onResourceListRefresh";
        public const string OnResourceStart = "onResourceStart";
        public const string OnResourceStarting = "onResourceStarting";
        public const string OnResourceStop = "onResourceStop";
        public const string OnServerResourceStart = "onServerResourceStart";
        public const string OnServerResourceStop = "onServerResourceStop";
        public const string OnClientResourceStart = "onClientResourceStart";
        public const string OnClientResourceStop = "onClientResourceStop";

        public const string OnPlayerConnect = "playerConnecting";
        public const string OnPlayerDropped = "playerDropped";
        public const string OnPlayerEnteredScope = "playerEnteredScope";
        public const string OnPlayerJoining = "playerJoining";
        public const string OnPlayerLeftScope = "playerLeftScope";

        public const string OnPtFxEvent = "ptFxEvent";

        public const string OnRemoveAllWeaponsEvent = "removeAllWeaponsEvent";
        public const string OnStartProjectileEvent = "startProjectileEvent";
        public const string OnWeaponDamageEvent = "weaponDamageEvent";

        public const string OnGameEventTriggered = "gameEventTriggered";
        public const string OnRespawnPlayerPedEvent = "respawnPlayerPedEvent";

        public const string OnPopulationPedCreating = "populationPedCreating";
        public const string OnVehicleComponentControlEvent = "vehicleComponentControlEvent";

        public const string OnRconCommand = "rconCommand";
    }
}
