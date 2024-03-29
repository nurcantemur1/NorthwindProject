﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductUptated = "Ürün güncellendi";
        public static string ProductDeleted = "Ürün silindi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string ProductNameAlreadyExists="bu isimde başka bir ürün var";

        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";

        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string CategoryListed="kategoriler listelendi";
        public static string ProductListed="ürünler listelendi";
    }
}
