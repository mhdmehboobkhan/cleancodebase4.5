using System.Collections.Generic;
using Nop.Web.Framework.Models;
using Nop.Web.Models.Common;

namespace Nop.Web.Models.Customer
{
    public partial record CustomerAddressListModel : BasePagedListModel<AddressModel>
    {
        public CustomerAddressListModel()
        {
            Addresses = new List<AddressModel>();
        }

        public IList<AddressModel> Addresses { get; set; }
    }

    /// <summary>
    /// Represents a customer address search model
    /// </summary>
    public partial record CustomerAddressSearchModel : BaseSearchModel
    {
    }
}