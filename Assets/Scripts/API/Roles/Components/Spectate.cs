using API.Network;
using UnityEngine;

namespace API.Roles.Components
{
	public class Spectate
	{
		protected Camera mainCamera;
		protected PlayerMovableRole target;

		protected int index = 0;

		protected void Update()
		{
			if (Input.GetMouseButton(0))
			{
				index = index + 1 > EGNetworkManager.players.Count ? 0 : index;
				if(EGNetworkManager.players[index].role is PlayerMovableRole role){
					mainCamera.transform.SetParent(role.Head.transform);
				}
			}
		}
	}
}
