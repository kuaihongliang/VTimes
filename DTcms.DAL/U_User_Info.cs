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
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;//Please add references
namespace DTcms.DAL
{
	/// <summary>
	/// 数据访问类:U_User_Info
	/// </summary>
	public partial class U_User_Info
	{
		public U_User_Info()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("user_id", "U_User_Info"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int user_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from U_User_Info");
			strSql.Append(" where user_id=@user_id");
			SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.Int,4)
			};
			parameters[0].Value = user_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(DTcms.Model.U_User_Info model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into U_User_Info(");
			strSql.Append("account_amount,user_name,user_cardnum,user_sex,user_telphone,user_status,user_remark,create_time,last_pay_time,last_rechage_time)");
			strSql.Append(" values (");
			strSql.Append("@account_amount,@user_name,@user_cardnum,@user_sex,@user_telphone,@user_status,@user_remark,@create_time,@last_pay_time,@last_rechage_time)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@account_amount", SqlDbType.Decimal,9),
					new SqlParameter("@user_name", SqlDbType.NVarChar,50),
					new SqlParameter("@user_cardnum", SqlDbType.NVarChar,50),
					new SqlParameter("@user_sex", SqlDbType.NVarChar,20),
					new SqlParameter("@user_telphone", SqlDbType.NVarChar,50),
					new SqlParameter("@user_status", SqlDbType.Int,4),
					new SqlParameter("@user_remark", SqlDbType.NVarChar,100),
					new SqlParameter("@create_time", SqlDbType.DateTime),
					new SqlParameter("@last_pay_time", SqlDbType.DateTime),
					new SqlParameter("@last_rechage_time", SqlDbType.DateTime)};
			parameters[0].Value = model.account_amount;
			parameters[1].Value = model.user_name;
			parameters[2].Value = model.user_cardnum;
			parameters[3].Value = model.user_sex;
			parameters[4].Value = model.user_telphone;
			parameters[5].Value = model.user_status;
			parameters[6].Value = model.user_remark;
			parameters[7].Value = model.create_time;
			parameters[8].Value = model.last_pay_time;
			parameters[9].Value = model.last_rechage_time;

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
		public bool Update(DTcms.Model.U_User_Info model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update U_User_Info set ");
			strSql.Append("account_amount=@account_amount,");
			strSql.Append("user_name=@user_name,");
			strSql.Append("user_cardnum=@user_cardnum,");
			strSql.Append("user_sex=@user_sex,");
			strSql.Append("user_telphone=@user_telphone,");
			strSql.Append("user_status=@user_status,");
			strSql.Append("user_remark=@user_remark,");
			strSql.Append("create_time=@create_time,");
			strSql.Append("last_pay_time=@last_pay_time,");
			strSql.Append("last_rechage_time=@last_rechage_time");
			strSql.Append(" where user_id=@user_id");
			SqlParameter[] parameters = {
					new SqlParameter("@account_amount", SqlDbType.Decimal,9),
					new SqlParameter("@user_name", SqlDbType.NVarChar,50),
					new SqlParameter("@user_cardnum", SqlDbType.NVarChar,50),
					new SqlParameter("@user_sex", SqlDbType.NVarChar,20),
					new SqlParameter("@user_telphone", SqlDbType.NVarChar,50),
					new SqlParameter("@user_status", SqlDbType.Int,4),
					new SqlParameter("@user_remark", SqlDbType.NVarChar,100),
					new SqlParameter("@create_time", SqlDbType.DateTime),
					new SqlParameter("@last_pay_time", SqlDbType.DateTime),
					new SqlParameter("@last_rechage_time", SqlDbType.DateTime),
					new SqlParameter("@user_id", SqlDbType.Int,4)};
			parameters[0].Value = model.account_amount;
			parameters[1].Value = model.user_name;
			parameters[2].Value = model.user_cardnum;
			parameters[3].Value = model.user_sex;
			parameters[4].Value = model.user_telphone;
			parameters[5].Value = model.user_status;
			parameters[6].Value = model.user_remark;
			parameters[7].Value = model.create_time;
			parameters[8].Value = model.last_pay_time;
			parameters[9].Value = model.last_rechage_time;
			parameters[10].Value = model.user_id;

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
		public bool Delete(int user_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from U_User_Info ");
			strSql.Append(" where user_id=@user_id");
			SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.Int,4)
			};
			parameters[0].Value = user_id;

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
		public bool DeleteList(string user_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from U_User_Info ");
			strSql.Append(" where user_id in ("+user_idlist + ")  ");
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
		public DTcms.Model.U_User_Info GetModel(int user_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 user_id,account_amount,user_name,user_cardnum,user_sex,user_telphone,user_status,user_remark,create_time,last_pay_time,last_rechage_time from U_User_Info ");
			strSql.Append(" where user_id=@user_id");
			SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.Int,4)
			};
			parameters[0].Value = user_id;

			DTcms.Model.U_User_Info model=new DTcms.Model.U_User_Info();
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
		public DTcms.Model.U_User_Info DataRowToModel(DataRow row)
		{
			DTcms.Model.U_User_Info model=new DTcms.Model.U_User_Info();
			if (row != null)
			{
				if(row["user_id"]!=null && row["user_id"].ToString()!="")
				{
					model.user_id=int.Parse(row["user_id"].ToString());
				}
				if(row["account_amount"]!=null && row["account_amount"].ToString()!="")
				{
					model.account_amount=decimal.Parse(row["account_amount"].ToString());
				}
				if(row["user_name"]!=null)
				{
					model.user_name=row["user_name"].ToString();
				}
				if(row["user_cardnum"]!=null)
				{
					model.user_cardnum=row["user_cardnum"].ToString();
				}
				if(row["user_sex"]!=null)
				{
					model.user_sex=row["user_sex"].ToString();
				}
				if(row["user_telphone"]!=null)
				{
					model.user_telphone=row["user_telphone"].ToString();
				}
				if(row["user_status"]!=null && row["user_status"].ToString()!="")
				{
					model.user_status=int.Parse(row["user_status"].ToString());
				}
				if(row["user_remark"]!=null)
				{
					model.user_remark=row["user_remark"].ToString();
				}
				if(row["create_time"]!=null && row["create_time"].ToString()!="")
				{
					model.create_time=DateTime.Parse(row["create_time"].ToString());
				}
				if(row["last_pay_time"]!=null && row["last_pay_time"].ToString()!="")
				{
					model.last_pay_time=DateTime.Parse(row["last_pay_time"].ToString());
				}
				if(row["last_rechage_time"]!=null && row["last_rechage_time"].ToString()!="")
				{
					model.last_rechage_time=DateTime.Parse(row["last_rechage_time"].ToString());
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
			strSql.Append("select user_id,account_amount,user_name,user_cardnum,user_sex,user_telphone,user_status,user_remark,create_time,last_pay_time,last_rechage_time ");
			strSql.Append(" FROM U_User_Info ");
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
			strSql.Append(" user_id,account_amount,user_name,user_cardnum,user_sex,user_telphone,user_status,user_remark,create_time,last_pay_time,last_rechage_time ");
			strSql.Append(" FROM U_User_Info ");
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
			strSql.Append("select count(1) FROM U_User_Info ");
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
				strSql.Append("order by T.user_id desc");
			}
			strSql.Append(")AS Row, T.*  from U_User_Info T ");
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
			parameters[0].Value = "U_User_Info";
			parameters[1].Value = "user_id";
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

