using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
  public static  class Messages
    {
        //Çok destekli yapıya getirebeiliriz.
        public static string ProductAdded = "Ürün Eklendi";
        public static string ProductNameInvalid = "Ürün İsmi Geçersiz";
        public  static string  MaintenanceTime="sistem bakımda";
        public  static string ProductListed="ürünler listelendi";
        internal static string ProductCountOfCategoryError="ürün sayısı kategori için fazla";
        internal static string ProductNameAlreadyExists="Bu adda zaten ürün bulunmaktadır";
        internal static string CategoryLimitExceded="Kategori limit aşıldı için yeni ürün eklenemiyor";
        internal static object CategoryListed;
    }
}
