using API.Roles;
using API.Roles.Managers;
using API.User;
using Mirror;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace API.Network
{
	public class EGNetworkManager : NetworkManager
	{
		public static List<Player> players => _players;
		protected static List<Player> _players = new ();

		[SerializeField]
		protected GameObject
			localPlayerPrefab,
			onlinePlayerPrefab;
		public override void OnServerAddPlayer(NetworkConnectionToClient conn)
		{
			Transform startPos = GetStartPosition();
			GameObject playerGameObject = startPos != null
				? Instantiate(playerPrefab, startPos.position, startPos.rotation)
				: Instantiate(playerPrefab);

			// instantiating a "Player" prefab gives it the name "Player(clone)"
			// => appending the connectionId is WAY more useful for debugging!
			playerGameObject.name = $"{playerPrefab.name} [connId={conn.connectionId}]";

			NetworkServer.AddPlayerForConnection(conn, playerGameObject);

			Player player = playerGameObject.AddComponent<Player>();

			if (conn.identity.isLocalPlayer) InitLocalPlayer(player);
			else InitOnlinePlayer(player);
		}

		[Server]
		protected void InitOnlinePlayer(Player playerPrefab)
		{
			RoleManager.SetRole<Spectator>(playerPrefab);
		}

		[Server]
		protected void InitLocalPlayer(Player playerPrefab)
		{
			RoleManager.SetRole<Spectator>(playerPrefab);
		}

		protected void SetPlayersList(List<Player> players)
		{
			_players = players;
		}
	}
}
