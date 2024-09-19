using API.Roles.PlayerComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkSCTest
{
	public class NetworkFPC : FirstPersonController
	{
		protected override void Update()
		{
			if(isLocalPlayer)
				base.Update();
		}

		protected override void FixedUpdate()
		{
			if (isLocalPlayer)
				base.FixedUpdate();
		}
	}
}
