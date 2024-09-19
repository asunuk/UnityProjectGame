using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace API.Roles.Interfaces
{
	public interface ICameraController
	{
		public Camera Camera { get; }
		public float CameraSenitivityX { get; set; }
		public float CameraSenitivityY { get; set; }
		public float CameraLimitX { get; set; }
	}
}
