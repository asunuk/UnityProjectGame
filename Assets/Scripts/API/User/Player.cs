using API.Network;
using API.Roles;
using API.Roles.Managers;
using API.Utils;
using Mirror;
using UnityEngine;

namespace API.User
{
	[RequireComponent(typeof(NetworkIdentity))]
	public class Player : EGameObject
	{
		public NetworkIdentity identity => GetComponent<NetworkIdentity>();

		[SerializeField]
		[SyncVar]
		protected string _nickname;

		[SerializeField]
		//[SyncVar(hook = nameof(RoleUpdate))]
		protected Role _role;

		public string Nickname => _nickname;

		public Role role => _role;

		#region Server

		[Server]
		public void SetRole<T>() where T : Role
		{
			_role = gameObject.AddComponent<T>();
		}

		[Server]
		protected void SetNickname(string newNickname) 
		{ 
			_nickname = newNickname;
		}

		#endregion

		#region Client

		protected void RoleUpdate(Role oldRole, Role newRole)
		{
			if (identity.isLocalPlayer)
			{
				role.LocalInit();
			}
			else
				role.OnlineInit();
		}

		#endregion
	}
}
