using API.Entityes.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;

namespace API.Entityes
{

	[Serializable]
	public class EntityData
	{
		public readonly EntityType entityType;
		public readonly Vector3 position, rotation;
		public readonly int health;
		public EntityData(Entity entity)
		{
			entityType = entity.entityType;

			UnityEngine.Vector3 upos = entity.gameObject.transform.position;
			position = new Vector3(upos.x, upos.y, upos.z);

			UnityEngine.Vector3 urot = entity.gameObject.transform.rotation.eulerAngles;
			rotation = new Vector3(urot.x, urot.y, urot.z);

			health = entity.health;
		}
	}
	public class EntityManager
	{

		public EntityData getEntityData(Entity entity)
		{
			return new EntityData(entity);
		}
	}
}
