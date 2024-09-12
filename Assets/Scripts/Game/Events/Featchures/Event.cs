using Game.Events.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace Game.Events.Featchures
{
	public delegate void CustomEventHandler<TEvent>(TEvent ev) where TEvent : IEvent;
	public delegate IEnumerator<float> CustomAsyncEventHandler<TEventArgs>(TEventArgs ev);
	public class Event<T> where T : IEvent
	{

		private static readonly Dictionary<Type, Event<T>> TypeToEvent = new();
		public Event()
		{
			TypeToEvent.Add(typeof(T), this);
		}
		public event CustomEventHandler<T> InnerEvent;
		public event CustomAsyncEventHandler<T> InnerAsyncEvent;

		public static Event<T> operator +(Event<T> @event, CustomEventHandler<T> handler)
		{
			@event.Subscribe(handler);
			return @event;
		}
		public static Event<T> operator -(Event<T> @event, CustomEventHandler<T> handler)
		{
			@event.Unsubscribe(handler);
			return @event;
		}

		public void Subscribe(CustomEventHandler<T> handler)
		{
			InnerEvent += handler;
		}

		public void Subscribe(CustomAsyncEventHandler<T> handler)
		{
			InnerAsyncEvent += handler;
		}



		public void Unsubscribe(CustomEventHandler<T> handler)
		{
			InnerEvent -= handler;
		}

		public void Unsubscribe(CustomAsyncEventHandler<T> handler)
		{
			InnerAsyncEvent -= handler;
		}



		public void InvokeSafely(T arg)
		{
			InvokeNormal(arg);
		}

		internal void InvokeNormal(T arg)
		{
			if (InnerEvent is null)
				return;

			foreach (CustomEventHandler<T> handler in InnerEvent.GetInvocationList().Cast<CustomEventHandler<T>>())
			{
				try
				{
					handler(arg);
				}
				catch (Exception ex)
				{
					Debug.LogError($"Method \"{handler.Method.Name}\" of the class \"{handler.Method.ReflectedType.FullName}\" caused an exception when handling the event \"{GetType().FullName}\"\n{ex}");
				}
			}
		}



		public void InvokeSafelyAsync(T arg, MonoBehaviour ActiveMonoBehavoior)
		{
			InvokeNormalAsync(arg, ActiveMonoBehavoior);
		}

		internal void InvokeNormalAsync(T arg, MonoBehaviour ActiveMonoBehavoior)
		{
			if (InnerAsyncEvent is null)
				return;

			foreach (CustomAsyncEventHandler<T> handler in InnerAsyncEvent.GetInvocationList().Cast<CustomAsyncEventHandler<T>>())
			{
				try
				{
					ActiveMonoBehavoior.StartCoroutine(handler(arg));
				}
				catch (Exception ex)
				{
					Debug.LogError($"Method \"{handler.Method.Name}\" of the class \"{handler.Method.ReflectedType.FullName}\" caused an exception when handling the event \"{GetType().FullName}\"\n{ex}");
				}
			}
		}


	}
}
