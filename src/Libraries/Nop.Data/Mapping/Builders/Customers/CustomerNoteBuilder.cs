using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Customers;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Customers
{
    /// <summary>
    /// Represents a customer note entity builder
    /// </summary>
    public partial class CustomerNoteBuilder : NopEntityBuilder<CustomerNote>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(CustomerNote.Note)).AsString(int.MaxValue).NotNullable()
                .WithColumn(nameof(CustomerNote.CustomerId)).AsInt32().ForeignKey<Customer>();
        }

        #endregion
    }
}