namespace TEK.SeatPlan.Entity
{
	public abstract class BaseEntity : IdentifiedEntity<int>
	{
		public override bool IsNew => this.Id <= 0;
	}

	public abstract class BaseDataEntity : BaseEntity { }

	public abstract class TrackedEntity : BaseDataEntity { }
}