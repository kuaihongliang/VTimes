/**  版本信息模板在安装目录下，可自行修改。
* S_Student_Info.cs
*
* 功 能： N/A
* 类 名： S_Student_Info
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2021-01-21 15:46:54   N/A    初版
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
using Maticsoft.DBUtility;//Please add references
namespace DTcms.DAL
{
	/// <summary>
	/// 数据访问类:S_Student_Info
	/// </summary>
	public partial class S_Student_Info
	{
		public S_Student_Info()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("st_id", "S_Student_Info"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int st_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from S_Student_Info");
			strSql.Append(" where st_id=@st_id");
			SqlParameter[] parameters = {
					new SqlParameter("@st_id", SqlDbType.Int,4)
			};
			parameters[0].Value = st_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(DTcms.Model.S_Student_Info model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into S_Student_Info(");
			strSql.Append("st_name,st_telphone,st_education,st_sex,st_nation,st_native,st_age,st_long,st_weight,st_class,st_disease,st_school,st_idcard,st_ballage,st_introducer,st_remark,FK_class_level,st_status,create_time,account_amount)");
			strSql.Append(" values (");
			strSql.Append("@st_name,@st_telphone,@st_education,@st_sex,@st_nation,@st_native,@st_age,@st_long,@st_weight,@st_class,@st_disease,@st_school,@st_idcard,@st_ballage,@st_introducer,@st_remark,@FK_class_level,@st_status,@create_time,@account_amount)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@st_name", SqlDbType.NVarChar,50),
					new SqlParameter("@st_telphone", SqlDbType.NVarChar,50),
					new SqlParameter("@st_education", SqlDbType.NVarChar,50),
					new SqlParameter("@st_sex", SqlDbType.NVarChar,50),
					new SqlParameter("@st_nation", SqlDbType.NVarChar,50),
					new SqlParameter("@st_native", SqlDbType.NVarChar,50),
					new SqlParameter("@st_age", SqlDbType.NVarChar,50),
					new SqlParameter("@st_long", SqlDbType.NVarChar,50),
					new SqlParameter("@st_weight", SqlDbType.NVarChar,50),
					new SqlParameter("@st_class", SqlDbType.NVarChar,50),
					new SqlParameter("@st_disease", SqlDbType.NVarChar,50),
					new SqlParameter("@st_school", SqlDbType.NVarChar,50),
					new SqlParameter("@st_idcard", SqlDbType.NVarChar,50),
					new SqlParameter("@st_ballage", SqlDbType.NVarChar,50),
					new SqlParameter("@st_introducer", SqlDbType.NVarChar,50),
					new SqlParameter("@st_remark", SqlDbType.NVarChar,50),
					new SqlParameter("@FK_class_level", SqlDbType.Int,4),
					new SqlParameter("@st_status", SqlDbType.Int,4),
					new SqlParameter("@create_time", SqlDbType.DateTime),
					new SqlParameter("@account_amount", SqlDbType.Int,4)};
			parameters[0].Value = model.st_name;
			parameters[1].Value = model.st_telphone;
			parameters[2].Value = model.st_education;
			parameters[3].Value = model.st_sex;
			parameters[4].Value = model.st_nation;
			parameters[5].Value = model.st_native;
			parameters[6].Value = model.st_age;
			parameters[7].Value = model.st_long;
			parameters[8].Value = model.st_weight;
			parameters[9].Value = model.st_class;
			parameters[10].Value = model.st_disease;
			parameters[11].Value = model.st_school;
			parameters[12].Value = model.st_idcard;
			parameters[13].Value = model.st_ballage;
			parameters[14].Value = model.st_introducer;
			parameters[15].Value = model.st_remark;
			parameters[16].Value = model.FK_class_level;
			parameters[17].Value = model.st_status;
			parameters[18].Value = model.create_time;
			parameters[19].Value = model.account_amount;

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
		public bool Update(DTcms.Model.S_Student_Info model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update S_Student_Info set ");
			strSql.Append("st_name=@st_name,");
			strSql.Append("st_telphone=@st_telphone,");
			strSql.Append("st_education=@st_education,");
			strSql.Append("st_sex=@st_sex,");
			strSql.Append("st_nation=@st_nation,");
			strSql.Append("st_native=@st_native,");
			strSql.Append("st_age=@st_age,");
			strSql.Append("st_long=@st_long,");
			strSql.Append("st_weight=@st_weight,");
			strSql.Append("st_class=@st_class,");
			strSql.Append("st_disease=@st_disease,");
			strSql.Append("st_school=@st_school,");
			strSql.Append("st_idcard=@st_idcard,");
			strSql.Append("st_ballage=@st_ballage,");
			strSql.Append("st_introducer=@st_introducer,");
			strSql.Append("st_remark=@st_remark,");
			strSql.Append("FK_class_level=@FK_class_level,");
			strSql.Append("st_status=@st_status,");
			strSql.Append("create_time=@create_time,");
			strSql.Append("account_amount=@account_amount");
			strSql.Append(" where st_id=@st_id");
			SqlParameter[] parameters = {
					new SqlParameter("@st_name", SqlDbType.NVarChar,50),
					new SqlParameter("@st_telphone", SqlDbType.NVarChar,50),
					new SqlParameter("@st_education", SqlDbType.NVarChar,50),
					new SqlParameter("@st_sex", SqlDbType.NVarChar,50),
					new SqlParameter("@st_nation", SqlDbType.NVarChar,50),
					new SqlParameter("@st_native", SqlDbType.NVarChar,50),
					new SqlParameter("@st_age", SqlDbType.NVarChar,50),
					new SqlParameter("@st_long", SqlDbType.NVarChar,50),
					new SqlParameter("@st_weight", SqlDbType.NVarChar,50),
					new SqlParameter("@st_class", SqlDbType.NVarChar,50),
					new SqlParameter("@st_disease", SqlDbType.NVarChar,50),
					new SqlParameter("@st_school", SqlDbType.NVarChar,50),
					new SqlParameter("@st_idcard", SqlDbType.NVarChar,50),
					new SqlParameter("@st_ballage", SqlDbType.NVarChar,50),
					new SqlParameter("@st_introducer", SqlDbType.NVarChar,50),
					new SqlParameter("@st_remark", SqlDbType.NVarChar,50),
					new SqlParameter("@FK_class_level", SqlDbType.Int,4),
					new SqlParameter("@st_status", SqlDbType.Int,4),
					new SqlParameter("@create_time", SqlDbType.DateTime),
					new SqlParameter("@account_amount", SqlDbType.Int,4),
					new SqlParameter("@st_id", SqlDbType.Int,4)};
			parameters[0].Value = model.st_name;
			parameters[1].Value = model.st_telphone;
			parameters[2].Value = model.st_education;
			parameters[3].Value = model.st_sex;
			parameters[4].Value = model.st_nation;
			parameters[5].Value = model.st_native;
			parameters[6].Value = model.st_age;
			parameters[7].Value = model.st_long;
			parameters[8].Value = model.st_weight;
			parameters[9].Value = model.st_class;
			parameters[10].Value = model.st_disease;
			parameters[11].Value = model.st_school;
			parameters[12].Value = model.st_idcard;
			parameters[13].Value = model.st_ballage;
			parameters[14].Value = model.st_introducer;
			parameters[15].Value = model.st_remark;
			parameters[16].Value = model.FK_class_level;
			parameters[17].Value = model.st_status;
			parameters[18].Value = model.create_time;
			parameters[19].Value = model.account_amount;
			parameters[20].Value = model.st_id;

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
		public bool Delete(int st_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from S_Student_Info ");
			strSql.Append(" where st_id=@st_id");
			SqlParameter[] parameters = {
					new SqlParameter("@st_id", SqlDbType.Int,4)
			};
			parameters[0].Value = st_id;

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
		public bool DeleteList(string st_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from S_Student_Info ");
			strSql.Append(" where st_id in ("+st_idlist + ")  ");
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
		public DTcms.Model.S_Student_Info GetModel(int st_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 st_id,st_name,st_telphone,st_education,st_sex,st_nation,st_native,st_age,st_long,st_weight,st_class,st_disease,st_school,st_idcard,st_ballage,st_introducer,st_remark,FK_class_level,st_status,create_time,account_amount from S_Student_Info ");
			strSql.Append(" where st_id=@st_id");
			SqlParameter[] parameters = {
					new SqlParameter("@st_id", SqlDbType.Int,4)
			};
			parameters[0].Value = st_id;

			DTcms.Model.S_Student_Info model=new DTcms.Model.S_Student_Info();
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
		public DTcms.Model.S_Student_Info DataRowToModel(DataRow row)
		{
			DTcms.Model.S_Student_Info model=new DTcms.Model.S_Student_Info();
			if (row != null)
			{
				if(row["st_id"]!=null && row["st_id"].ToString()!="")
				{
					model.st_id=int.Parse(row["st_id"].ToString());
				}
				if(row["st_name"]!=null)
				{
					model.st_name=row["st_name"].ToString();
				}
				if(row["st_telphone"]!=null)
				{
					model.st_telphone=row["st_telphone"].ToString();
				}
				if(row["st_education"]!=null)
				{
					model.st_education=row["st_education"].ToString();
				}
				if(row["st_sex"]!=null)
				{
					model.st_sex=row["st_sex"].ToString();
				}
				if(row["st_nation"]!=null)
				{
					model.st_nation=row["st_nation"].ToString();
				}
				if(row["st_native"]!=null)
				{
					model.st_native=row["st_native"].ToString();
				}
				if(row["st_age"]!=null)
				{
					model.st_age=row["st_age"].ToString();
				}
				if(row["st_long"]!=null)
				{
					model.st_long=row["st_long"].ToString();
				}
				if(row["st_weight"]!=null)
				{
					model.st_weight=row["st_weight"].ToString();
				}
				if(row["st_class"]!=null)
				{
					model.st_class=row["st_class"].ToString();
				}
				if(row["st_disease"]!=null)
				{
					model.st_disease=row["st_disease"].ToString();
				}
				if(row["st_school"]!=null)
				{
					model.st_school=row["st_school"].ToString();
				}
				if(row["st_idcard"]!=null)
				{
					model.st_idcard=row["st_idcard"].ToString();
				}
				if(row["st_ballage"]!=null)
				{
					model.st_ballage=row["st_ballage"].ToString();
				}
				if(row["st_introducer"]!=null)
				{
					model.st_introducer=row["st_introducer"].ToString();
				}
				if(row["st_remark"]!=null)
				{
					model.st_remark=row["st_remark"].ToString();
				}
				if(row["FK_class_level"]!=null && row["FK_class_level"].ToString()!="")
				{
					model.FK_class_level=int.Parse(row["FK_class_level"].ToString());
				}
				if(row["st_status"]!=null && row["st_status"].ToString()!="")
				{
					model.st_status=int.Parse(row["st_status"].ToString());
				}
				if(row["create_time"]!=null && row["create_time"].ToString()!="")
				{
					model.create_time=DateTime.Parse(row["create_time"].ToString());
				}
				if(row["account_amount"]!=null && row["account_amount"].ToString()!="")
				{
					model.account_amount=int.Parse(row["account_amount"].ToString());
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
			strSql.Append("select st_id,st_name,st_telphone,st_education,st_sex,st_nation,st_native,st_age,st_long,st_weight,st_class,st_disease,st_school,st_idcard,st_ballage,st_introducer,st_remark,FK_class_level,st_status,create_time,account_amount ");
			strSql.Append(" FROM S_Student_Info ");
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
			strSql.Append(" st_id,st_name,st_telphone,st_education,st_sex,st_nation,st_native,st_age,st_long,st_weight,st_class,st_disease,st_school,st_idcard,st_ballage,st_introducer,st_remark,FK_class_level,st_status,create_time,account_amount ");
			strSql.Append(" FROM S_Student_Info ");
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
			strSql.Append("select count(1) FROM S_Student_Info ");
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
				strSql.Append("order by T.st_id desc");
			}
			strSql.Append(")AS Row, T.*  from S_Student_Info T ");
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
			parameters[0].Value = "S_Student_Info";
			parameters[1].Value = "st_id";
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

