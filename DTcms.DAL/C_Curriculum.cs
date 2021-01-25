using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTcms.DBUtility;
using DTcms.Common;
namespace DTcms.DAL
{
    /// <summary>
    /// 数据访问类:C_Curriculum
    /// </summary>
    public partial class C_Curriculum
    {
        public C_Curriculum()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_Curriculum");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)
            };
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.C_Curriculum model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into C_Curriculum(");
            strSql.Append("CurriculumName,CurriculumRemark,CurriculumDate,TeacherID,Teacher,State)");
            strSql.Append(" values (");
            strSql.Append("@CurriculumName,@CurriculumRemark,@CurriculumDate,@TeacherID,@Teacher,@State)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@CurriculumName", SqlDbType.NVarChar,50),
                    new SqlParameter("@CurriculumRemark", SqlDbType.NVarChar,500),
                    new SqlParameter("@CurriculumDate", SqlDbType.DateTime),
                    new SqlParameter("@TeacherID", SqlDbType.Int,4),
                    new SqlParameter("@Teacher", SqlDbType.NVarChar,50),
                    new SqlParameter("@State", SqlDbType.Int,4)};
            parameters[0].Value = model.CurriculumName;
            parameters[1].Value = model.CurriculumRemark;
            parameters[2].Value = model.CurriculumDate;
            parameters[3].Value = model.TeacherID;
            parameters[4].Value = model.Teacher;
            parameters[5].Value = model.State;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        public bool Update(Model.C_Curriculum model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Curriculum set ");
            strSql.Append("CurriculumName=@CurriculumName,");
            strSql.Append("CurriculumRemark=@CurriculumRemark,");
            strSql.Append("CurriculumDate=@CurriculumDate,");
            strSql.Append("TeacherID=@TeacherID,");
            strSql.Append("Teacher=@Teacher,");
            strSql.Append("State=@State");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@CurriculumName", SqlDbType.NVarChar,50),
                    new SqlParameter("@CurriculumRemark", SqlDbType.NVarChar,500),
                    new SqlParameter("@CurriculumDate", SqlDbType.DateTime),
                    new SqlParameter("@TeacherID", SqlDbType.Int,4),
                    new SqlParameter("@Teacher", SqlDbType.NVarChar,50),
                    new SqlParameter("@State", SqlDbType.Int,4),
                    new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.CurriculumName;
            parameters[1].Value = model.CurriculumRemark;
            parameters[2].Value = model.CurriculumDate;
            parameters[3].Value = model.TeacherID;
            parameters[4].Value = model.Teacher;
            parameters[5].Value = model.State;
            parameters[6].Value = model.ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from C_Curriculum ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)
            };
            parameters[0].Value = ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from C_Curriculum ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public Model.C_Curriculum GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,CurriculumName,CurriculumRemark,CurriculumDate,TeacherID,Teacher,State from C_Curriculum ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)
            };
            parameters[0].Value = ID;

            Model.C_Curriculum model = new Model.C_Curriculum();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
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
        public Model.C_Curriculum DataRowToModel(DataRow row)
        {
            Model.C_Curriculum model = new Model.C_Curriculum();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["CurriculumName"] != null)
                {
                    model.CurriculumName = row["CurriculumName"].ToString();
                }
                if (row["CurriculumRemark"] != null)
                {
                    model.CurriculumRemark = row["CurriculumRemark"].ToString();
                }
                if (row["CurriculumDate"] != null && row["CurriculumDate"].ToString() != "")
                {
                    model.CurriculumDate = DateTime.Parse(row["CurriculumDate"].ToString());
                }
                if (row["TeacherID"] != null && row["TeacherID"].ToString() != "")
                {
                    model.TeacherID = int.Parse(row["TeacherID"].ToString());
                }
                if (row["Teacher"] != null)
                {
                    model.Teacher = row["Teacher"].ToString();
                }
                if (row["State"] != null && row["State"].ToString() != "")
                {
                    model.State = int.Parse(row["State"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,CurriculumName,CurriculumRemark,CurriculumDate,TeacherID,Teacher,State ");
            strSql.Append(" FROM C_Curriculum ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ID,CurriculumName,CurriculumRemark,CurriculumDate,TeacherID,Teacher,State ");
            strSql.Append(" FROM C_Curriculum ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM C_Curriculum ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from C_Curriculum T ");
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
			parameters[0].Value = "C_Curriculum";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 按年、月获取数据列表
        /// </summary>
        /// <param name="Year"></param>
        /// <param name="Month"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public List<int> GetList(int Year, int Month, out List<string> title)
        {
            StringBuilder where = new StringBuilder();
            where.Append(" DATEPART(year,CurriculumDate)=" + Year);
            where.Append(" AND DATEPART(month,CurriculumDate)=" + Month);
            int count = GetRecordCount(where.ToString());
            if (count == 0) count = 1;
            List<int> intArray = new List<int>(new int[count]); //通过数据库记录动态赋值即下面的i值
            title = new List<string>(new string[count]);
            //从数据库里选取符合要求的记录，将日期存入数组(即符合所选的当前年当前月所有的会议记录) 
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT * ");
            strSql.Append(" FROM C_Curriculum ");
            strSql.Append(" WHERE DATEPART(year,CurriculumDate)=" + Year);
            strSql.Append(" AND DATEPART(month,CurriculumDate)=" + Month);

            string planName = string.Empty;
            try
            {
                DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];
                for(int i=0;i< dt.Rows.Count; i++)
                {
                    planName = dt.Rows[i]["CurriculumName"].ToString();
                    DateTime sdate = DateTime.Parse(dt.Rows[i]["CurriculumDate"].ToString());
                    intArray[i] = sdate.Day;
                    title[i] = planName;
                }
                //while (dr.Read())
                //{

                //    DateTime sdate = DateTime.Parse(dr["START_DATE"].ToString());
                //    DateTime edate = DateTime.Parse(dr["END_DATE"].ToString());
                //    planName = dr["PLAN_TITLE"].ToString();

                //    if (sdate == edate) //如果该会议安排没有跨天数
                //    {
                //        intArray[i] = sdate.Day;
                //        title[i] = planName;
                //        i++;
                //    }
                //    else if (sdate < edate) //跨天数(仅当前月内)，如11日，12日...都安排该日程，则在日历控件呈现时12日，12日...都会显示改会议日程安排
                //    {
                //        for (int j = 0; j <= edate.Day - sdate.Day; j++)
                //        {
                //            intArray[i] = sdate.Day + j;
                //            title[i] = planName;
                //            i++;
                //        }
                //    }
                //}

                return intArray;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            
        }
        /// <summary>
        /// 按年、月获取数据列表
        /// </summary>
        /// <param name="Year"></param>
        /// <param name="Month"></param>
        /// <returns></returns>
        public DataTable GetList(int Year, int Month)
        {
            //从数据库里选取符合要求的记录，将日期存入数组(即符合所选的当前年当前月所有的会议记录) 
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT * ");
            strSql.Append(" FROM C_Curriculum ");
            strSql.Append(" WHERE DATEPART(year,CurriculumDate)=" + Year);
            strSql.Append(" AND DATEPART(month,CurriculumDate)=" + Month);
            try
            {
                DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];
                return dt;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// 按年、月、openid获取数据列表
        /// </summary>
        /// <param name="Year"></param>
        /// <param name="Month"></param>
        /// <param name="openid"></param>
        /// <returns></returns>
        public DataTable GetList(int Year, int Month,string openid)
        {
            StringBuilder where = new StringBuilder();
            where.Append(" student_openid='" + openid + "'");
            S_Student_Info student = new S_Student_Info();
            DataTable stdt = student.GetList(where.ToString()).Tables[0];

            //从数据库里选取符合要求的记录，将日期存入数组(即符合所选的当前年当前月所有的会议记录) 
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT * ");
            strSql.Append(" FROM C_Curriculum ");
            strSql.Append(" WHERE DATEPART(year,CurriculumDate)=" + Year);
            strSql.Append(" AND DATEPART(month,CurriculumDate)=" + Month);
            if (stdt.Rows.Count == 0)
            {
                strSql.Append(" AND 1=2");
            }
            else
            {
                strSql.Append(" AND TeacherID="+ stdt.Rows[0]["FK_belong_teacher"].ToString());
            }
            try
            {
                DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];
                return dt;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }
        #endregion  ExtensionMethod
    }
}
