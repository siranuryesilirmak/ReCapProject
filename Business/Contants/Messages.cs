using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Contants
{
    public static class Messages
    {
        public static string BrandListed = "Markalar listelendi.";
        public static string ColorsListed = "renkler listelendi.";
        public static string CarAdded = "Araba eklendi.";
        public static string CarNameInvalid = "Arabanın açıklaması geçersiz.";
        public static string MaintenanceTime= "Sistem bakımda";
        public static string CarsListed = "arabalar listelendi";
        public  static string CarCountOfBrandCorrect = "bu markada en fazla 10 ürün olabilir";
        public static string DescriptionAlreadyExist = "Aynı isimde zaten başka bir açıklama var";
        public static string BrandLimitExceded = "Marka limiti aşıldığı için yeni ürün eklenemiyor.";
        public static string CarImageAdded = "resim eklendi";
        public static string CarImageLimitExceeded = "resim limiti aşıldı";
        public static string CarImageDeleted = "resim silindi";
        public static string CarImageUpdated = "resim güncellendi";
        public static string AuthorizationDenied = "Yetkiniz yok.";
        public static string RentalsListed = "kiralama bilgileri listelendi";
        public static string CarUpdated = "güncellendi.";
        public static string CustomersListed = "Müşteriler listelendi";

    }
}
