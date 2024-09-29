using Dream.Core.Context;
using System;

namespace Dream.Core
{
	public sealed class LifetimeId : Id<Guid>
	{
		public LifetimeId(Guid value) : base(value)
		{
		}
	}
}
