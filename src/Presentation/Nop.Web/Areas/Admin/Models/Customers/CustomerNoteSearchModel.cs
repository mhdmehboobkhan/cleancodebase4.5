using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;
using System;
using System.ComponentModel.DataAnnotations;

namespace Nop.Web.Areas.Admin.Models.Customers
{
    /// <summary>
    /// Represents an customer note search model
    /// </summary>
    public partial record CustomerNoteSearchModel : BaseSearchModel
    {
        #region Ctor

        public CustomerNoteSearchModel()
        {
            CustomerNote = new CustomerNoteModel();
        }

        #endregion

        #region Properties

        [NopResourceDisplayName("Admin.Customers.CustomerNotes.List.Customer")]
        public int CustomerId { get; set; }

        [NopResourceDisplayName("Admin.Customers.CustomerNotes.List.CreatedOnFrom")]
        [UIHint("DateNullable")]
        public DateTime? CreatedOnFrom { get; set; }

        [NopResourceDisplayName("Admin.Customers.CustomerNotes.List.CreatedOnTo")]
        [UIHint("DateNullable")]
        public DateTime? CreatedOnTo { get; set; }

        public CustomerNoteModel CustomerNote { get; set; }

        #endregion
    }
}