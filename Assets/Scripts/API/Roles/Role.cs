using API.Roles.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace API.Roles
{
	public abstract class Role : MonoBehaviour, IRole
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

		public virtual void Init()
		{

		}
	}
}
