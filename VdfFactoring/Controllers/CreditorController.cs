using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common.Helpers;
using Pjax.Mvc5;


namespace VdfFactoring.Controllers
{
    //  [FsisAuthentication]
    [Pjax]
    public class CreditorController : BaseController, IPjax
    {
        //protected readonly ICreditor creditor;

        //public CreditorController(ICreditor creditor)
        //{
        //    this.creditor = creditor;
        //}

        public bool IsPjaxRequest { get; set; }

        public string PjaxVersion { get; set; }


        public ActionResult DebtorDebt()
        {
            return View();
        }

        public ActionResult DebtorLimitRisk()
        {
            return View();
        }

        public ActionResult Receivable()
        {
            return View();
        }

        public ActionResult Payment()
        {
            return View();
        }

        public ActionResult Agreement()
        {

            return View();
        }

        public ActionResult Invoice()
        {

            return View();
        }

        /*
                #region Borçlu Tahsilat ve Teminat Bilgileri Sayfası

                //Get:/creditor/DebtorDebt
                public ActionResult DebtorDebt()
                {

                    BLDebtorDebt blDebtorDebt = new BLDebtorDebt();

                    if (ViewBag.UserLayoutCredentials.TEMINAT_RAPORU)
                    {
                        ViewBag.Title = StaticVariables.Creditor.DEBTOR_COLLECTION_COLLETERAL_INFO;
                    }
                    else
                        ViewBag.Title = StaticVariables.Creditor.DEBTOR_COLLECTION_INFO;

                    DataTable dt = new DataTable(StaticVariables.Creditor.DEBTOR_COLLECTION_LIST);

                    List<SelectOption> creditorOptionList = new List<SelectOption>();
                    var user = SessionHelper.GetValue<PCWebUser>(StaticVariables.Session.CURRENT_USER);

                    if (user.UserType == "V" && user.CompanyId == 0 && user.CompanyName == "")
                    {
                        //to do get all comnpanies
                        DataTable creditorTable = creditor.GetCreditorTable(0).Data;
                        creditorTable.TableName = StaticVariables.Creditor.DEBTOR_COLLECTION_INFO;
                        creditorOptionList = StaticMethods.GetSelectOptionList(ref creditorTable,"DistributorName","DistributorId");
                    }
                    else if (user.UserType == "Y" || user.UserType == "D")
                    {
                        // get only related company
                        SelectOption o = new SelectOption();
                        o.Value = user.CompanyId.ToString();
                        o.Text = user.CompanyName;
                        creditorOptionList.Add(o);
                    }

                    CreditorRelatedDebtorDebtModel model = new CreditorRelatedDebtorDebtModel();
                    model.DebtorDebtTable = new DataTableModel(dt);
                    model.DebtorDebtTable.IsVisible = false; // dropDown listten herhangi birşey secilmediği müddetce tablonun ekrana basılmasına gerek yok.
                    model.CreditorDropdown = new DropdownModel(StaticVariables.Creditor.TITLE);
                    model.CreditorDropdown.SelectOptions = creditorOptionList;
                    SetCurrentPageTableModelToExport(model.DebtorDebtTable);

                    if (Request.IsAjaxRequest())
                        return PartialView(model);
                    else return View(model);
                }

                //post:/creditor/LoadDebtorDebtTable
                [HttpPost]
                public ActionResult LoadDebtorDebtTable(CreditorRelatedDebtorDebtModel model)
                {
                    int creditorId = 0;
                    bool isValid = Int32.TryParse(model.CreditorDropdown.Value, out creditorId);
                    //   var summaryColumnList = new List<int>() { 3, 4 }; // ÖNEMLİ: buradaki amaç 4 ve 5. kolondan summary almaktır (startIndex= 0).  tablodaki ilk kolon "Satır Seçme Chexk box" ise dataTable daki 5 ve 6. kolonlara tekabul eder.

                    DataTable dt = new DataTable();
                    DataSet ds = this.creditor.GetCollectionAmountTable(creditorId).Data;
                    if (ds.Tables.Count > 0)
                    {
                        dt = ds.Tables[1];
                    }
                    dt.TableName = StaticVariables.Creditor.DEBTOR_COLLECTION_INFO;
                    List<string> captionList = StaticVariables.TableColumnCaptions.DebtorCollectionAmountInfoFirst;

                    for (int i = 1; i < ds.Tables[0].Rows.Count - 1; i++)
                    {
                        captionList.Add((Convert.ToDateTime(ds.Tables[0].Rows[i]["EndDate"]).ToFSISDateFormat()));
                    }

                    captionList.AddRange(StaticVariables.TableColumnCaptions.DebtorCollectionAmountInfoLast);

                    dt.SetTableCaptions(captionList);

                    DataTableModel dtModel = SetDebtorDebtTableModel(ref dt, model.ListCollections);
                    SetCurrentPageTableModelToExport(dtModel); // excel export için session daki objeyi guncelle

                    // DataTableModel model = new DataTableModel(new BLSample().LoadAgreementTableFromFactoringService(450)) { ShowFooter = true, SummaryColumnsList = summaryColumnList };
                    if (Request.IsAjaxRequest())
                        return PartialView("_DataTable", dtModel);
                    else return View();
                }

                /// <summary>
                ///  borclu bilgisine ait table model i doldurur
                /// </summary>
                /// <param name="source"></param>
                /// <param name="listCollections"></param>
                /// <returns></returns>
                private DataTableModel SetDebtorDebtTableModel(ref DataTable source, string listCollections)
                {
                    DataTableModel model = new DataTableModel(source);
                    model.IdColunmName = "DealerId";  // tabloda id olarak kullacağımız kolon adı
                    model.IsRowsEditable = false;
                    model.HiddenColumnsList.AddRange(new int[] { 0, 2 });

                    if (listCollections == "1") // Tahsilatlar Raporu
                    {
                        source.TableName = StaticVariables.Creditor.DEBTOR_COLLECTION_LIST;
                        for (int i = source.Columns.Count - 6; i < source.Columns.Count; i++)
                        {
                            model.HiddenColumnsList.Add(i);
                        }
                    }
                    else
                    {
                        source.TableName = StaticVariables.Creditor.DEBTOR_COLLETERAL_LIST;
                        for (int i = 3; i < source.Columns.Count - 6; i++)
                        {
                            model.HiddenColumnsList.Add(i);
                        }
                    }

                    int[] array = new int[model.DataTable.Columns.Count - 3];
                    for (int i = 0; i < array.Length; i++)
                    {
                        array[i] = i + 3;

                    }
                    model.SetColumnDataFormat(ColumnDataFormat.Money, array);
                    return model;
                }
                #endregion Borçlu Tahsilat ve Teminat Bilgileri Sayfası

                #region Borçlu Limit Risk İzleme Sayfası

                //Get:/creditor/DebtorLimitRisk
                public ActionResult DebtorLimitRisk()
                {

                    BLDebtorLimitRisk blLimitRisk = new BLDebtorLimitRisk();
                    @ViewBag.Title = StaticVariables.Creditor.DEBTOR_LIMIT_RISK_INFO;
                    DataTable dt = new DataTable(StaticVariables.Creditor.DEBTOR_LIMIT_RISK_INFO);

                    List<SelectOption> creditorOptionList = new List<SelectOption>();
                    var user = SessionHelper.GetValue<PCWebUser>(StaticVariables.Session.CURRENT_USER);

                    if (user.UserType == "V" && user.CompanyId == 0 && user.CompanyName == "")
                    {
                        //to do get all comnpanies
                        DataTable creditorTable = creditor.GetCreditorTable(0).Data;
                        creditorTable.TableName = StaticVariables.Creditor.DEBTOR_LIMIT_RISK_INFO;
                        creditorOptionList = StaticMethods.GetSelectOptionList(ref creditorTable,"DistributorName","DistributorId");
                    }
                    else if (user.UserType == "Y" || user.UserType == "D")
                    {
                        // get only related company
                        SelectOption o = new SelectOption();
                        o.Value = user.CompanyId.ToString();
                        o.Text = user.CompanyName;
                        creditorOptionList.Add(o);
                    }

                    CreditorRelatedDebtorLimitRiskModel model = new CreditorRelatedDebtorLimitRiskModel();
                    model.DebtorLimitRiskTable = new DataTableModel(dt);
                    model.DebtorLimitRiskTable.IsVisible = false; // dropDown listten herhangi birşey secilmediği müddetce tablonun ekrana basılmasına gerek yok.
                    model.Dropdown = new DropdownModel(StaticVariables.Creditor.TITLE);
                    model.Dropdown.SelectOptions = creditorOptionList;
                    SetCurrentPageTableModelToExport(model.DebtorLimitRiskTable);
                    if (Request.IsAjaxRequest())
                        return PartialView(model);
                    else return View(model);
                }

                //post:/creditor/LoadDebtorLimitRiskTable
                [HttpPost]
                public ActionResult LoadDebtorLimitRiskTable(CreditorRelatedDebtorLimitRiskModel model)
                {
                    int creditorId = 0;
                    bool isValid = Int32.TryParse(model.Dropdown.Value, out creditorId);
                    //   var summaryColumnList = new List<int>() { 3, 4 }; // ÖNEMLİ: buradaki amaç 4 ve 5. kolondan summary almaktır (startIndex= 0).  tablodaki ilk kolon "Satır Seçme Chexk box" ise dataTable daki 5 ve 6. kolonlara tekabul eder.

                    DataTable dt = new DataTable();
                    DataSet ds = this.creditor.GetLimitRiskAmountTable(creditorId).Data;
                    if (ds.Tables.Count > 0)
                    {
                        dt = ds.Tables[0];
                    }
                    dt.TableName = StaticVariables.Creditor.DEBTOR_LIMIT_RISK_LIST;

                    DataTableModel dtModel = SetDebtorLimitRiskTable(ref dt);
                    SetCurrentPageTableModelToExport(dtModel);
                    if (Request.IsAjaxRequest())
                        return PartialView("_DataTable", dtModel);
                    else return View();
                }

                private DataTableModel SetDebtorLimitRiskTable(ref DataTable source)
                {
                    //List<string> captionList = StaticVariables.TableColumnCaptions.DebtorLimitRiskAmountList;
                    //dt.SetTableCaptions(captionList);
                    DataTableModel dtModel = new DataTableModel(source);
                    dtModel.IdColunmName = "DealerId";  // tabloda id olarak kullacağımız kolon adı
                    dtModel.IsRowsEditable = false;
                    int[] array = new int[dtModel.DataTable.Columns.Count - 3]; // ilk 3 kolon harici hepsi money format
                    for (int i = 0; i < array.Length; i++)
                    {
                        array[i] = i + 3;
                    }
                    dtModel.SetColumnDataFormat(ColumnDataFormat.Money, array);
                    dtModel.HiddenColumnsList.Add(0);

                    return dtModel;
                }

                #endregion Borçlu Limit Risk İzleme Sayfası
          */

        #region creditor pages common methods

        #endregion creditor pages common methods

    }
}
