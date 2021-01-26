/**  版本信息模板在安装目录下，可自行修改。
* P_Cost_Item.cs
*
* 功 能： N/A
* 类 名： P_Cost_Item
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2021-01-26 14:26:16   N/A    初版
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
	/// P_Cost_Item:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class P_Cost_Item
	{
		public P_Cost_Item()
		{}
		#region Model
		private int _item_id;
		private string _item_name;
		private decimal? _item_amount;
		private string _item_remark;
		/// <summary>
		/// 
		/// </summary>
		public int item_id
		{
			set{ _item_id=value;}
			get{return _item_id;}
		}
		/// <summary>
		/// 消费项目名称
		/// </summary>
		public string item_name
		{
			set{ _item_name=value;}
			get{return _item_name;}
		}
		/// <summary>
		/// 消费金额
		/// </summary>
		public decimal? item_amount
		{
			set{ _item_amount=value;}
			get{return _item_amount;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string item_remark
		{
			set{ _item_remark=value;}
			get{return _item_remark;}
		}
		#endregion Model

	}
}

