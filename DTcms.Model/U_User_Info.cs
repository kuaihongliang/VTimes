/**  版本信息模板在安装目录下，可自行修改。
* U_User_Info.cs
*
* 功 能： N/A
* 类 名： U_User_Info
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
	/// U_User_Info:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class U_User_Info
	{
		public U_User_Info()
		{}
		#region Model
		private int _user_id;
		private decimal? _account_amount;
		private string _user_name;
		private string _user_cardnum;
		private string _user_sex;
		private string _user_telphone;
		private int? _user_status;
		private string _user_remark;
		private DateTime? _create_time;
		private DateTime? _last_pay_time;
		private DateTime? _last_rechage_time;
		/// <summary>
		/// 
		/// </summary>
		public int user_id
		{
			set{ _user_id=value;}
			get{return _user_id;}
		}
		/// <summary>
		/// 账户余额
		/// </summary>
		public decimal? account_amount
		{
			set{ _account_amount=value;}
			get{return _account_amount;}
		}
		/// <summary>
		/// 用户姓名
		/// </summary>
		public string user_name
		{
			set{ _user_name=value;}
			get{return _user_name;}
		}
		/// <summary>
		/// 用户卡号
		/// </summary>
		public string user_cardnum
		{
			set{ _user_cardnum=value;}
			get{return _user_cardnum;}
		}
		/// <summary>
		/// 性别
		/// </summary>
		public string user_sex
		{
			set{ _user_sex=value;}
			get{return _user_sex;}
		}
		/// <summary>
		/// 联系电话
		/// </summary>
		public string user_telphone
		{
			set{ _user_telphone=value;}
			get{return _user_telphone;}
		}
		/// <summary>
		/// 用户状态
		/// </summary>
		public int? user_status
		{
			set{ _user_status=value;}
			get{return _user_status;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string user_remark
		{
			set{ _user_remark=value;}
			get{return _user_remark;}
		}
		/// <summary>
		/// 创建日期
		/// </summary>
		public DateTime? create_time
		{
			set{ _create_time=value;}
			get{return _create_time;}
		}
		/// <summary>
		/// 最近一次消费时间
		/// </summary>
		public DateTime? last_pay_time
		{
			set{ _last_pay_time=value;}
			get{return _last_pay_time;}
		}
		/// <summary>
		/// 最近一次充值时间
		/// </summary>
		public DateTime? last_rechage_time
		{
			set{ _last_rechage_time=value;}
			get{return _last_rechage_time;}
		}
		#endregion Model

	}
}

