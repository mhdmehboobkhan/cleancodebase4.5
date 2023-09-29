using Nop.Web.Framework.Models;

namespace Nop.Web.Areas.Admin.Models.Customers
{
    /// <summary>
    /// Represents an customer note list model
    /// </summary>
    public partial record CustomerNoteListModel : BasePagedListModel<CustomerNoteModel>
    {
    }
}