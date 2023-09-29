using System.Collections.Generic;
using System.Collections.Specialized;
using Nop.Core.Domain.Common;
using Nop.Plugin.Misc.ZsWebApi.Models.Common;

namespace Nop.Plugin.Misc.ZsWebApi.Extensions
{
    public static class MappingExtensions
    {
        public static NameValueCollection ToNameValueCollection(this List<KeyValueApi> formValues)
        {
            var form = new NameValueCollection();
            foreach (var values in formValues)
            {
                form.Add(values.Key, values.Value);
            }
            return form;
        }

        public static Address AddressFromToModel(this NameValueCollection form)
        {
            var address = new Address()
            {
                FirstName = form["FirstName"],
                LastName = form["LastName"],
                Email = form["Email"],
                Address1 = form["Address1"],
                Address2 = form["Address2"],
                Company = form["Company"],
                ZipPostalCode = form["ZipPostalCode"],
                County = form["County"],
                City = form["City"],
                PhoneNumber = form["PhoneNumber"],
                FaxNumber = form["FaxNumber"],
            };

            int cId = 0;
            int.TryParse(form["CountryId"], out cId);
            if (cId > 0)
            {
                address.CountryId = cId;
            }
            int sId = 0;
            int.TryParse(form["StateProvinceId"], out sId);
            if (sId > 0)
            {
                address.StateProvinceId = sId;
            }
            return address;
        }
    }
}
