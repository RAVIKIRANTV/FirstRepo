using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebAPICrudOperation.Models
{
    public class PatientModelManager
    {
        string cns = ConfigurationManager.ConnectionStrings["scn"].ConnectionString;

        public int RegisterPatient(PateintModel pateintModel)
        {
            using (SqlConnection cn = new SqlConnection(cns))
            {
                using (SqlCommand cmd = new SqlCommand("RegisterPatient", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FirstName", pateintModel.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", pateintModel.LastName);
                    cmd.Parameters.AddWithValue("@Age", pateintModel.Age);
                    cmd.Parameters.AddWithValue("@BloodGroup", pateintModel.BloodGroup);
                    try
                    {
                        cn.Open();
                        int count = cmd.ExecuteNonQuery();
                        if (count > 0)
                        {
                            return count;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        if (cn.State == System.Data.ConnectionState.Open)
                        {
                            cn.Close();
                        }
                    }
                }
            }
            return 0;
        }

        public List<PateintModel> GetPatientDetails()
        {
            using (SqlConnection cn = new SqlConnection(cns))
            {
                using (SqlCommand cmd = new SqlCommand("GetPatients", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        cn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        List<PateintModel> selectListItems = new List<PateintModel>();
                        while (dr.Read())
                        {
                            PateintModel pateintModel = new PateintModel();
                            pateintModel.FirstName = Convert.ToString(dr["FirstName"]);
                            pateintModel.LastName = Convert.ToString(dr["LastName"]);
                            pateintModel.Age = Convert.ToInt32(dr["Age"]);
                            pateintModel.BloodGroup = Convert.ToString(dr["BloodGroup"]);
                            selectListItems.Add(pateintModel);
                        }
                        dr.Close();
                        return selectListItems;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        if (cn.State == ConnectionState.Open)
                        {
                            cn.Close();
                        }
                    }
                }
            }
        }
        public PateintModel GetPatientDetailsBasedOnPId(int patientId)
        {
            using (SqlConnection cn = new SqlConnection(cns))
            {
                using (SqlCommand cmd=new SqlCommand("GetpatientDetailsBasedOnPatientId", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pid", patientId);
                    try
                    {
                        cn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        PateintModel pateintModel = null;
                        while (dr.Read())
                        {
                            pateintModel = new PateintModel();
                            pateintModel.FirstName = Convert.ToString(dr["FirstName"]);
                            pateintModel.LastName = Convert.ToString(dr["LastName"]);
                            pateintModel.Age = Convert.ToInt32(dr["Age"]);
                            pateintModel.BloodGroup = Convert.ToString(dr["BloodGroup"]);
                        }
                        return pateintModel;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }            
        }

        public int UpdatePatient(PateintModel pateintModel,int pId)
        {
            using (SqlConnection cn = new SqlConnection(cns))
            {
                using (SqlCommand cmd = new SqlCommand("UpdatePatientDetails", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Pid", pId);
                    cmd.Parameters.AddWithValue("@FirstName", pateintModel.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", pateintModel.LastName);
                    cmd.Parameters.AddWithValue("@Age", pateintModel.Age);
                    cmd.Parameters.AddWithValue("@BloodGroup", pateintModel.BloodGroup);
                    try
                    {
                        cn.Open();
                        int count = cmd.ExecuteNonQuery();
                        if (count > 0)
                        {
                            return count;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        if (cn.State == System.Data.ConnectionState.Open)
                        {
                            cn.Close();
                        }
                    }
                }
            }
            return 0;
        }

        public int DeletePatient(PateintModel pateintModel, int pId)
        {
            using (SqlConnection cn = new SqlConnection(cns))
            {
                using (SqlCommand cmd = new SqlCommand("DeletePatient", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Pid", pId);                  
                    try
                    {
                        cn.Open();
                        int count = cmd.ExecuteNonQuery();
                        if (count > 0)
                        {
                            return count;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        if (cn.State == System.Data.ConnectionState.Open)
                        {
                            cn.Close();
                        }
                    }
                }
            }
            return 0;
        }
    }
}
