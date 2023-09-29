using Nop.Web.Framework.Models;

namespace Nop.Web.Models.Customer
{
    /// <summary>
    /// Represents an customer note list model
    /// </summary>
    public partial record CustomerNoteListModel : BasePagedListModel<CustomerNoteModel>
    {
    }
}