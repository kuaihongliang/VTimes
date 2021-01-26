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
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;//Please add references
namespace DTcms.DAL
{
	/// <summary>
	/// 数据访问类:P_Cost_Item
	/// </summary>
	public partial class P_Cost_Item
	{
		public P_Cost_Item()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("item_id", "P_Cost_Item"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int item_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from P_Cost_Item");
			strSql.Append(" where item_id=@item_id");
			SqlParameter[] parameters = {
					new SqlParameter("@item_id", SqlDbType.Int,4)
			};
			parameters[0].Value = item_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(DTcms.Model.P_Cost_Item model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into P_Cost_Item(");
			strSql.Append("item_name,item_amount,item_remark)");
			strSql.Append(" values (");
			strSql.Append("@item_name,@item_amount,@item_remark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@item_name", SqlDbType.NVarChar,50),
					new SqlParameter("@item_amount", SqlDbType.Decimal,9),
					new SqlParameter("@item_remark", SqlDbType.NVarChar,100)};
			parameters[0].Value = model.item_name;
			parameters[1].Value = model.item_amount;
			parameters[2].Value = model.item_remark;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(DTcms.Model.P_Cost_Item model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update P_Cost_Item set ");
			strSql.Append("item_name=@item_name,");
			strSql.Append("item_amount=@item_amount,");
			strSql.Append("item_remark=@item_remark");
			strSql.Append(" where item_id=@item_id");
			SqlParameter[] parameters = {
					new SqlParameter("@item_name", SqlDbType.NVarChar,50),
					new SqlParameter("@item_amount", SqlDbType.Decimal,9),
					new SqlParameter("@item_remark", SqlDbType.NVarChar,100),
					new SqlParameter("@item_id", SqlDbType.Int,4)};
			parameters[0].Value = model.item_name;
			parameters[1].Value = model.item_amount;
			parameters[2].Value = model.item_remark;
			parameters[3].Value = model.item_id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int item_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from P_Cost_Item ");
			strSql.Append(" where item_id=@item_id");
			SqlParameter[] parameters = {
					new SqlParameter("@item_id", SqlDbType.Int,4)
			};
			parameters[0].Value = item_id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string item_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from P_Cost_Item ");
			strSql.Append(" where item_id in ("+item_idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DTcms.Model.P_Cost_Item GetModel(int item_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 item_id,item_name,item_amount,item_remark from P_Cost_Item ");
			strSql.Append(" where item_id=@item_id");
			SqlParameter[] parameters = {
					new SqlParameter("@item_id", SqlDbType.Int,4)
			};
			parameters[0].Value = item_id;

			DTcms.Model.P_Cost_Item model=new DTcms.Model.P_Cost_Item();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DTcms.Model.P_Cost_Item DataRowToModel(DataRow row)
		{
			DTcms.Model.P_Cost_Item model=new DTcms.Model.P_Cost_Item();
			if (row != null)
			{
				if(row["item_id"]!=null && row["item_id"].ToString()!="")
				{
					model.item_id=int.Parse(row["item_id"].ToString());
				}
				if(row["item_name"]!=null)
				{
					model.item_name=row["item_name"].ToString();
				}
				if(row["item_amount"]!=null && row["item_amount"].ToString()!="")
				{
					model.item_amount=decimal.Parse(row["item_amount"].ToString());
				}
				if(row["item_remark"]!=null)
				{
					model.item_remark=row["item_remark"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select item_id,item_name,item_amount,item_remark ");
			strSql.Append(" FROM P_Cost_Item ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" item_id,item_name,item_amount,item_remark ");
			strSql.Append(" FROM P_Cost_Item ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM P_Cost_Item ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.item_id desc");
			}
			strSql.Append(")AS Row, T.*  from P_Cost_Item T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "P_Cost_Item";
			parameters[1].Value = "item_id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

