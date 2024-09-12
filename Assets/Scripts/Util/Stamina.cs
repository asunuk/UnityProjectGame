using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Util
{
	public class Stamina
	{
		public float minValue, maxValue, reloadTimeInMilliseconds, value;
		public Stamina(float minValue, float maxValue, float reloadTimeInMilliseconds)
		{
			this.minValue = minValue;
			this.maxValue = maxValue;
			this.reloadTimeInMilliseconds = reloadTimeInMilliseconds;
		}

		public float GetValue()
		{
			return value;
		}

		public float GetValueInInterest()
		{
			return  value / ( maxValue / 100.0f);
		}

		public void SetValue(float value)
		{
			this.value = value;
		}

		public void AddValue(float value)
		{
			this.value = value + this.value > maxValue ? maxValue :  +value + this.value;
		}

		public void AddValueByInterest(float interest)
		{
			float value = interest * (maxValue / 100);
			this.value = value + this.value > maxValue ? maxValue : value + this.value;
		}

		public void SubValue(float value)
		{
			this.value = -value + this.value < minValue ? minValue : -value + this.value;
		}

		public void SubValueByInterest(float interest)
		{
			float value = interest * (maxValue / 100);
			this.value = -value + this.value < minValue ? minValue : -value + this.value;
		}

		public void ReloadU()
		{
			if (value < maxValue) AddValue(maxValue / reloadTimeInMilliseconds * Time.deltaTime);
		}

		public void ReloadFU()
		{
			if (value < maxValue) AddValue(maxValue / reloadTimeInMilliseconds * Time.fixedDeltaTime);
		}
		public void UnreloadU()
		{
			if (value > minValue) SubValue(maxValue / reloadTimeInMilliseconds * Time.deltaTime);
		}

		public void UnreloadFU()
		{
			if (value > minValue) SubValue(maxValue / reloadTimeInMilliseconds * Time.fixedDeltaTime);
		}
	}
}
