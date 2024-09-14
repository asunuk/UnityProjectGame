using Game.Roles.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Game.Roles
{
	public abstract class Role : MonoBehaviour, IRole
	{
		public abstract string RoleName { get; }
		protected virtual void Start()
		{
			Init();
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

		protected virtual void Init()
		{

		}
	}
}
