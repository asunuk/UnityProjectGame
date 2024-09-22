using API.Roles.Interfaces;
using API.Roles.PlayerComponents;
using Mirror;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace API.Roles.Components
{
	public class FPC : NetworkFPC, ICameraController
	{
		[SerializeField]
		protected Camera _Camera;

		public Camera Camera => _Camera;

		public float CameraSenitivityX { get => _CameraSensitivityX; set => _CameraSensitivityX = value; }
		public float CameraSenitivityY { get => _CameraSensitivityY; set => _CameraSensitivityY = value; }
		public float CameraLimitX { get => _CameraLimitX; set => _CameraLimitX = value; }

		public override bool isWalking => CurrentStaticSpeed == WalkingSpeed;
		public override bool isRunning => Input.GetKey(runningKey);
		public override bool isBackMovement => Input.GetKey(back);
		public override bool isSneaking => sneakOnHold ? Input.GetKey(sneakingKey) : sneakingOffHold;
		public override bool isJumping => Input.GetKey(jumpingKey);

		[Header("Клавишы и переменные для управления FPC")]

		public bool sneakOnHold;

		public KeyCode
			forward = KeyCode.W,
			back = KeyCode.S,
			right = KeyCode.D,
			left = KeyCode.A,
			runningKey = KeyCode.LeftShift,
			jumpingKey = KeyCode.Space,
			sneakingKey = KeyCode.LeftAlt;

		[Header("Элеменеты управления камерой")]

		[SerializeField]
		private float _CameraLimitX = 95.0f;

		[SerializeField]
		protected float
			_CameraSensitivityX,
			_CameraSensitivityY;

		private Transform defaultCameraTransform;
		private float lastYSpeed;
		private float rotationX;
		private bool sneakingOffHold;


		protected override void Update()
		{
			RegisterEvents();

			if (isOwned && !freezy)
			{
				CameraMoveLogic();
			}
		}

		[Command]
		protected override void CmdMove()
		{
			float _lastDirection = _moveDirection.y;
			lastPosition = player.gameObject.transform.position;

			Vector3 f = GetComponent<PlayerMovableRole>().gameObject.transform.TransformDirection(Vector3.forward) * lastYSpeed;
			Vector3 r = GetComponent<PlayerMovableRole>().gameObject.transform.TransformDirection(Vector3.right) * lastYSpeed;

			Vector3 axis = GetAxis(forward, back, left, right);
			Vector3 _cd = !characterController.isGrounded ? moveDirection : (axis.x * r) + (axis.z * f);
			_moveDirection = freezy ? !characterController.isGrounded ? _moveDirection : Vector3.zero : !characterController.isGrounded ? _moveDirection : _cd;

			_moveDirection.y = (isJumping && characterController.isGrounded) && !freezy ? _JumpForce : _lastDirection;
			if (!characterController.isGrounded)
			{
				_moveDirection.y -= player.Location.gravity * Time.fixedDeltaTime;
			}

			base.CmdMove();
		}

		protected void CameraMoveLogic()
		{
			rotationX += -Input.GetAxis("Mouse Y") * _CameraSensitivityY;
			rotationX = Mathf.Clamp(rotationX, -_CameraLimitX, _CameraLimitX);
			_Camera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
			player.Body.transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * _CameraSensitivityX, 0);
		}

		protected Vector3 GetAxis(KeyCode forward, KeyCode back, KeyCode left, KeyCode right)
		{
			Vector3 rv = Vector3.zero;

			if (Input.GetKey(forward)) rv.z++;
			if (Input.GetKey(back)) rv.z--;
			if (Input.GetKey(right)) rv.x++;
			if (Input.GetKey(left)) rv.x--;

			return rv;
		}
	}
}
