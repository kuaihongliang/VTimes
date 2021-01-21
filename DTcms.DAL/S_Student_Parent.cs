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
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;//Please add references
namespace DTcms.DAL
{
	/// <summary>
	/// 数据访问类:S_Student_Parent
	/// </summary>
	public partial class S_Student_Parent
	{
		public S_Student_Parent()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("parent_id", "S_Student_Parent"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int parent_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from S_Student_Parent");
			strSql.Append(" where parent_id=@parent_id");
			SqlParameter[] parameters = {
					new SqlParameter("@parent_id", SqlDbType.Int,4)
			};
			parameters[0].Value = parent_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(DTcms.Model.S_Student_Parent model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into S_Student_Parent(");
			strSql.Append("FK_student,parent_name,parent_relationship,parent_workunit,parent_post,parent_tel)");
			strSql.Append(" values (");
			strSql.Append("@FK_student,@parent_name,@parent_relationship,@parent_workunit,@parent_post,@parent_tel)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@FK_student", SqlDbType.Int,4),
					new SqlParameter("@parent_name", SqlDbType.NVarChar,50),
					new SqlParameter("@parent_relationship", SqlDbType.NVarChar,50),
					new SqlParameter("@parent_workunit", SqlDbType.NVarChar,50),
					new SqlParameter("@parent_post", SqlDbType.NVarChar,50),
					new SqlParameter("@parent_tel", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.FK_student;
			parameters[1].Value = model.parent_name;
			parameters[2].Value = model.parent_relationship;
			parameters[3].Value = model.parent_workunit;
			parameters[4].Value = model.parent_post;
			parameters[5].Value = model.parent_tel;

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
		public bool Update(DTcms.Model.S_Student_Parent model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update S_Student_Parent set ");
			strSql.Append("FK_student=@FK_student,");
			strSql.Append("parent_name=@parent_name,");
			strSql.Append("parent_relationship=@parent_relationship,");
			strSql.Append("parent_workunit=@parent_workunit,");
			strSql.Append("parent_post=@parent_post,");
			strSql.Append("parent_tel=@parent_tel");
			strSql.Append(" where parent_id=@parent_id");
			SqlParameter[] parameters = {
					new SqlParameter("@FK_student", SqlDbType.Int,4),
					new SqlParameter("@parent_name", SqlDbType.NVarChar,50),
					new SqlParameter("@parent_relationship", SqlDbType.NVarChar,50),
					new SqlParameter("@parent_workunit", SqlDbType.NVarChar,50),
					new SqlParameter("@parent_post", SqlDbType.NVarChar,50),
					new SqlParameter("@parent_tel", SqlDbType.NVarChar,50),
					new SqlParameter("@parent_id", SqlDbType.Int,4)};
			parameters[0].Value = model.FK_student;
			parameters[1].Value = model.parent_name;
			parameters[2].Value = model.parent_relationship;
			parameters[3].Value = model.parent_workunit;
			parameters[4].Value = model.parent_post;
			parameters[5].Value = model.parent_tel;
			parameters[6].Value = model.parent_id;

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
		public bool Delete(int parent_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from S_Student_Parent ");
			strSql.Append(" where parent_id=@parent_id");
			SqlParameter[] parameters = {
					new SqlParameter("@parent_id", SqlDbType.Int,4)
			};
			parameters[0].Value = parent_id;

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
		public bool DeleteList(string parent_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from S_Student_Parent ");
			strSql.Append(" where parent_id in ("+parent_idlist + ")  ");
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
		public DTcms.Model.S_Student_Parent GetModel(int parent_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 parent_id,FK_student,parent_name,parent_relationship,parent_workunit,parent_post,parent_tel from S_Student_Parent ");
			strSql.Append(" where parent_id=@parent_id");
			SqlParameter[] parameters = {
					new SqlParameter("@parent_id", SqlDbType.Int,4)
			};
			parameters[0].Value = parent_id;

			DTcms.Model.S_Student_Parent model=new DTcms.Model.S_Student_Parent();
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
		public DTcms.Model.S_Student_Parent DataRowToModel(DataRow row)
		{
			DTcms.Model.S_Student_Parent model=new DTcms.Model.S_Student_Parent();
			if (row != null)
			{
				if(row["parent_id"]!=null && row["parent_id"].ToString()!="")
				{
					model.parent_id=int.Parse(row["parent_id"].ToString());
				}
				if(row["FK_student"]!=null && row["FK_student"].ToString()!="")
				{
					model.FK_student=int.Parse(row["FK_student"].ToString());
				}
				if(row["parent_name"]!=null)
				{
					model.parent_name=row["parent_name"].ToString();
				}
				if(row["parent_relationship"]!=null)
				{
					model.parent_relationship=row["parent_relationship"].ToString();
				}
				if(row["parent_workunit"]!=null)
				{
					model.parent_workunit=row["parent_workunit"].ToString();
				}
				if(row["parent_post"]!=null)
				{
					model.parent_post=row["parent_post"].ToString();
				}
				if(row["parent_tel"]!=null)
				{
					model.parent_tel=row["parent_tel"].ToString();
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
			strSql.Append("select parent_id,FK_student,parent_name,parent_relationship,parent_workunit,parent_post,parent_tel ");
			strSql.Append(" FROM S_Student_Parent ");
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
			strSql.Append(" parent_id,FK_student,parent_name,parent_relationship,parent_workunit,parent_post,parent_tel ");
			strSql.Append(" FROM S_Student_Parent ");
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
			strSql.Append("select count(1) FROM S_Student_Parent ");
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
				strSql.Append("order by T.parent_id desc");
			}
			strSql.Append(")AS Row, T.*  from S_Student_Parent T ");
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
			parameters[0].Value = "S_Student_Parent";
			parameters[1].Value = "parent_id";
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

