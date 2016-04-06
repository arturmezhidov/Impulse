using System.Collections.Generic;

namespace Impulse.Common.Components
{
	public static class Mapper
	{
		public static D Mapp<D>(object source)
		{
			var result = AutoMapper.Mapper.DynamicMap<D>(source);

			return result;
		}

		public static D Mapp<S, D>(S source)
		{
			AutoMapper.Mapper.CreateMap<S, D>();

			var result = AutoMapper.Mapper.Map<D>(source);

			return result;
		}

		public static IEnumerable<D> MappCollection<S, D>(IEnumerable<S> source)
		{
			AutoMapper.Mapper.CreateMap<S, D>();

			var result = AutoMapper.Mapper.Map<IEnumerable<S>, List<D>>(source);

			return result;
		}
	}
}
