using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using VdfFactoring.ViewModels;

namespace VdfFactoring
{
    public class CustomerDataGenerator
    {
        public List<string> FirstNameList { get; private set; }
        public List<string> LastNameList { get; private set; }
        public List<string> PositionList { get; private set; }
        public List<string> OfficeList { get; private set; }
        public List<DateTime> StartDateList { get; private set; }
        public List<decimal> SalaryList { get; private set; }

        public List<CustomerModel> GenerateCustomerList(DataGridRequestQueryString queryString)
        {
            DataGridOrderType orderType = queryString.orderBy == "asc" ? DataGridOrderType.Asc : DataGridOrderType.Desc;

            if (HttpContext.Current.Session["customers"] != null)
            {
                var list = HttpContext.Current.Session["customers"] as List<CustomerModel>;

                var sessionList = Sort(list, queryString.orderedColumnName, orderType);

                return sessionList.Skip(queryString.start).Take(queryString.length).ToList();
            }
            var customerList = new List<CustomerModel>();

            #region Generate sample data

            FirstNameList = new List<string>();

            FirstNameList.Add("Mustafa");
            FirstNameList.Add("Ali");
            FirstNameList.Add("Veli");
            FirstNameList.Add("Hakkı");
            FirstNameList.Add("Siraç");
            FirstNameList.Add("Veli");
            FirstNameList.Add("Muhammed");
            FirstNameList.Add("Cetin");
            FirstNameList.Add("Kadir");
            FirstNameList.Add("Serap");
            FirstNameList.Add("Selin");
            FirstNameList.Add("Mehtap");
            FirstNameList.Add("Dursun");
            FirstNameList.Add("Selami");
            FirstNameList.Add("Yavuz");

            LastNameList = new List<string>();
            LastNameList.Add("Korkmaz");
            LastNameList.Add("Kayak");
            LastNameList.Add("Yılmaz");
            LastNameList.Add("Gönenç");
            LastNameList.Add("Türkoglu");
            LastNameList.Add("Eskir");
            LastNameList.Add("Kose");
            LastNameList.Add("Solmaz");
            LastNameList.Add("Turhanlı");
            LastNameList.Add("Tavlı");
            LastNameList.Add("Bozkurt");
            LastNameList.Add("Yıldırım");
            LastNameList.Add("Tatar");
            LastNameList.Add("Kırkıl");
            LastNameList.Add("Cetin");

            PositionList = new List<string>();
            PositionList.Add("Müdür");
            PositionList.Add("Yönetici");
            PositionList.Add("Uzman");
            PositionList.Add("Yetkili");
            PositionList.Add("Tasarımcı");
            PositionList.Add("CEO");
            PositionList.Add("CFO");

            OfficeList = new List<string>();
            OfficeList.Add("Soma");
            OfficeList.Add("Kırkagac");
            OfficeList.Add("Akhisar");
            OfficeList.Add("Salihli");
            OfficeList.Add("Demirci");
            OfficeList.Add("Alaşehir");
            OfficeList.Add("Saruhanlı");
            OfficeList.Add("Golmarmara");


            StartDateList = new List<DateTime>();
            for (int i = 0; i < 20; i++)
            {
                StartDateList.Add(DateTime.Now.AddDays((i + 1) * (-10)));
            }

            SalaryList = new List<decimal>();
            Random random = new Random();
            for (int i = 0; i < 20; i++)
            {
                var d = random.NextDouble() * (500 - 100) + 100;
                SalaryList.Add(Convert.ToDecimal(Math.Round(d, 2)));
            }
            for (int i = 0; i < 505; i++)
            {
                var firstName = FirstNameList[random.Next(0, 14)];
                var lastName = LastNameList[random.Next(0, 14)];
                var position = PositionList[random.Next(0, 6)];
                var office = OfficeList[random.Next(0, 7)];
                var startDate = StartDateList[random.Next(0, 19)].ToShortDateString();
                var salary = SalaryList[random.Next(0, 19)];

                customerList.Add(new CustomerModel
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Position = position,
                    Office = office,
                    Salary = salary,
                    StartDate = startDate
                });
            }

            #endregion Generate sample data

            HttpContext.Current.Session["customers"] = customerList;

            var customerQuery = Sort(customerList, queryString.orderedColumnName, orderType);

            return customerQuery.Skip(queryString.start).Take(queryString.length).ToList();
        }

        private IOrderedEnumerable<T> Sort<T>(List<T> unSortedlist, string propertyName, DataGridOrderType orderType)
        {
            bool isDateOrdering = propertyName.ToLower().Contains("date");

            PropertyInfo pi = typeof(T).GetProperty(propertyName);
            switch (orderType)
            {
                case DataGridOrderType.Asc:

                    if (isDateOrdering)
                    {
                        return unSortedlist.OrderBy(x => DateTime.Parse(pi.GetValue(x, null).ToString()));
                    }
                    return unSortedlist.OrderBy(x => pi.GetValue(x, null));
                case DataGridOrderType.Desc:

                    if (isDateOrdering)
                    {
                        return unSortedlist.OrderByDescending(x => DateTime.Parse(pi.GetValue(x, null).ToString()));
                    }
                    return unSortedlist.OrderByDescending(x => pi.GetValue(x, null));

                default: return null;
            }
        }
    }
}

