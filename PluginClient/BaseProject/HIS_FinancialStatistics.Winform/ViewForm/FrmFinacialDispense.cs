﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using EfwControls.CustomControl;
using EFWCoreLib.CoreFrame.Business;
using HIS_FinancialStatistics.Winform.IView;

namespace HIS_FinancialStatistics.Winform.ViewForm
{
    /// <summary>
    /// 发药人员工作量统计
    /// </summary>
    public partial class FrmFinacialDispense : BaseFormBusiness, IFrmFinacialDispense
    {
        /// <summary>
        /// 构造
        /// Initializes a new instance of the<see cref="FrmFinacialDispense" /> class.
        /// </summary>
        public FrmFinacialDispense()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 设置组织机构
        /// </summary>
        /// <param name="dtWorker">组织机构数据</param>
        public void SetWorkers(DataTable dtWorker)
        {
            cmbWorker.DisplayMember = "WorkName";
            cmbWorker.ValueMember = "WorkId";
            cmbWorker.DataSource = dtWorker;
        }

        /// <summary>
        /// 窗体打开事件
        /// </summary>
        /// <param name="sender">控件对象</param>
        /// <param name="e">事件参数</param>
        private void FrmFinacialCharger_OpenWindowBefore(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            DateTime d1 = new DateTime(now.Year, now.Month, 1);//当前月第一天
            DateTime d2 = d1.AddMonths(1).AddDays(-1);//当前月最后一天
            sdtDate.Bdate.Value = d1;
            sdtDate.Edate.Value = d2;
            DataTable dt = (DataTable)InvokeController("GetWorker");
            SetWorkers(dt);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender">控件对象</param>
        /// <param name="e">事件参数</param>
        private void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                GridViewResult.Stop();
                this.Cursor = Cursors.WaitCursor;
                DateTime bdate = Convert.ToDateTime(sdtDate.Bdate.Value.ToString("yyyy-MM-dd 00:00:00"));
                DateTime edate = Convert.ToDateTime(sdtDate.Edate.Value.ToString("yyyy-MM-dd 23:59:59"));
                int queryWorkId = Convert.ToInt32(cmbWorker.SelectedValue);
                string currentUserName = (string)InvokeController("GetCurrentUserName");
                DataTable dtReport = (DataTable)InvokeController("GetFinacialDispenseData", frmName, bdate, edate, queryWorkId);
                Dictionary<string, object> myDictionary = new Dictionary<string, object>();
                myDictionary.Add("Title", cmbWorker.Text.Trim() + "发药人员工作量统计");
                myDictionary.Add("DateRange", sdtDate.Bdate.Value.ToString("yyyy-MM-dd") + "至" + sdtDate.Edate.Value.ToString("yyyy-MM-dd"));
                myDictionary.Add("Printer", currentUserName);
                GridReport gridreport = new GridReport();
                gridreport = ReportTool.GetReport((InvokeController("this") as AbstractController).LoginUserInfo.WorkId, 4019, 0, myDictionary, dtReport);
                GridViewResult.Report = gridreport.Report;
                GridViewResult.Start();
                GridViewResult.Refresh();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender">控件对象</param>
        /// <param name="e">事件参数</param>
        private void BtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                GridViewResult.PostColumnLayout();
                GridViewResult.Report.PrintPreview(true);
            }
            catch (Exception error)
            {
                MessageBoxEx.Show(error.Message);
            }
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender">控件对象</param>
        /// <param name="e">事件参数</param>
        private void BtnClose_Click(object sender, EventArgs e)
        {
            InvokeController("Close", this);
        }

        /// <summary>
        /// 窗体关闭事件
        /// </summary>
        /// <param name="sender">控件对象</param>
        /// <param name="e">事件参数</param>
        private void FrmFinacialCharger_FormClosed(object sender, FormClosedEventArgs e)
        {
            GridViewResult.Stop();
        }
    }
}
