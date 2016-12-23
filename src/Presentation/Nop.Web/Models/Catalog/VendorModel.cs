using System.Collections.Generic;
using Nop.Web.Framework.Mvc;
using System.Linq;
using Nop.Web.Models.Media;

namespace Nop.Web.Models.Catalog
{
    public partial class VendorModel : BaseNopEntityModel
    {
        public VendorModel()
        {
            PictureModel = new PictureModel();
            Products = new List<ProductOverviewModel>();
            PagingFilteringContext = new CatalogPagingFilteringModel();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string MetaTitle { get; set; }
        public string SeName { get; set; }
        public bool AllowCustomersToContactVendors { get; set; }

        public PictureModel PictureModel { get; set; }

        public CatalogPagingFilteringModel PagingFilteringContext { get; set; }

        public IList<ProductOverviewModel> Products { get; set; }

        public Core.Domain.Customers.Customer VendorManager { get; set; }

        public string Address
        {
            get
            {
                if (VendorManager == null)
                    return string.Empty;

                if (VendorManager.Addresses.Count == 0)
                    return string.Empty;

                var address = VendorManager.Addresses.First();

                var addressParts = new List<string>();
                addressParts.Add(address.Address1);
                addressParts.Add(address.Address2);
                addressParts.Add(address.City);
                addressParts.Add(address.ZipPostalCode);
                addressParts.Add(address.StateProvince.Name);
                addressParts.Add(address.Country.Name);

                return string.Join(", ", addressParts.Where(a => !string.IsNullOrEmpty(a)));
            }
        }

        public string PhoneNumber
        {
            get
            {
                if (VendorManager == null)
                    return string.Empty;

                if (VendorManager.Addresses.Count == 0)
                    return string.Empty;

                var address = VendorManager.Addresses.First();

                return address.PhoneNumber;
            }
        }
    }
}