using API.Roles;
using Mirror;
using UnityEngine;

namespace API
{
	[RequireComponent(typeof(NetworkIdentity))]
	public class Player : NetworkBehaviour
	{
		private string _Nickname;

		protected Role _Role;

		public string Nickname => _Nickname;

		public Role Role => _Role;


		public void SetRole(Role Role)
		{
			_Role = Role;
			Role.Init();
		}
	}
}
