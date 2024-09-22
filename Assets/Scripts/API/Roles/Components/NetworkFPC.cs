
using API.Events.EventArgs.Player;
using API.Roles.Interfaces;
using Mirror;
using UnityEngine;
namespace API.Roles.PlayerComponents
{
	public enum MoveForceTypes
	{
		Walking, 
		Running,
		Sneaking,
		JumpForce,
	}


	[RequireComponent(typeof(CharacterController))]
	public class NetworkFPC : NetworkBehaviour, IMovement
	{
		protected PlayerMovableRole player => GetComponent<PlayerMovableRole>();
		protected CharacterController characterController => GetComponent<CharacterController>();
		protected float gravity => player.Location.gravity;


		[Header("Основные параметры FPC")]
		[SyncVar]
		protected bool freezy = false;

		[SyncVar]
		[SerializeField]
		protected float
			_WalkingSpeed = 3.5f,
			_RunningSpeed = 5.5f,
			_SneakingSpeed = 1.5f,
			_JumpForce = 4.0f;

		//Поля интерфейса IFirstPersonController

		public Vector3 moveDirection => _moveDirection;
		public bool isMoving => player.gameObject.transform.position != lastPosition;
		public virtual bool isWalking => CurrentStaticSpeed == WalkingSpeed;
		public virtual bool isRunning { get; }
		public virtual bool isBackMovement { get; }
		public virtual bool isSneaking { get; }
		public virtual bool isJumping { get; }
		public float SneakingSpeed { get => _SneakingSpeed; set => _SneakingSpeed = value; } 
		public float WalkingSpeed { get => _WalkingSpeed; set => _WalkingSpeed = value; }
		public float RunningSpeed { get => _RunningSpeed; set => _RunningSpeed = value; }
		public float CurrentSpeed => Vector3.Distance(player.Body.transform.position, lastPosition);
		public float CurrentStaticSpeed => isRunning && isSneaking ? WalkingSpeed : isRunning ? RunningSpeed : isSneaking ? SneakingSpeed : WalkingSpeed;
		public float JumpForce { get => _JumpForce; set => _JumpForce = value; }

		[SyncVar]
		protected Vector3 _moveDirection = Vector3.zero;
		[SyncVar]
		protected Vector3 lastPosition;
		private Transform defaultCameraTransform;
		private float lastYSpeed;
		private float rotationX;
		private bool sneakingOffHold;

		protected virtual void Start()
		{

			defaultCameraTransform = player.Head.transform;

			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
		protected virtual void FixedUpdate()
		{
			lastYSpeed = !characterController.isGrounded ? lastYSpeed : CurrentStaticSpeed;

			if (isOwned && !freezy) CmdMove();
		}

		protected virtual void Update()
		{
			RegisterEvents();
		}

		protected virtual void RegisterEvents()
		{
			if (isJumping) Events.Handlers.Player.OnJumping(new JumpingEventArgs(player));
			if (isMoving) Events.Handlers.Player.OnMove(new MoveEventArgs(player));
		}

		[Server]
		public virtual void SetSpeed(MoveForceTypes speedType, float value)
		{
			switch (speedType)
			{
				case MoveForceTypes.Walking:
					WalkingSpeed = value;
					break;
				case MoveForceTypes.Sneaking:
					SneakingSpeed = value;
					break;
				case MoveForceTypes.Running:
					SneakingSpeed = value;
					break;
				case MoveForceTypes.JumpForce:
					JumpForce = value;
					break;
			}
		}

		[Command]
		public virtual void SetFreezy(bool value) => freezy = value;


		[Command]
		protected virtual void CmdMove()
		{
			characterController.Move(moveDirection * Time.fixedDeltaTime);
		}
	}
}