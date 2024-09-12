using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

namespace Game.Roles.PlayerComponents
{
	public class Interaction : MonoBehaviour
	{
		public List<InteractiveGameObject> interactiveGameObjects { get; protected set; } = new();
		public List<string> interactiveTags { get; protected set; } = new();
		public KeyCode interactionKey = KeyCode.E;
		private Ray ray;
		private void Start()
		{

		}

		private void Update()
		{
			if (Input.GetKeyDown(interactionKey))
			{
				RaycastHit _hit;
				if (Physics.Raycast(ray, out _hit))
				{
					InteractiveGameObject igo = GetInteractiveObjectByGameObject(_hit.collider.gameObject);
					if (igo is not null) 
						igo.InteractAction();
					else 
						igo = GetInteractiveObjectByGameObject(_hit.collider.gameObject);
				}
			}
		}

		//Добавляет интерактивный объект в список интерактивных объектов
		public void AddInteractiveObject(InteractiveGameObject gameObject)
		{
			if (!interactiveGameObjects.Contains(gameObject)) interactiveGameObjects.Add(gameObject);
			else
				throw new Exception($"Объект '{gameObject}' уже существует в списке интерактивных вещей");
		}

		//Добавляет интерактивный тег в список интерактивных тегов
		public void AddInteractiveTag(string tagName)
		{
			if (!interactiveTags.Contains(tagName)) interactiveTags.Add(tagName);
			else
				throw new Exception($"Тег '{tagName}' уже существует в списке интерактивных тегов");
		}


		public void RemoveInteractiveObject(InteractiveGameObject gameObject)
		{
			if (interactiveGameObjects.Contains(gameObject)) interactiveGameObjects.Remove(gameObject);
			else
				throw new Exception($"Объект '{gameObject}' несуществует в списке интерактивных вещей");
		}

		public void RemoveInteractiveTag(string tagName)
		{
			if (interactiveTags.Contains(tagName)) interactiveTags.Remove(tagName);
			else
				throw new Exception($"Тег '{tagName}' несуществует в списке интерактивных тегов");
		}

		public Dictionary<string, GameObject[]> GetGameObejctsByAllInteractiveTags()
		{
			Dictionary<string, GameObject[]> dict = new Dictionary<string, GameObject[]>();
			foreach(string tag in interactiveTags)
			{
				dict.Add(tag, GameObject.FindGameObjectsWithTag(tag));
			}

			return dict;
		}

		public InteractiveGameObject GetInteractiveObjectByGameObject(GameObject gameObject)
		{
			InteractiveGameObject igo = null;
			interactiveGameObjects.ForEach((_igo) =>
			{
				igo = _igo.gameObject == gameObject ? _igo : igo;
			});
			return igo;
		}
	}
}