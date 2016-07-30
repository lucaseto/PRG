using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PRDGSTTest_Client.Models
{
    public class Product
    {
        [Display(Name = "Id")]
        public int ProductID { get; set; }
        [Required(ErrorMessage = "Please enter a name")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Product Number")]
        [Required(ErrorMessage = "Please enter a Product Number")]

        public string ProductNumber { get; set; }
        [Display(Name = "Color")]

        public string Color { get; set; }


        [Display(Name = "Standard Cost")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        [Required(ErrorMessage = "Please enter a name")]
        public decimal StandardCost { get; set; }


        [Display(Name = "List Price")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        [Required(ErrorMessage = "Please enter a List Price")]
        public decimal ListPrice { get; set; }



        [Display(Name = "Size")]
        public string Size { get; set; }


        [Display(Name = "Weight")]
        public Nullable<decimal> Weight { get; set; }

        [Display(Name = "Product Category ID")]

        public Nullable<int> ProductCategoryID { get; set; }
        [Display(Name = "Product Model ID")]

        public Nullable<int> ProductModelID { get; set; }



        [Display(Name = "Sell Start Date")]
        [Required(ErrorMessage = "Please enter a Sell Start Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
        public System.DateTime SellStartDate { get; set; }


        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Sell End Date")]
        public Nullable<System.DateTime> SellEndDate { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Discontinued Date")]
        public Nullable<System.DateTime> DiscontinuedDate { get; set; }


        [Display(Name = "ThumbNail Photo")]
        public byte[] ThumbNailPhoto { get; set; }

        public string ThumbNailPhotoDisplay
        {
            get
            {
                if (ThumbNailPhoto != null)
                {
                    var base64 = Convert.ToBase64String(ThumbNailPhoto);
                    return String.Format("data:image/gif;base64,{0}", base64);
                }
                return string.Empty;
            }
        }

        [Display(Name = "Thumbnail Photo File Name")]

        public string ThumbnailPhotoFileName { get; set; }
        [Display(Name = "rowguid")]
        [Required(ErrorMessage = "Please enter a rowguid")]

        public System.Guid rowguid { get; set; }
        [Display(Name = "Modified Date")]
        [Required(ErrorMessage = "Please enter a Modified Date")]

        public System.DateTime ModifiedDate { get; set; }

    }
}