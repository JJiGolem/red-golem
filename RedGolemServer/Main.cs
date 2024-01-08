using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using RedGolemServer.Framework;

namespace RedGolemServer
{
    public class Main : ServerScript
    {
        public Main()
        {
            ServerEvents.OnResourceStartingEvent += ServerEvents_OnResourceStartingEvent;
            ServerEvents.OnServerResourceStartEvent += ServerEvents_OnServerResourceStartEvent;
            ServerEvents.OnClientResourceStartEvent += ServerEvents_OnClientResourceStartEvent;
            ServerEvents.OnRconCommandEvent += ServerEvents_OnRconCommandEvent;

            ServerEvents.OnPlayerConnectEvent += ServerEvents_OnPlayerConnectEvent;
            ServerEvents.OnPlayerDroppedEvent += ServerEvents_OnPlayerDroppedEvent;
            ServerEvents.OnPlayerJoiningEvent += ServerEvents_OnPlayerJoiningEvent;

            API.RegisterCommand("giveweapon", new Action<Player, string>(GiveWeapon), false);
        }

        private void GiveWeapon([FromSource] Player player, string weaponName)
        {
            
        }

        private Task ServerEvents_OnPlayerJoiningEvent([FromSource] Player player, string oldId)
        {
            Debug.WriteLine($"PlayerJoining: {player.Name}, {player.Handle} - {oldId}");
            return Task.CompletedTask;
        }

        private Task ServerEvents_OnPlayerDroppedEvent([FromSource] Player player, string reason)
        {
            Debug.WriteLine($"PlayerDropped: {player.Name}, {player.Handle} - {reason}");
            return Task.CompletedTask;
        }

        private Task ServerEvents_OnPlayerConnectEvent([FromSource] Player player, string playerName, Action<string> setKickReason, Framework.Primitives.PlayerConnectDeferral deferrals)
        {
            Debug.WriteLine($"PlayerConnect: {player.Name}, {player.Handle} - {playerName}");
            return Task.CompletedTask;
        }

        private Task ServerEvents_OnResourceStartingEvent(string resourceName)
        {
            Debug.WriteLine($"ResourceStarting: {resourceName}");
            return Task.CompletedTask;
        }

        private Task ServerEvents_OnRconCommandEvent(string command, object[] arguments)
        {
            Debug.WriteLine($"RcomCommand: {command} - {string.Join(", ", arguments)}");
            return Task.CompletedTask;
        }

        private Task ServerEvents_OnServerResourceStartEvent(string resourceName)
        {
            Debug.WriteLine($"ServerResourceStart: {resourceName}");
            return Task.CompletedTask;
        }

        private Task ServerEvents_OnClientResourceStartEvent(string resourceName)
        {
            Debug.WriteLine($"ClientResourceStart: {resourceName}");
            return Task.CompletedTask;
        }
    }
}
