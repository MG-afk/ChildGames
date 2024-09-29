namespace Dream.Core.Context
{
	public abstract class Id<T>
	{
		private readonly T _value;

		public Id(T value)
		{
			_value = value;
		}

		public static implicit operator T(Id<T> property)
		{
			return property._value;
		}
	}
}