using Mirror;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace API.Utils
{
	[RequireComponent(typeof(NetworkIdentity), typeof(NetworkTransformUnreliable))]
	public class EGameObject : NetworkBehaviour
	{
	}
}
