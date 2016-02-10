using Common.UIElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Common.Helpers
{
    public static class StaticVariables
    {
        #region set breadcrumbs
        //prjojeye eklenen ekranların breadcrumb  linklerini oluşturmak için o ekranların bağlantılarını aşağıdaki listeye eklemeliyiz.
        public static List<Breadcrumb> Breadcrumbs
        {
            get
            {
                return new List<Breadcrumb>()
                {
                new Breadcrumb(){Id=0,ParentId=0,ControllerName="Home",ActionName="index",ViewTitle="Anasayfa", BackButtonText=""},
                new Breadcrumb(){Id=1,ParentId=0,ControllerName="",ActionName="",ViewTitle="Borçlu İşlemleri", BackButtonText=""},
                new Breadcrumb(){Id=4,ParentId=1,ControllerName="debtor",ActionName="debt",ViewTitle="Borç Bilgileri", BackButtonText=""},
                new Breadcrumb(){Id=5,ParentId=1,ControllerName="debtor",ActionName="invoice",ViewTitle="Fatura Bilgileri", BackButtonText=""},
                new Breadcrumb(){Id=6,ParentId=1,ControllerName="debtor",ActionName="agreement",ViewTitle="Mutabakat Bilgileri", BackButtonText=""},
                new Breadcrumb(){Id=7,ParentId=1,ControllerName="debtor",ActionName="limit",ViewTitle="Yetkili Satıcı Limit Bilgileri", BackButtonText=""},
                new Breadcrumb(){Id=8,ParentId=0,ControllerName="",ActionName="",ViewTitle="Alacaklı İşlemleri", BackButtonText=""},
                new Breadcrumb(){Id=2,ParentId=8,ControllerName="creditor",ActionName="DebtorDebt",ViewTitle="Borçlu Borç Bilgileri", BackButtonText=""},
                new Breadcrumb(){Id=3,ParentId=8,ControllerName="creditor",ActionName="DebtorLimitRisk",ViewTitle="Borçlu Limit Risk Bilgileri", BackButtonText=""},
                new Breadcrumb(){Id=9,ParentId=8,ControllerName="creditor",ActionName="receivable",ViewTitle="Alacak Bilgileri", BackButtonText=""},               
                new Breadcrumb(){Id=10,ParentId=8,ControllerName="creditor",ActionName="payment",ViewTitle="Ödeme Tutar Bilgileri", BackButtonText=""},
                new Breadcrumb(){Id=11,ParentId=8,ControllerName="creditor",ActionName="invoice",ViewTitle="Fatura Bilgileri", BackButtonText=""},
                new Breadcrumb(){Id=12,ParentId=8,ControllerName="creditor",ActionName="agreement",ViewTitle="Mutabakat Bilgileri", BackButtonText=""},
                new Breadcrumb(){Id=13,ParentId=8,ControllerName="creditor",ActionName="sample",ViewTitle="Sample Page", BackButtonText=""},
                new Breadcrumb(){Id=14,ParentId=8,ControllerName="",ActionName="",ViewTitle="Ön Ödeme", BackButtonText=""},
                new Breadcrumb(){Id=15,ParentId=14,ControllerName="prefinance",ActionName="prefinanceinfo",ViewTitle="Ön Ödeme Blgileri", BackButtonText=""},
                new Breadcrumb(){Id=16,ParentId=14,ControllerName="prefinance",ActionName="prefinanceEntry",ViewTitle="Ön Ödeme Giriş", BackButtonText=""},
                new Breadcrumb(){Id=17,ParentId=0,ControllerName="",ActionName="",ViewTitle="Diğer", BackButtonText=""},
                new Breadcrumb(){Id=18,ParentId=17,ControllerName="Other",ActionName="stocks",ViewTitle="Stok İzle", BackButtonText=""},
                new Breadcrumb(){Id=19,ParentId=17,ControllerName="Other",ActionName="changePassword",ViewTitle="Şifre Değiştir", BackButtonText=""},
                new Breadcrumb(){Id=20,ParentId=17,ControllerName="Other",ActionName="vdfAutoFinance",ViewTitle="VDF Otomotiv Finansmanı", BackButtonText=""},
                new Breadcrumb(){Id=21,ParentId=14,ControllerName="prefinance",ActionName="prefinanceCollection",ViewTitle="Ön Ödeme Tahsilat Bilgileri", BackButtonText=""},
                new Breadcrumb(){Id=22,ParentId=21,ControllerName="prefinance",ActionName="prefinanceCollectionDetail",ViewTitle="Tahsilat Detayı", BackButtonText="Ön Ödeme Tahsilat Bilgileri"},
                new Breadcrumb(){Id=23,ParentId=0,ControllerName="",ActionName="",ViewTitle="Rehin İşlemleri", BackButtonText=""},
                new Breadcrumb(){Id=24,ParentId=23,ControllerName="tradeVehicle",ActionName="tradeVehicleList",ViewTitle="Takas Araç Bilgileri", BackButtonText=""},
                new Breadcrumb(){Id=25,ParentId=23,ControllerName="tradeVehicle",ActionName="pledgedVehicleList",ViewTitle="Rehin Araç Bilgileri", BackButtonText=""},
                new Breadcrumb(){Id=26,ParentId=0,ControllerName="",ActionName="",ViewTitle="Test İşlemleri", BackButtonText=""},
                new Breadcrumb(){Id=27,ParentId=26,ControllerName="Test",ActionName="Pjax1",ViewTitle="Pjax1", BackButtonText=""},
                new Breadcrumb(){Id=28,ParentId=26,ControllerName="Test",ActionName="Pjax2",ViewTitle="Pjax2", BackButtonText=""},
                new Breadcrumb(){Id=29,ParentId=26,ControllerName="home",ActionName="page1",ViewTitle="Page1", BackButtonText=""},
                new Breadcrumb(){Id=30,ParentId=26,ControllerName="home",ActionName="page2",ViewTitle="Page2", BackButtonText=""},
                new Breadcrumb(){Id=31,ParentId=26,ControllerName="test",ActionName="datagridsample",ViewTitle="Data Grid Sample", BackButtonText=""}
                };
            }
        }

        #endregion set breadcrumbs

        #region Page and DOM element titles
        #region Creditor
        public struct Creditor
        {
            public const string TITLE = "Müşteri Ünvanı";
            public const string AGREEMENT_INFO = "Alacaklı - Müşteri Mutabakat Bilgileri";
            public const string AGREEMENT_DETAIL_LIST = "Mütabakat Detay Listesi";
            public const string SAMPLE_PAGE = "This is a sample page";

            public const string DEBTOR_COLLECTION_COLLETERAL_INFO = "Borçlu Tahsilat ve Teminat Bilgileri";
            public const string DEBTOR_COLLECTION_INFO = "Borçlu Tahsilat Bilgileri";

            public const string DEBTOR_COLLECTION_LIST = "Borçlu Tahsilat Listesi";
            public const string DEBTOR_COLLETERAL_LIST = "Borçlu Teminat Listesi";
            public const string DEBTOR_LIMIT_RISK_INFO = "Borçlu Limit Risk Bilgileri ";
            public const string DEBTOR_LIMIT_RISK_LIST = "Borçlu Limit Risk Listesi ";
            public const string PREFINANCE_COLLECTION_INFO = "Ön Ödeme Tahsilat Bilgileri";
            public const string PREFINANCE_COLLECTION_DETAIL_INFO = "Ön Ödeme Tahsilat Detay Bilgileri";
            public const string PREFINANCE_COLLECTION_LIST = "Ön Ödeme Tahsilat Listesi ";
            public const string PREFINANCE_COLLECTION_DISTRIBUTION_LIST = "Ön Ödeme Tahsilat Dağılım Listesi ";
            public const string PREFINANCE_RETURNED_COLLECTION_LIST = "Ön Ödeme Devreden Tahsilat Listesi ";
            public const string PREFINANCE_RETURNED_COLLECTION_DETAIL = "Ön Ödeme Devreden Tahsilat Detayı ";
        }
        #endregion Creditor

        #region TradeVehicle
        public struct TradeVehicle
        {
            public const string TRADE_VEHICLE_INFO = "Takas Araç Bilgileri";
            public const string PLEDGED_VEHICLE_INFO = "Rehin Araç Bilgileri";
            public const string PLEDGED_VEHICLE_LIST = "Rehinli Araç Listesi";
            public const string PLEDGE_STATUS = "Rehin Durumu";
            public const string VEHICLE_LIST = "Araç Listesi";
            public const string VEHICLE_BRAND = "Marka";
            public const string VEHICLE_MODEL = "Model";
            public const string VEHICLE_SUB_MODEL = "Alt Model";
            public const string VEHICLE_BRAND_VALIDATED = "Marka*";
            public const string VEHICLE_MODEL_VALIDATED = "Model*";
            public const string VEHICLE_SUB_MODEL_VALIDATED = "Alt Model*";
            public const string VEHICLE_SUCCESSFULLY_INSERTED = "Araç girişi başarıyla tamamlanmıştır.";
            public const string VEHICLE_SUCCESSFULLY_UPDATED = "Araç başarıyla güncellenmiştir.";
            public const string VEHICLE_SUCCESSFULLY_DELETED = "Araç başarıyla silindi.";
            public const string VEHICLE_ADD_EDIT = "Araç giriş / güncelleme";
        }
        #endregion TradeVehicle

        #region Debtor
        public struct Debtor
        {
            public const string TITLE = "Borçlu Ünvanı";
            public const string TITLE_VALIDATED = "Borçlu Ünvanı*";
            public const string SEARCH = "Borçlu Arama";
            public const string LIST = "Borçlu Listesi";
        }

        #endregion Debtor

        #region Table Column Caption list
        public class TableColumnCaptions
        {
            public static List<string> DebtorCollectionAmountInfoFirst { get { return new List<string> { "ID", "Yetkili Satıcı", "", "GF Bakiyesi", "Stok Finansmanı" }; } }
            public static List<string> DebtorCollectionAmountInfoLast { get { return new List<string> { "Sonrası", "Toplam Faturalanmış", "Toplam Faturalanmamış", "Kullanılmış OYSF", "Teminat Mektubu(TL)", "Kefalet/Garantörlük(TL)", "E-Rehin(TL)", "Stok Rehin(TL)", "Havuz(TL)", "Alacak Temliki(TL)" }; } }
            public static List<string> DebtorLimitRiskAmountList { get { return new List<string> { "ID", "Yetkili Satıcı", "Limit Tipi", "LOB", "Toplam Risk", "Çatı Limiti", "GF Bakiyesi", "Kullanılabilir Limit", "VDF Ek Limit" }; } }
        }
        #endregion Table Column Caption lists
        #endregion Page and DOM element titles

        #region Common Static Texts
        public struct CommonTexts
        {
            public const string PLEASE_SELECT = "Lütfen seçiniz";
        }
        #endregion Common Static Texts

        #region Session Variables
        public struct Session
        {
            public const string CURRENT_USER = "CurrentUser";
            public const string CURRENT_USER_LAYOUT_CREDENTIALS = "CurrentUserLayoutCredentials";
            public const string CURRENT_PAGE_TABLE_MODEL_TO_EXPORT = "CurrentPageTableModelToExport"; //sayfalara ait tabloları excel e aktartmak için
            public const string CURRENT_POPUP_TABLE_MODEL_TO_EXPORT = "CurrentPopUpTableModelToExport";  //pop up lara ait tabloları excel e aktartmak için
            public const string CURRENT_USER_FROM = "CurrentUserFrom"; // smartnetten gelen requestlerin bypass edilmesi 
            public const string SMARTNET = "SmartNet";
            public const string BREADCRUMBS = "Breadcrumbs";
        }
        #endregion Session Variables

        #region Service URLs
        public struct ServiceURL
        {
            public const string FACTORING = "FactoringWS_URL";
            public const string SECURITY_SECURE = "SecuritySecureWS_URL";
        }
        #endregion Service URLs

        #region UserMessageTypes
        public struct UserMessageType
        {
            public const string NONE = "none";
            public const string SERVER_ERROR = "server-error";
            public const string ERROR = "error";
            public const string WARNING = "warning";
            public const string SUCCESS = "success";
            public const string INFO = "info";
        }
        #endregion  UserMessageTypes

        #region response messages
        public struct ResponseMessage
        {
            public const string RECORD_NOT_FOUND = "Listelenecek kayıt bulunamadı.";
            public const string TABLES_NOT_FOUND = "İlgili tablolar bulunamadı.";
            public const string MODELS_NOT_FOUND = "Araç modelleri bulunamadı.";
            public const string SUB_MODELS_NOT_FOUND = "Araç alt modelleri bulunamadı.";
            public const string INSURANCE_AMOUNT_NOT_FOUND = "Araç kasko değeri bulunamadı.";
            public const string PLEDGE_REMOVE_APPROVAL_ADDED = "Rehin Kaldırma onay süreci başlatıldı.";
            public const string PLEDGED_VEHICLE_NOT_FOUND = "EGM de, bu araca ait  aktif bir rehin bulunmamaktadır.";
            public const string PLEDGE_STATUS_NOT_FOUND = "Rehin durum bilgileri bulunamadı.";
            public const string PLEDGE_COLLETERAL_AGE_NOT_AVAILABLE = "{0} ve daha yaşlı araçlar için rehin teminatı yaratılamaz.";
        }
        #endregion response messages

        #region DOM element validations
        public struct Validation
        {
            public const string REQUIRED_CLASS = "validation-required"; // css class of required inputs
            public const string PLATE_CLASS = "validation-plate"; // css class of plate inputs            
            public const string GENERIC_REQUIRED = "{0} alanı zorunludur.";
            public const string PLATE_MAX_LENGTH = "{0} alanı için max 10 karakter giriniz. Örn: 34ABC100";
            public const string PLATE = "{0} alanı için girilen format hatalı. Örn: 34ABC100";
            public const string DEBTOR_REQUIRED = StaticVariables.Debtor.TITLE + " alanı zorunludur.";
            public const string BRAND_REQUIRED = StaticVariables.TradeVehicle.VEHICLE_BRAND + " alanı zorunludur.";
            public const string MODEL_REQUIRED = StaticVariables.TradeVehicle.VEHICLE_MODEL + " alanı zorunludur.";
            public const string SUB_MODEL_REQUIRED = StaticVariables.TradeVehicle.VEHICLE_SUB_MODEL + " alanı zorunludur.";
            public const string REGISTRATION_NUMBER_OR_ABSIS_REQUIRED = "Ruhsat Tescil yada Absis Numarasından birinin girilmesi zorunludur.";
            public const string REGISTRATION_NUMBER_MAX_LENGTH = "{0} alanı için max 25 karakter giriniz.";
            public const string ABSIS_LENGTH = "{0} alanı 19 karakter olmalıdır.";
        }
        #endregion DOM element validations

    }

    #region Enumerators
    public enum AuthenticationMode
    {
        Network = 0,
        Application = 1,
        Both = 2,
        None = 3,
        BothSecure = 4
    }

    public enum ResponseCode
    {
        Fail = 0,
        Success,
        Warning,
        Info,
        NoEffect
    }

    public enum DataExportType
    {
        FromPage,
        FromPopUp
    }

    public enum DataLoadType
    {
        AsPage,
        AsModalBox
    }
    public enum ColumnDataFormat
    {
        Default,
        Date,
        Money
    }

    public enum ColumnDataType
    {
        Text,
        LinkButton,
        ImageButton,
    }

    public enum DataSearchType
    {
        Text,
        Dropdown,
        DatePicker,
        DateRangePicker
    }

    public enum PagingType
    {
        ClientSide, // retrieve all data and process operations like listing, paging, sorting on client side using js.
        ServerSide // retrieve only needed data  and process operations via server side requests
    }

    #endregion Enumerators

}