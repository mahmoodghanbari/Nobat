namespace Nobat.Backend.Infrastructure.Persistence.Extensions
{
	public static class ModelBuilderExtensions
	{
		public static void RegisterAllEntities(this ModelBuilder modelBuilder)
		{
			var entityTypes = modelBuilder.Model.GetEntityTypes()
				.Where(t => typeof(IEntity).IsAssignableFrom(t.ClrType) &&
				!t.ClrType.IsAbstract)
				.ToList();

			foreach (var type in entityTypes)
			{
				modelBuilder.Entity(type.ClrType);
			}
		}

		public static void ApplyAllConfigurations(this ModelBuilder modelBuilder)
		{
			var applyConfigurationMethod = typeof(ModelBuilder)
				.GetMethods()
				.First(m => m.Name == "ApplyConfiguration" &&
							m.GetParameters().Any(p => p.ParameterType.IsGenericType &&
							p.ParameterType.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)));

			var configurationTypes = Assembly.GetExecutingAssembly()
				.GetTypes()
				.Where(t => t.GetInterfaces().Any(i =>
					i.IsGenericType &&
					i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)));

			foreach (var configType in configurationTypes)
			{
				var entityType = configType.GetInterfaces()
					.First(i => i.IsGenericType &&
							   i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))
					.GetGenericArguments()[0];

				var configInstance = Activator.CreateInstance(configType);
				applyConfigurationMethod.MakeGenericMethod(entityType)
					.Invoke(modelBuilder, new[] { configInstance });
			}
		}

		public static void ApplySoftDeleteFilter(this ModelBuilder modelBuilder)
		{
			foreach (var entityType in modelBuilder.Model.GetEntityTypes())
			{
				if (typeof(IEntity).IsAssignableFrom(entityType.ClrType))
				{
					entityType.SetQueryFilter(BuildSoftDeleteFilter(entityType.ClrType));
				}
			}
		}

		private static LambdaExpression BuildSoftDeleteFilter(Type entityType)
		{
			var parameter = Expression.Parameter(entityType, "e");
			var property = Expression.PropertyOrField(parameter, "IsDeleted");
			var falseConstant = Expression.Constant(false);
			var body = Expression.Equal(property, falseConstant);
			return Expression.Lambda(body, parameter);
		}
	}
}
