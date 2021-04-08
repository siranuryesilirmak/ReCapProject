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

        public static string CarAdded = "Araba eklendi.";
        public static string CarNameInvalid = "Arabanın açıklaması geçersiz.";
        public static string MaintenanceTime= "Sistem bakımda";
        public static string CarsListed = "arabalar listelendi";
        public  static string CarCountOfBrandCorrect = "bu markada en fazla 10 ürün olabilir";
        public static string DescriptionAlreadyExist = "Aynı isimde zaten başka bir açıklama var";
        public static string BrandLimitExceded = "Marka limiti aşıldığı için yeni ürün eklenemiyor.";
        public static string CarImageAdded;
        public static string CarImageLimitExceeded;
        public static string CarImageDeleted;
        public static string CarImageUpdated;
        public static string AuthorizationDenied = "Yetkiniz yok.";
    }
}
