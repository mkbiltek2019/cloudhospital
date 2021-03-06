﻿using HIS_Entity.MIManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS_MIInterface.Interface.BaseClass
{
    /// <summary>
    /// 医保报销门诊接口处理
    /// </summary>
    public interface MIMzInterface
    {
        /// <summary>
        /// 获取卡片信息病人列表
        /// </summary>
        /// <returns></returns>
        ResultClass MZ_GetCardInfo(InputClass inputClass);//string sCardNo);

        /// <summary>
        /// 根据身份证号查找农合病人
        /// </summary>
        ResultClass MZ_GetPersonInfo(InputClass inputClass);//string sCardNo);

        /// <summary>
        /// 门诊预登记
        /// </summary>
        /// <returns></returns>
        ResultClass MZ_PreviewRegister(InputClass inputClass);//MI_Register register);

        /// <summary>
        /// 门诊登记
        /// </summary>
        /// <returns></returns>
        ResultClass MZ_Register(InputClass inputClass);//int registerId, string serialNO);

        ///// <summary>
        ///// 回滚门诊医保登记
        ///// </summary>
        ///// <returns></returns>
        //ResultClass MZ_RegisterRollBack(InputClass inputClass);//int registerId, string serialNO);
        
        /// <summary>
        /// 门诊登记后更新
        /// </summary>
        /// <returns></returns>
        ResultClass MZ_UpdateRegister(InputClass inputClass);//int registerId, string serialNO);
        
        /// <summary>
        /// 取消门诊登记
        /// </summary>
        /// <returns></returns>
        ResultClass MZ_CancelRegister(InputClass inputClass);//string serialNO);
        /// <summary>
        /// 确认取消挂号
        /// </summary>
        /// <param name="inputClass"></param>
        /// <returns></returns>
        ResultClass MZ_CancelRegisterCommit(InputClass inputClass);
        /// <summary>
        /// 预算
        /// </summary>
        /// <returns></returns>
        ResultClass MZ_PreviewCharge(InputClass inputClass);//TradeData tradedata);
        /// <summary>
        /// 结算
        /// </summary>
        /// <returns></returns>
        ResultClass MZ_Charge(InputClass inputClass);//int tradeRecordId, string fph);
        /// <summary>
        /// 取消门诊结算
        /// </summary>
        /// <returns></returns>
        ResultClass MZ_CancelCharge(InputClass inputClass);//string fph);
        /// <summary>
        /// 确认取消门诊结算
        /// </summary>
        /// <param name="inputClass"></param>
        /// <returns></returns>
        ResultClass MZ_CancelChargeCommit(InputClass inputClass);
        /// <summary>
        /// 交易状态查询
        /// </summary>
        /// <param name="inputClass"></param>
        /// <returns></returns>
        ResultClass MZ_CommitTradeState(InputClass inputClass);
        /// <summary>
        /// 发票重打
        /// </summary>
        /// <param name="inputClass"></param>
        /// <returns></returns>
        ResultClass MZ_RePrintInvoice(InputClass inputClass);
        ResultClass MZ_PrintInvoice(InputClass inputClass);
        /// <summary>
        /// HIS自行打印发票
        /// </summary>
        /// <param name="inputClass"></param>
        /// <returns></returns>
        ResultClass MZ_HISPrintInvoice(InputClass inputClass);
        /// <summary>
        /// 上传门诊病人费用
        /// </summary>
        /// <returns></returns>
        ResultClass MZ_UploadzyPatFee(InputClass inputClass); 
        /// <summary>
        /// 下载门诊病人费用数据
        /// </summary>
        /// <returns></returns>
        ResultClass MZ_DownloadzyPatFee(InputClass inputClass); 

        //获取已结算费用
        ResultClass MZ_LoadFeeDetailByTicketNum(InputClass inputClass);

        /// <summary>
        /// 根据医保交易状态更新交易记录
        /// </summary>
        /// <param name="inputClass"></param>
        /// <returns></returns>
        ResultClass Mz_UpdateTradeRecord(InputClass inputClass);


        /// <summary>
        /// 根据就诊号 获取挂号交易流水号
        /// </summary>
        /// <param name="sSerialNO">挂号就诊号</param>
        /// <returns></returns>
        ResultClass Mz_GetRegisterTradeNo(string sSerialNO);

    }
}
