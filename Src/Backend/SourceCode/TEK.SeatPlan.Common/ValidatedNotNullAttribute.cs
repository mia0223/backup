using System;

namespace TEK.SeatPlan.Common
{
	[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
	internal sealed class ValidatedNotNullAttribute : Attribute
	{
	}
}