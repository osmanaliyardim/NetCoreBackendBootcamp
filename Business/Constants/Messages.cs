using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        //Products
        public static string ProductAdded = "Ürün başarıyla eklendi!";
        public static string ProductDeteled = "Ürün başarıyla silindi!";
        public static string ProductUpdated = "Ürün başarıyla güncellendi!";
        public static string ProductByIdListed = "Ürün başarıyla listelendi!";
        public static string ProductsListed = "Tüm ürünler başarıyla listelendi!";
        public static string ProductsByCategoryListed = "Seçtiğiniz kategorideki tüm ürünler başarıyla listelendi!";

        public static string ProductNameAlreadyExists = "Bu ürün zaten mevcut!";

        //Categories
        public static string CategoryAdded = "Kategori başarıyla eklendi!";
        public static string CategoryDeteled = "Kategori başarıyla silindi!";
        public static string CategoryUpdated = "Kategori başarıyla güncellendi!";
        public static string CategoryByIdListed = "Kategori başarıyla listelendi!";
        public static string CategoriesListed = "Tüm kategoriler başarıyla listelendi!";
        public static string NumOfCategoriesListed = "Kategori sayıları listelendi!";

        //Users
        public static string UserAdded = "Kullanıcı başarıyla eklendi!";
        public static string UserDeteled = "Kullanıcı başarıyla silindi!";
        public static string UserUpdated = "Kullanıcı başarıyla güncellendi!";
        public static string UserByIdListed = "Kullanıcı başarıyla listelendi!";
        public static string UsersListed = "Tüm kullanıcılar başarıyla listelendi!";
        public static string UserByClaimListed = "Kullanıcının rolleri başarıyla listelendi!";
        public static string UserByMailListed = "Kullanıcı başarıyla listelendi!";
        
        //Authentication
        public static string UserNotFound = "Kullanıcı bulunamadı!";
        public static string PasswordInvalid = "Geçersiz şifre!";
        public static string LoginSuccessful = "Giriş başarılı!";
        public static string UserAlreadyExist = "Bu email zaten kayıtlı!";
        public static string UserRegistered = "Kayıt başarılı!";
        public static string AccessTokenCreated = "Access Token başarıyla oluşturuldu!";
        
        //Authorization
        public static string AuthorizationDenied = "Bu işlem için yetkiniz yok!";
    }
}
