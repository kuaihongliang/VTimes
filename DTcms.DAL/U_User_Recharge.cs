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
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;//Please add references
namespace DTcms.DAL
{
	/// <summary>
	/// 数据访问类:U_User_Recharge
	/// </summary>
	public partial class U_User_Recharge
	{
		public U_User_Recharge()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("recharge_id", "U_User_Recharge"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int recharge_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from U_User_Recharge");
			strSql.Append(" where recharge_id=@recharge_id");
			SqlParameter[] parameters = {
					new SqlParameter("@recharge_id", SqlDbType.Int,4)
			};
			parameters[0].Value = recharge_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(DTcms.Model.U_User_Recharge model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into U_User_Recharge(");
			strSql.Append("FK_user_id,recharge_user_name,recharge_type,payment_type,recharge_amount,balance,real_amount,rechage_time,create_by,create_name,recharge_remark)");
			strSql.Append(" values (");
			strSql.Append("@FK_user_id,@recharge_user_name,@recharge_type,@payment_type,@recharge_amount,@balance,@real_amount,@rechage_time,@create_by,@create_name,@recharge_remark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@FK_user_id", SqlDbType.Int,4),
					new SqlParameter("@recharge_user_name", SqlDbType.NVarChar,50),
					new SqlParameter("@recharge_type", SqlDbType.Int,4),
					new SqlParameter("@payment_type", SqlDbType.NVarChar,50),
					new SqlParameter("@recharge_amount", SqlDbType.Decimal,9),
					new SqlParameter("@balance", SqlDbType.Decimal,9),
					new SqlParameter("@real_amount", SqlDbType.Decimal,9),
					new SqlParameter("@rechage_time", SqlDbType.DateTime),
					new SqlParameter("@create_by", SqlDbType.Int,4),
					new SqlParameter("@create_name", SqlDbType.NVarChar,50),
					new SqlParameter("@recharge_remark", SqlDbType.NVarChar,100)};
			parameters[0].Value = model.FK_user_id;
			parameters[1].Value = model.recharge_user_name;
			parameters[2].Value = model.recharge_type;
			parameters[3].Value = model.payment_type;
			parameters[4].Value = model.recharge_amount;
			parameters[5].Value = model.balance;
			parameters[6].Value = model.real_amount;
			parameters[7].Value = model.rechage_time;
			parameters[8].Value = model.create_by;
			parameters[9].Value = model.create_name;
			parameters[10].Value = model.recharge_remark;

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
		public bool Update(DTcms.Model.U_User_Recharge model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update U_User_Recharge set ");
			strSql.Append("FK_user_id=@FK_user_id,");
			strSql.Append("recharge_user_name=@recharge_user_name,");
			strSql.Append("recharge_type=@recharge_type,");
			strSql.Append("payment_type=@payment_type,");
			strSql.Append("recharge_amount=@recharge_amount,");
			strSql.Append("balance=@balance,");
			strSql.Append("real_amount=@real_amount,");
			strSql.Append("rechage_time=@rechage_time,");
			strSql.Append("create_by=@create_by,");
			strSql.Append("create_name=@create_name,");
			strSql.Append("recharge_remark=@recharge_remark");
			strSql.Append(" where recharge_id=@recharge_id");
			SqlParameter[] parameters = {
					new SqlParameter("@FK_user_id", SqlDbType.Int,4),
					new SqlParameter("@recharge_user_name", SqlDbType.NVarChar,50),
					new SqlParameter("@recharge_type", SqlDbType.Int,4),
					new SqlParameter("@payment_type", SqlDbType.NVarChar,50),
					new SqlParameter("@recharge_amount", SqlDbType.Decimal,9),
					new SqlParameter("@balance", SqlDbType.Decimal,9),
					new SqlParameter("@real_amount", SqlDbType.Decimal,9),
					new SqlParameter("@rechage_time", SqlDbType.DateTime),
					new SqlParameter("@create_by", SqlDbType.Int,4),
					new SqlParameter("@create_name", SqlDbType.NVarChar,50),
					new SqlParameter("@recharge_remark", SqlDbType.NVarChar,100),
					new SqlParameter("@recharge_id", SqlDbType.Int,4)};
			parameters[0].Value = model.FK_user_id;
			parameters[1].Value = model.recharge_user_name;
			parameters[2].Value = model.recharge_type;
			parameters[3].Value = model.payment_type;
			parameters[4].Value = model.recharge_amount;
			parameters[5].Value = model.balance;
			parameters[6].Value = model.real_amount;
			parameters[7].Value = model.rechage_time;
			parameters[8].Value = model.create_by;
			parameters[9].Value = model.create_name;
			parameters[10].Value = model.recharge_remark;
			parameters[11].Value = model.recharge_id;

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
		public bool Delete(int recharge_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from U_User_Recharge ");
			strSql.Append(" where recharge_id=@recharge_id");
			SqlParameter[] parameters = {
					new SqlParameter("@recharge_id", SqlDbType.Int,4)
			};
			parameters[0].Value = recharge_id;

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
		public bool DeleteList(string recharge_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from U_User_Recharge ");
			strSql.Append(" where recharge_id in ("+recharge_idlist + ")  ");
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
		public DTcms.Model.U_User_Recharge GetModel(int recharge_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 recharge_id,FK_user_id,recharge_user_name,recharge_type,payment_type,recharge_amount,balance,real_amount,rechage_time,create_by,create_name,recharge_remark from U_User_Recharge ");
			strSql.Append(" where recharge_id=@recharge_id");
			SqlParameter[] parameters = {
					new SqlParameter("@recharge_id", SqlDbType.Int,4)
			};
			parameters[0].Value = recharge_id;

			DTcms.Model.U_User_Recharge model=new DTcms.Model.U_User_Recharge();
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
		public DTcms.Model.U_User_Recharge DataRowToModel(DataRow row)
		{
			DTcms.Model.U_User_Recharge model=new DTcms.Model.U_User_Recharge();
			if (row != null)
			{
				if(row["recharge_id"]!=null && row["recharge_id"].ToString()!="")
				{
					model.recharge_id=int.Parse(row["recharge_id"].ToString());
				}
				if(row["FK_user_id"]!=null && row["FK_user_id"].ToString()!="")
				{
					model.FK_user_id=int.Parse(row["FK_user_id"].ToString());
				}
				if(row["recharge_user_name"]!=null)
				{
					model.recharge_user_name=row["recharge_user_name"].ToString();
				}
				if(row["recharge_type"]!=null && row["recharge_type"].ToString()!="")
				{
					model.recharge_type=int.Parse(row["recharge_type"].ToString());
				}
				if(row["payment_type"]!=null)
				{
					model.payment_type=row["payment_type"].ToString();
				}
				if(row["recharge_amount"]!=null && row["recharge_amount"].ToString()!="")
				{
					model.recharge_amount=decimal.Parse(row["recharge_amount"].ToString());
				}
				if(row["balance"]!=null && row["balance"].ToString()!="")
				{
					model.balance=decimal.Parse(row["balance"].ToString());
				}
				if(row["real_amount"]!=null && row["real_amount"].ToString()!="")
				{
					model.real_amount=decimal.Parse(row["real_amount"].ToString());
				}
				if(row["rechage_time"]!=null && row["rechage_time"].ToString()!="")
				{
					model.rechage_time=DateTime.Parse(row["rechage_time"].ToString());
				}
				if(row["create_by"]!=null && row["create_by"].ToString()!="")
				{
					model.create_by=int.Parse(row["create_by"].ToString());
				}
				if(row["create_name"]!=null)
				{
					model.create_name=row["create_name"].ToString();
				}
				if(row["recharge_remark"]!=null)
				{
					model.recharge_remark=row["recharge_remark"].ToString();
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
			strSql.Append("select recharge_id,FK_user_id,recharge_user_name,recharge_type,payment_type,recharge_amount,balance,real_amount,rechage_time,create_by,create_name,recharge_remark ");
			strSql.Append(" FROM U_User_Recharge ");
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
			strSql.Append(" recharge_id,FK_user_id,recharge_user_name,recharge_type,payment_type,recharge_amount,balance,real_amount,rechage_time,create_by,create_name,recharge_remark ");
			strSql.Append(" FROM U_User_Recharge ");
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
			strSql.Append("select count(1) FROM U_User_Recharge ");
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
				strSql.Append("order by T.recharge_id desc");
			}
			strSql.Append(")AS Row, T.*  from U_User_Recharge T ");
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
			parameters[0].Value = "U_User_Recharge";
			parameters[1].Value = "recharge_id";
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

