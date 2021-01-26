/**  版本信息模板在安装目录下，可自行修改。
* U_User_Recharge.cs
*
* 功 能： N/A
* 类 名： U_User_Recharge
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2021-01-26 14:26:17   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace DTcms.Model
{
	/// <summary>
	/// U_User_Recharge:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class U_User_Recharge
	{
		public U_User_Recharge()
		{}
		#region Model
		private int _recharge_id;
		private int _fk_user_id;
		private string _recharge_user_name;
		private int? _recharge_type;
		private string _payment_type;
		private decimal? _recharge_amount;
		private decimal? _balance;
		private decimal? _real_amount;
		private DateTime? _rechage_time;
		private int? _create_by;
		private string _create_name;
		private string _recharge_remark;
		/// <summary>
		/// 
		/// </summary>
		public int recharge_id
		{
			set{ _recharge_id=value;}
			get{return _recharge_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int FK_user_id
		{
			set{ _fk_user_id=value;}
			get{return _fk_user_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string recharge_user_name
		{
			set{ _recharge_user_name=value;}
			get{return _recharge_user_name;}
		}
		/// <summary>
		/// -1:消费 1:充值
		/// </summary>
		public int? recharge_type
		{
			set{ _recharge_type=value;}
			get{return _recharge_type;}
		}
		/// <summary>
		/// 支付方式:现金、支付宝、微信支付、刷卡、其他
		/// </summary>
		public string payment_type
		{
			set{ _payment_type=value;}
			get{return _payment_type;}
		}
		/// <summary>
		/// 充值/消费金额
		/// </summary>
		public decimal? recharge_amount
		{
			set{ _recharge_amount=value;}
			get{return _recharge_amount;}
		}
		/// <summary>
		/// 充值/消费后余额
		/// </summary>
		public decimal? balance
		{
			set{ _balance=value;}
			get{return _balance;}
		}
		/// <summary>
		/// 实际金额
		/// </summary>
		public decimal? real_amount
		{
			set{ _real_amount=value;}
			get{return _real_amount;}
		}
		/// <summary>
		/// 充值/消费时间
		/// </summary>
		public DateTime? rechage_time
		{
			set{ _rechage_time=value;}
			get{return _rechage_time;}
		}
		/// <summary>
		/// 操作人id
		/// </summary>
		public int? create_by
		{
			set{ _create_by=value;}
			get{return _create_by;}
		}
		/// <summary>
		/// 操作人姓名
		/// </summary>
		public string create_name
		{
			set{ _create_name=value;}
			get{return _create_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string recharge_remark
		{
			set{ _recharge_remark=value;}
			get{return _recharge_remark;}
		}
		#endregion Model

	}
}

