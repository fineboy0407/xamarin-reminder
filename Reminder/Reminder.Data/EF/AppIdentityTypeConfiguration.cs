using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Reminder.Data.EF
{
    /// <inheritdoc />
    /// <summary>
    /// Class AppIdentityTypeConfiguration
    /// </summary>
    public class AppIdentityTypeConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : class
    {
        /// <summary>
        /// Initializes a new instance of the <seealso cref="AppIdentityTypeConfiguration{TEntity}"/> class.
        /// </summary>
        /// <param name="tableName">Database table name</param>
        /// <param name="schemaName">Database schema name</param>
        public AppIdentityTypeConfiguration(string tableName, string schemaName)
        {
            TableName = tableName;
            SchemaName = schemaName;
        }

        /// <summary>
        /// Database table name
        /// </summary>
        public string TableName { get; }
        /// <summary>
        /// Database schema name
        /// </summary>
        public string SchemaName { get; }

        /// <inheritdoc />
        /// <summary>
        /// Configures the specified entity type builder.
        /// </summary>
        /// <param name="builder">The entity type builder.</param>
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            // Table
            builder.ToTable(TableName, SchemaName);
        }
    }
}