using API.Roles.Interfaces;
using Mirror;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace API.Roles
{
	[RequireComponent(typeof(NetworkIdentity))]
	public abstract class Role : NetworkBehaviour, IRole
	{
		public abstract string RoleName { get; }
		public abstract string RoleDescription { get; }
		protected virtual void Start()
		{

		}

		protected virtual void Update()
		{

		}

		protected virtual void FixedUpdate()
		{
			
		}
		protected virtual void OnDestroy()
		{

		}

		public virtual void LocalInit()
		{

		}

		public virtual void OnlineInit()
		{

		}
	}
}
