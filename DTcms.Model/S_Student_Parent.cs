/**  版本信息模板在安装目录下，可自行修改。
* S_Student_Parent.cs
*
* 功 能： N/A
* 类 名： S_Student_Parent
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2021-01-21 15:46:55   N/A    初版
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
	/// S_Student_Parent:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class S_Student_Parent
	{
		public S_Student_Parent()
		{}
		#region Model
		private int _parent_id;
		private int _fk_student;
		private string _parent_name;
		private string _parent_relationship;
		private string _parent_workunit;
		private string _parent_post;
		private string _parent_tel;
		/// <summary>
		/// 
		/// </summary>
		public int parent_id
		{
			set{ _parent_id=value;}
			get{return _parent_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int FK_student
		{
			set{ _fk_student=value;}
			get{return _fk_student;}
		}
		/// <summary>
		/// 监护人姓名
		/// </summary>
		public string parent_name
		{
			set{ _parent_name=value;}
			get{return _parent_name;}
		}
		/// <summary>
		/// 监护人与学生关系
		/// </summary>
		public string parent_relationship
		{
			set{ _parent_relationship=value;}
			get{return _parent_relationship;}
		}
		/// <summary>
		/// 监护人工作单位
		/// </summary>
		public string parent_workunit
		{
			set{ _parent_workunit=value;}
			get{return _parent_workunit;}
		}
		/// <summary>
		/// 工作职位
		/// </summary>
		public string parent_post
		{
			set{ _parent_post=value;}
			get{return _parent_post;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string parent_tel
		{
			set{ _parent_tel=value;}
			get{return _parent_tel;}
		}
		#endregion Model

	}
}

