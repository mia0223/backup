using System;
using System.Linq;
using System.Globalization;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace TEK.SeatPlan.Common
{
	[ExcludeFromCodeCoverage]
	public static class Requires
	{
		public static void ArgumentNotNull([ValidatedNotNull] object value, string parameterName)
		{
			if (value == null)
			{
				throw new ArgumentNullException(parameterName);
			}
		}

		public static void ArgumentNotEmpty([ValidatedNotNull] string value, string parameterName)
		{
			Requires.ArgumentNotNull(value, parameterName);
			Requires.ArgumentNotNull(parameterName, "parameterName");

			if (string.IsNullOrEmpty(value))
			{
				throw new ArgumentException("Value cannot be empty.", parameterName);
			}
		}

		public static void ArgumentNotEmpty<TItem>([ValidatedNotNull] IEnumerable<TItem> value, string parameterName)
		{
			Requires.ArgumentNotNull(value, parameterName);
			Requires.ArgumentNotNull(parameterName, "parameterName");

			if (!value.Any())
			{
				throw new ArgumentException("Value cannot be empty.", parameterName);
			}
		}

		public static void EnumArgumentInList([ValidatedNotNull] Enum value, string parameterName, params Enum[] allowedValues)
		{
			Requires.ArgumentNotNull(value, parameterName);
			Requires.ArgumentNotNull(parameterName, "parameterName");
			Requires.ArgumentNotNull(allowedValues, "allowedValues");

			if (!allowedValues.Contains(value))
			{
				throw new InvalidEnumArgumentException(
					parameterName,
					Convert.ToInt32(value, CultureInfo.InvariantCulture),
					value.GetType());
			}
		}

		public static void ArgumentInRange<TValue>(TValue value, TValue minimumValue, TValue maximumValue, string parameterName)
			where TValue : struct, IComparable<TValue>
		{
			Requires.ArgumentNotNull(parameterName, "parameterName");

			if ((value.CompareTo(minimumValue) < 0) || (value.CompareTo(maximumValue) > 0))
			{
				throw new ArgumentOutOfRangeException(parameterName);
			}
		}
	}
}