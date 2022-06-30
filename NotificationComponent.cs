using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System.Data;

namespace Inspinia_MVC5_SeedProject
{
    //#region Incident
    //public class NotificationComponent
    //{

    //    public void RegisterNotification(DateTime currentTime)
    //    {
    //        string conStr = ConfigurationManager.ConnectionStrings["AuditContext"].ConnectionString;

    //        string sqlCommand = @"SELECT [IncidentId],[IncidentCategory],[IncidentStatus] from [dbo].[Incidents] where IncidentStatus = 'Submitted' OR IncidentStatus ='Verification Pending' AND ([IncidentDateTime] >= @IncidentDateTime OR [IncidentDateTime] <= @IncidentDateTime) ";
    //        //you can notice here I have added table name like this [dbo].[Contacts] with [dbo], its mendatory when you use Sql Dependency  
    //        using (SqlConnection con = new SqlConnection(conStr))
    //        {
    //            SqlCommand cmd = new SqlCommand(sqlCommand, con);
    //            cmd.Parameters.AddWithValue("@IncidentDateTime", currentTime);
    //            if (con.State != System.Data.ConnectionState.Open)
    //            {
    //                con.Open();
    //            }

    //            SqlDependency sqlDep = new SqlDependency(cmd);
    //            sqlDep.OnChange += sqlDep_OnChange;
    //            //we must have to execute the command here  
    //            using (SqlDataReader reader = cmd.ExecuteReader())
    //            {
    //                con.Close();
    //            }
    //        }
    //    }

    //    public void sqlDep_OnChange(object sender, SqlNotificationEventArgs e)
    //    {
    //        //or you can also check => if (e.Info == SqlNotificationInfo.Insert) , if you want notification only for inserted record  
    //        if (e.Type == SqlNotificationType.Change)
    //        {
    //            SqlDependency sqlDep = sender as SqlDependency;
    //            sqlDep.OnChange -= sqlDep_OnChange;


    //            //from here we will send notification message to client  
    //            var notificationHub = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
    //            notificationHub.Clients.All.notify("added");
    //            //re-register notification  

    //            RegisterNotification(DateTime.Now);
    //        }
    //    }

    //    public List<Inspinia_MVC5_SeedProject.Models.Incident> GetData(DateTime IncidentDateTime, string No)
    //    {

    //        using (Inspinia_MVC5_SeedProject.Models.AuditContext dc = new Inspinia_MVC5_SeedProject.Models.AuditContext())
    //        {

    //            return dc.Incidents.Where(a => a.IncidentStatus == "Submitted" || a.IncidentStatus == "Verification Pending" && (a.IncidentDateTime >= IncidentDateTime || a.IncidentDateTime <= IncidentDateTime)).OrderByDescending(a => a.IncidentDateTime).ToList();

    //        }
    //    }
    //}

    //public class DelegateNotificationComponent
    //{

    //    public void RegisterNotification(DateTime currentTime)
    //    {
    //        string conStr = ConfigurationManager.ConnectionStrings["AuditContext"].ConnectionString;

    //        string sqlCommand = @"SELECT [IncidentId],[IncidentCategory],[IncidentStatus],[DelegatedTo] from [dbo].[Incidents] where IncidentStatus = 'Delegated' OR IncidentStatus = 'Re-delegated'  AND ([IncidentDateTime] >= @IncidentDateTime OR [IncidentDateTime] <= @IncidentDateTime) ";
    //        //you can notice here I have added table name like this [dbo].[Contacts] with [dbo], its mendatory when you use Sql Dependency  
    //        using (SqlConnection con = new SqlConnection(conStr))
    //        {
    //            SqlCommand cmd = new SqlCommand(sqlCommand, con);
    //            cmd.Parameters.AddWithValue("@IncidentDateTime", currentTime);
    //            if (con.State != System.Data.ConnectionState.Open)
    //            {
    //                con.Open();
    //            }

    //            SqlDependency sqlDep = new SqlDependency(cmd);
    //            sqlDep.OnChange += sqlDep_OnChange;
    //            //we must have to execute the command here  
    //            using (SqlDataReader reader = cmd.ExecuteReader())
    //            {
    //                con.Close();
    //            }
    //        }
    //    }

    //    public void sqlDep_OnChange(object sender, SqlNotificationEventArgs e)
    //    {
    //        //or you can also check => if (e.Info == SqlNotificationInfo.Insert) , if you want notification only for inserted record  
    //        if (e.Type == SqlNotificationType.Change)
    //        {
    //            SqlDependency sqlDep = sender as SqlDependency;
    //            sqlDep.OnChange -= sqlDep_OnChange;


    //            //from here we will send notification message to client  
    //            var notificationHub = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
    //            notificationHub.Clients.All.notify("added");
    //            //re-register notification  

    //            RegisterNotification(DateTime.Now);
    //        }
    //    }

    //    public List<Inspinia_MVC5_SeedProject.Models.Incident> GetData(DateTime IncidentDateTime, string Department)
    //    {
    //        using (Inspinia_MVC5_SeedProject.Models.AuditContext dc = new Inspinia_MVC5_SeedProject.Models.AuditContext())
    //        {
    //            return dc.Incidents.Where(a => a.IncidentStatus == "Delegated" || a.IncidentStatus == "Re-delegated" && (a.IncidentDateTime >= IncidentDateTime || a.IncidentDateTime <= IncidentDateTime) && a.DelegatedTo == Department).OrderByDescending(a => a.IncidentDateTime).ToList();
    //        }
    //    }
    //}
    //#endregion

    //#region OT & Anaesthesia
    //public class AdverseAanaesthesiaNotification
    //{
    //    public void RegisterNotification(DateTime currentTime)
    //    {
    //        string conStr = ConfigurationManager.ConnectionStrings["AuditContext"].ConnectionString;

    //        string sqlCommand = @"SELECT [Id],[IPNumber],[Type_of_anaesthesia] from [dbo].[Ramaiah_AdverseAnaesthesiaEvent] where  ([dt_Submitted] >= @SubmittedTime OR [dt_Submitted] <= @SubmittedTime) ";
    //        //you can notice here I have added table name like this [dbo].[Contacts] with [dbo], its mendatory when you use Sql Dependency  
    //        using (SqlConnection con = new SqlConnection(conStr))
    //        {
    //            SqlCommand cmd = new SqlCommand(sqlCommand, con);
    //            cmd.Parameters.AddWithValue("@SubmittedTime", currentTime);
    //            if (con.State != System.Data.ConnectionState.Open)
    //            {
    //                con.Open();
    //            }

    //            SqlDependency sqlDep = new SqlDependency(cmd);
    //            sqlDep.OnChange += sqlDep_OnChange;
    //            //we must have to execute the command here  
    //            using (SqlDataReader reader = cmd.ExecuteReader())
    //            {
    //                con.Close();
    //            }
    //        }
    //    }

    //    public void sqlDep_OnChange(object sender, SqlNotificationEventArgs e)
    //    {
    //        //or you can also check => if (e.Info == SqlNotificationInfo.Insert) , if you want notification only for inserted record  
    //        if (e.Type == SqlNotificationType.Change)
    //        {
    //            SqlDependency sqlDep = sender as SqlDependency;
    //            sqlDep.OnChange -= sqlDep_OnChange;


    //            //from here we will send notification message to client  
    //            var notificationHub = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
    //            notificationHub.Clients.All.notify("added");
    //            //re-register notification  

    //            RegisterNotification(DateTime.Now);
    //        }
    //    }

    //    public List<Inspinia_MVC5_SeedProject.Models.Ramaiah_AdverseAnaesthesiaEvent> GetData(DateTime SubmittedDateTime, string No)
    //    {
    //        using (Inspinia_MVC5_SeedProject.Models.AuditContext dc = new Inspinia_MVC5_SeedProject.Models.AuditContext())
    //        {
    //            List<Models.Ramaiah_AdverseAnaesthesiaEvent> items = new List<Models.Ramaiah_AdverseAnaesthesiaEvent>();
    //            string constr = ConfigurationManager.ConnectionStrings["AuditContext"].ConnectionString.ToString();
    //            string query = "select Id,IPNumber,Type_of_anaesthesia, dt_submitted  from dbo.Ramaiah_AdverseAnaesthesiaEvent where MONTH(dt_submitted) = MONTH(GetDate()) and YEAR(dt_submitted) = YEAR(GetDate()) ";
    //            SqlConnection con = new SqlConnection(constr);
    //            con.Open();
    //            SqlCommand cmd = new SqlCommand(query, con);
    //            cmd.CommandType = CommandType.Text;
    //            SqlDataReader dr = cmd.ExecuteReader();
    //            while (dr.Read())
    //            {
    //                items.Add(new Models.Ramaiah_AdverseAnaesthesiaEvent
    //                {
    //                    Id = Convert.ToInt32(dr["Id"].ToString()),


    //                    IPNumber = dr["IPNumber"].ToString(),
    //                    Type_of_anaesthesia = dr["Type_of_anaesthesia"].ToString(),
    //                    dt_submitted = Convert.ToDateTime(dr["dt_submitted"].ToString())



    //                }
    //               );
    //            }

    //            con.Close();
    //            cmd.Dispose();
    //            dr.Close();

    //            return items;




    //        }
    //    }
    //}

    //public class AnaesthesiaRelatedMortalityNotification
    //{
    //    public void RegisterNotification(DateTime currentTime)
    //    {
    //        string conStr = ConfigurationManager.ConnectionStrings["AuditContext"].ConnectionString;

    //        string sqlCommand = @"SELECT [Id],[IPNumber],[Initial_Diagnosis_and_cause_of_death] from [dbo].[Ramaiah_AnaesthesiaRelatedMortality] where  ([dt_Submitted] >= @SubmittedTime OR [dt_Submitted] <= @SubmittedTime) ";
    //        //you can notice here I have added table name like this [dbo].[Contacts] with [dbo], its mendatory when you use Sql Dependency  
    //        using (SqlConnection con = new SqlConnection(conStr))
    //        {
    //            SqlCommand cmd = new SqlCommand(sqlCommand, con);
    //            cmd.Parameters.AddWithValue("@SubmittedTime", currentTime);
    //            if (con.State != System.Data.ConnectionState.Open)
    //            {
    //                con.Open();
    //            }

    //            SqlDependency sqlDep = new SqlDependency(cmd);
    //            sqlDep.OnChange += sqlDep_OnChange;
    //            //we must have to execute the command here  
    //            using (SqlDataReader reader = cmd.ExecuteReader())
    //            {
    //                con.Close();
    //            }
    //        }
    //    }

    //    public void sqlDep_OnChange(object sender, SqlNotificationEventArgs e)
    //    {
    //        //or you can also check => if (e.Info == SqlNotificationInfo.Insert) , if you want notification only for inserted record  
    //        if (e.Type == SqlNotificationType.Change)
    //        {
    //            SqlDependency sqlDep = sender as SqlDependency;
    //            sqlDep.OnChange -= sqlDep_OnChange;


    //            //from here we will send notification message to client  
    //            var notificationHub = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
    //            notificationHub.Clients.All.notify("added");
    //            //re-register notification  

    //            RegisterNotification(DateTime.Now);
    //        }
    //    }

    //    public List<Inspinia_MVC5_SeedProject.Models.Ramaiah_AnaesthesiaRelatedMortality> GetData(DateTime SubmittedDateTime, string No)
    //    {
    //        using (Inspinia_MVC5_SeedProject.Models.AuditContext dc = new Inspinia_MVC5_SeedProject.Models.AuditContext())
    //        {
    //            List<Models.Ramaiah_AnaesthesiaRelatedMortality> items = new List<Models.Ramaiah_AnaesthesiaRelatedMortality>();
    //            string constr = ConfigurationManager.ConnectionStrings["AuditContext"].ConnectionString.ToString();
    //            string query = "select Id,IPNumber,Initial_Diagnosis_and_cause_of_death,dt_submitted  from dbo.Ramaiah_AnaesthesiaRelatedMortality where MONTH(dt_submitted) = MONTH(GetDate()) and YEAR(dt_submitted) = YEAR(GetDate()) ";
    //            SqlConnection con = new SqlConnection(constr);
    //            con.Open();
    //            SqlCommand cmd = new SqlCommand(query, con);
    //            cmd.CommandType = CommandType.Text;
    //            SqlDataReader dr = cmd.ExecuteReader();
    //            while (dr.Read())
    //            {
    //                items.Add(new Models.Ramaiah_AnaesthesiaRelatedMortality
    //                {
    //                    Id = Convert.ToInt32(dr["Id"].ToString()),


    //                    IPNumber = dr["IPNumber"].ToString(),
    //                    Type_of_anaesthesia = dr["Initial_Diagnosis_and_cause_of_death"].ToString(),
    //                    dt_submitted = Convert.ToDateTime(dr["dt_submitted"].ToString())


    //                }
    //               );
    //            }

    //            con.Close();
    //            cmd.Dispose();
    //            dr.Close();

    //            return items;




    //        }
    //    }

    //}

    //public class UnplannedReturnOTNotification
    //{
    //    public void RegisterNotification(DateTime currentTime)
    //    {
    //        string conStr = ConfigurationManager.ConnectionStrings["AuditContext"].ConnectionString;

    //        string sqlCommand = @"SELECT [Id],[IPnumber],[Reason_for_returning_to_OT] from [dbo].[Unplanned_return_to_OT] where  ([submitted_date] >= @SubmittedTime OR [submitted_date] <= @SubmittedTime) ";
    //        //you can notice here I have added table name like this [dbo].[Contacts] with [dbo], its mendatory when you use Sql Dependency  
    //        using (SqlConnection con = new SqlConnection(conStr))
    //        {
    //            SqlCommand cmd = new SqlCommand(sqlCommand, con);
    //            cmd.Parameters.AddWithValue("@SubmittedTime", currentTime);
    //            if (con.State != System.Data.ConnectionState.Open)
    //            {
    //                con.Open();
    //            }

    //            SqlDependency sqlDep = new SqlDependency(cmd);
    //            sqlDep.OnChange += sqlDep_OnChange;
    //            //we must have to execute the command here  
    //            using (SqlDataReader reader = cmd.ExecuteReader())
    //            {
    //                con.Close();
    //            }
    //        }
    //    }

    //    public void sqlDep_OnChange(object sender, SqlNotificationEventArgs e)
    //    {
    //        //or you can also check => if (e.Info == SqlNotificationInfo.Insert) , if you want notification only for inserted record  
    //        if (e.Type == SqlNotificationType.Change)
    //        {
    //            SqlDependency sqlDep = sender as SqlDependency;
    //            sqlDep.OnChange -= sqlDep_OnChange;


    //            //from here we will send notification message to client  
    //            var notificationHub = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
    //            notificationHub.Clients.All.notify("added");
    //            //re-register notification  

    //            RegisterNotification(DateTime.Now);
    //        }
    //    }

    //    public List<Inspinia_MVC5_SeedProject.Models.Unplanned_return_to_OT> GetData(DateTime SubmittedDateTime, string No)
    //    {
    //        using (Inspinia_MVC5_SeedProject.Models.AuditContext dc = new Inspinia_MVC5_SeedProject.Models.AuditContext())
    //        {
    //            List<Models.Unplanned_return_to_OT> items = new List<Models.Unplanned_return_to_OT>();
    //            string constr = ConfigurationManager.ConnectionStrings["AuditContext"].ConnectionString.ToString();
    //            string query = "select Id,IPnumber,Reason_for_returning_to_OT,submitted_date  from dbo.Unplanned_return_to_OT where MONTH(submitted_date) = MONTH(GetDate()) and YEAR(submitted_date) = YEAR(GetDate()) ";
    //            SqlConnection con = new SqlConnection(constr);
    //            con.Open();
    //            SqlCommand cmd = new SqlCommand(query, con);
    //            cmd.CommandType = CommandType.Text;
    //            SqlDataReader dr = cmd.ExecuteReader();
    //            while (dr.Read())
    //            {
    //                items.Add(new Models.Unplanned_return_to_OT
    //                {
    //                    Id = Convert.ToInt32(dr["Id"].ToString()),


    //                    IPnumber = dr["IPnumber"].ToString(),
    //                    Reason_for_returning_to_OT = dr["Reason_for_returning_to_OT"].ToString(),
    //                    submitted_date = Convert.ToDateTime(dr["submitted_date"].ToString())



    //                }
    //               );
    //            }

    //            con.Close();
    //            cmd.Dispose();
    //            dr.Close();

    //            return items;




    //        }
    //    }
    //}

    //public class UnplannedVentilationNotification
    //{
    //    public void RegisterNotification(DateTime currentTime)
    //    {
    //        string conStr = ConfigurationManager.ConnectionStrings["AuditContext"].ConnectionString;

    //        string sqlCommand = @"SELECT [Id],[IPNumber],[Reason_for_unplanned_ventilation] from [dbo].[Ramaiah_UnplannedVentilation] where  ([dt_submitted] >= @SubmittedTime OR [dt_submitted] <= @SubmittedTime) ";
    //        //you can notice here I have added table name like this [dbo].[Contacts] with [dbo], its mendatory when you use Sql Dependency  
    //        using (SqlConnection con = new SqlConnection(conStr))
    //        {
    //            SqlCommand cmd = new SqlCommand(sqlCommand, con);
    //            cmd.Parameters.AddWithValue("@SubmittedTime", currentTime);
    //            if (con.State != System.Data.ConnectionState.Open)
    //            {
    //                con.Open();
    //            }

    //            SqlDependency sqlDep = new SqlDependency(cmd);
    //            sqlDep.OnChange += sqlDep_OnChange;
    //            //we must have to execute the command here  
    //            using (SqlDataReader reader = cmd.ExecuteReader())
    //            {
    //                con.Close();
    //            }
    //        }
    //    }

    //    public void sqlDep_OnChange(object sender, SqlNotificationEventArgs e)
    //    {
    //        //or you can also check => if (e.Info == SqlNotificationInfo.Insert) , if you want notification only for inserted record  
    //        if (e.Type == SqlNotificationType.Change)
    //        {
    //            SqlDependency sqlDep = sender as SqlDependency;
    //            sqlDep.OnChange -= sqlDep_OnChange;


    //            //from here we will send notification message to client  
    //            var notificationHub = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
    //            notificationHub.Clients.All.notify("added");
    //            //re-register notification  

    //            RegisterNotification(DateTime.Now);
    //        }
    //    }

    //    public List<Inspinia_MVC5_SeedProject.Models.Ramaiah_UnplannedVentilation> GetData(DateTime SubmittedDateTime, string No)
    //    {
    //        using (Inspinia_MVC5_SeedProject.Models.AuditContext dc = new Inspinia_MVC5_SeedProject.Models.AuditContext())
    //        {
    //            List<Models.Ramaiah_UnplannedVentilation> items = new List<Models.Ramaiah_UnplannedVentilation>();
    //            string constr = ConfigurationManager.ConnectionStrings["AuditContext"].ConnectionString.ToString();
    //            string query = "select Id,IPNumber,Reason_for_unplanned_ventilation,dt_submitted  from dbo.Ramaiah_UnplannedVentilation where MONTH(dt_submitted) = MONTH(GetDate()) and YEAR(dt_submitted) = YEAR(GetDate()) ";
    //            SqlConnection con = new SqlConnection(constr);
    //            con.Open();
    //            SqlCommand cmd = new SqlCommand(query, con);
    //            cmd.CommandType = CommandType.Text;
    //            SqlDataReader dr = cmd.ExecuteReader();
    //            while (dr.Read())
    //            {
    //                items.Add(new Models.Ramaiah_UnplannedVentilation
    //                {
    //                    Id = Convert.ToInt32(dr["Id"].ToString()),


    //                    IPNumber = dr["IPNumber"].ToString(),
    //                    Reason_for_unplanned_ventilation = dr["Reason_for_unplanned_ventilation"].ToString(),
    //                    dt_submitted = Convert.ToDateTime(dr["dt_submitted"].ToString())


    //                }
    //               );
    //            }

    //            con.Close();
    //            cmd.Dispose();
    //            dr.Close();

    //            return items;




    //        }
    //    }
    //}

    //public class ReexplorationNotification
    //{
    //    public void RegisterNotification(DateTime currentTime)
    //    {
    //        string conStr = ConfigurationManager.ConnectionStrings["AuditContext"].ConnectionString;

    //        string sqlCommand = @"SELECT [Id],[IPnumber],[Reason_for_exploration] from [dbo].[Re_exploration] where  ([submitted_date] >= @SubmittedTime OR [submitted_date] <= @SubmittedTime) ";
    //        //you can notice here I have added table name like this [dbo].[Contacts] with [dbo], its mendatory when you use Sql Dependency  
    //        using (SqlConnection con = new SqlConnection(conStr))
    //        {
    //            SqlCommand cmd = new SqlCommand(sqlCommand, con);
    //            cmd.Parameters.AddWithValue("@SubmittedTime", currentTime);
    //            if (con.State != System.Data.ConnectionState.Open)
    //            {
    //                con.Open();
    //            }

    //            SqlDependency sqlDep = new SqlDependency(cmd);
    //            sqlDep.OnChange += sqlDep_OnChange;
    //            //we must have to execute the command here  
    //            using (SqlDataReader reader = cmd.ExecuteReader())
    //            {
    //                con.Close();
    //            }
    //        }
    //    }

    //    public void sqlDep_OnChange(object sender, SqlNotificationEventArgs e)
    //    {
    //        //or you can also check => if (e.Info == SqlNotificationInfo.Insert) , if you want notification only for inserted record  
    //        if (e.Type == SqlNotificationType.Change)
    //        {
    //            SqlDependency sqlDep = sender as SqlDependency;
    //            sqlDep.OnChange -= sqlDep_OnChange;


    //            //from here we will send notification message to client  
    //            var notificationHub = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
    //            notificationHub.Clients.All.notify("added");
    //            //re-register notification  

    //            RegisterNotification(DateTime.Now);
    //        }
    //    }

    //    public List<Inspinia_MVC5_SeedProject.Models.Re_exploration> GetData(DateTime SubmittedDateTime, string No)
    //    {
    //        using (Inspinia_MVC5_SeedProject.Models.AuditContext dc = new Inspinia_MVC5_SeedProject.Models.AuditContext())
    //        {
    //            List<Models.Re_exploration> items = new List<Models.Re_exploration>();
    //            string constr = ConfigurationManager.ConnectionStrings["AuditContext"].ConnectionString.ToString();
    //            string query = "select Id,IPnumber,Reason_for_exploration,submitted_date  from dbo.Re_exploration where MONTH(submitted_date) = MONTH(GetDate()) and YEAR(submitted_date) = YEAR(GetDate())";
    //            SqlConnection con = new SqlConnection(constr);
    //            con.Open();
    //            SqlCommand cmd = new SqlCommand(query, con);
    //            cmd.CommandType = CommandType.Text;
    //            SqlDataReader dr = cmd.ExecuteReader();
    //            while (dr.Read())
    //            {
    //                items.Add(new Models.Re_exploration
    //                {
    //                    Id = Convert.ToInt32(dr["Id"].ToString()),


    //                    IPnumber = dr["IPnumber"].ToString(),
    //                    Reason_for_exploration = dr["Reason_for_exploration"].ToString(),
    //                    submitted_date = Convert.ToDateTime(dr["submitted_date"].ToString())



    //                }
    //               );
    //            }

    //            con.Close();
    //            cmd.Dispose();
    //            dr.Close();

    //            return items;




    //        }
    //    }
    //}

    //public class IntraOperativeChangeNotification
    //{
    //    public void RegisterNotification(DateTime currentTime)
    //    {
    //        string conStr = ConfigurationManager.ConnectionStrings["AuditContext"].ConnectionString;

    //        string sqlCommand = @"SELECT [Id],[IPnumber],[Reasonformodification] from [dbo].[Intraoperative_change_in_surgery] where  ([submitted_date] >= @SubmittedTime OR [submitted_date] <= @SubmittedTime) ";
    //        //you can notice here I have added table name like this [dbo].[Contacts] with [dbo], its mendatory when you use Sql Dependency  
    //        using (SqlConnection con = new SqlConnection(conStr))
    //        {
    //            SqlCommand cmd = new SqlCommand(sqlCommand, con);
    //            cmd.Parameters.AddWithValue("@SubmittedTime", currentTime);
    //            if (con.State != System.Data.ConnectionState.Open)
    //            {
    //                con.Open();
    //            }

    //            SqlDependency sqlDep = new SqlDependency(cmd);
    //            sqlDep.OnChange += sqlDep_OnChange;
    //            //we must have to execute the command here  
    //            using (SqlDataReader reader = cmd.ExecuteReader())
    //            {
    //                con.Close();
    //            }
    //        }
    //    }

    //    public void sqlDep_OnChange(object sender, SqlNotificationEventArgs e)
    //    {
    //        //or you can also check => if (e.Info == SqlNotificationInfo.Insert) , if you want notification only for inserted record  
    //        if (e.Type == SqlNotificationType.Change)
    //        {
    //            SqlDependency sqlDep = sender as SqlDependency;
    //            sqlDep.OnChange -= sqlDep_OnChange;


    //            //from here we will send notification message to client  
    //            var notificationHub = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
    //            notificationHub.Clients.All.notify("added");
    //            //re-register notification  

    //            RegisterNotification(DateTime.Now);
    //        }
    //    }

    //    public List<Inspinia_MVC5_SeedProject.Models.Intraoperative_change_in_surgery> GetData(DateTime SubmittedDateTime, string No)
    //    {
    //        using (Inspinia_MVC5_SeedProject.Models.AuditContext dc = new Inspinia_MVC5_SeedProject.Models.AuditContext())
    //        {
    //            List<Models.Intraoperative_change_in_surgery> items = new List<Models.Intraoperative_change_in_surgery>();
    //            string constr = ConfigurationManager.ConnectionStrings["AuditContext"].ConnectionString.ToString();
    //            string query = "select Id,IPnumber,Reasonformodification,submitted_date  from dbo.Intraoperative_change_in_surgery where MONTH(submitted_date) = MONTH(GetDate()) and YEAR(submitted_date) = YEAR(GetDate()) ";
    //            SqlConnection con = new SqlConnection(constr);
    //            con.Open();
    //            SqlCommand cmd = new SqlCommand(query, con);
    //            cmd.CommandType = CommandType.Text;
    //            SqlDataReader dr = cmd.ExecuteReader();
    //            while (dr.Read())
    //            {
    //                items.Add(new Models.Intraoperative_change_in_surgery
    //                {
    //                    Id = Convert.ToInt32(dr["Id"].ToString()),


    //                    IPnumber = dr["IPnumber"].ToString(),
    //                    Reasonformodification = dr["Reasonformodification"].ToString(),
    //                    submitted_date = Convert.ToDateTime(dr["submitted_date"].ToString())



    //                }
    //               );
    //            }

    //            con.Close();
    //            cmd.Dispose();
    //            dr.Close();

    //            return items;




    //        }
    //    }

    //}

    //public class AnaesthesiaPlanModNotification
    //{
    //    public void RegisterNotification(DateTime currentTime)
    //    {
    //        string conStr = ConfigurationManager.ConnectionStrings["AuditContext"].ConnectionString;

    //        string sqlCommand = @"SELECT [Id],[IPNumber],[Reason_for_modification] from [dbo].[Ramaiah_AnaesthesiaPlanModification] where  ([dt_Submitted] >= @SubmittedTime OR [dt_Submitted] <= @SubmittedTime) ";
    //        //you can notice here I have added table name like this [dbo].[Contacts] with [dbo], its mendatory when you use Sql Dependency  
    //        using (SqlConnection con = new SqlConnection(conStr))
    //        {
    //            SqlCommand cmd = new SqlCommand(sqlCommand, con);
    //            cmd.Parameters.AddWithValue("@SubmittedTime", currentTime);
    //            if (con.State != System.Data.ConnectionState.Open)
    //            {
    //                con.Open();
    //            }

    //            SqlDependency sqlDep = new SqlDependency(cmd);
    //            sqlDep.OnChange += sqlDep_OnChange;
    //            //we must have to execute the command here  
    //            using (SqlDataReader reader = cmd.ExecuteReader())
    //            {
    //                con.Close();
    //            }
    //        }
    //    }

    //    public void sqlDep_OnChange(object sender, SqlNotificationEventArgs e)
    //    {
    //        //or you can also check => if (e.Info == SqlNotificationInfo.Insert) , if you want notification only for inserted record  
    //        if (e.Type == SqlNotificationType.Change)
    //        {
    //            SqlDependency sqlDep = sender as SqlDependency;
    //            sqlDep.OnChange -= sqlDep_OnChange;


    //            //from here we will send notification message to client  
    //            var notificationHub = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
    //            notificationHub.Clients.All.notify("added");
    //            //re-register notification  

    //            RegisterNotification(DateTime.Now);
    //        }
    //    }

    //    public List<Inspinia_MVC5_SeedProject.Models.Ramaiah_AnaesthesiaPlanModification> GetData(DateTime SubmittedDateTime, string No)
    //    {
    //        using (Inspinia_MVC5_SeedProject.Models.AuditContext dc = new Inspinia_MVC5_SeedProject.Models.AuditContext())
    //        {
    //            List<Models.Ramaiah_AnaesthesiaPlanModification> items = new List<Models.Ramaiah_AnaesthesiaPlanModification>();
    //            string constr = ConfigurationManager.ConnectionStrings["AuditContext"].ConnectionString.ToString();
    //            string query = "select Id,IPNumber,Reason_for_modification, dt_submitted  from dbo.Ramaiah_AnaesthesiaPlanModification where MONTH(dt_submitted) = MONTH(GetDate()) and YEAR(dt_submitted) = YEAR(GetDate()) ";
    //            SqlConnection con = new SqlConnection(constr);
    //            con.Open();
    //            SqlCommand cmd = new SqlCommand(query, con);
    //            cmd.CommandType = CommandType.Text;
    //            SqlDataReader dr = cmd.ExecuteReader();
    //            while (dr.Read())
    //            {
    //                items.Add(new Models.Ramaiah_AnaesthesiaPlanModification
    //                {
    //                    Id = Convert.ToInt32(dr["Id"].ToString()),


    //                    IPNumber = dr["IPNumber"].ToString(),
    //                    Reason_for_modification = dr["Reason_for_modification"].ToString(),
    //                    dt_submitted = Convert.ToDateTime(dr["dt_submitted"].ToString())



    //                }
    //               );
    //            }

    //            con.Close();
    //            cmd.Dispose();
    //            dr.Close();

    //            return items;




    //        }
    //    }

    //}

    //#endregion

    //#region Labs

    //public class RedoLabsNotificationManager
    //{
    //    public void RegisterNotification(DateTime currentTime)
    //    {
    //        string conStr = ConfigurationManager.ConnectionStrings["AuditContext"].ConnectionString;

    //        string sqlCommand = @"SELECT [Id],[IPNumber],[TestName] from [dbo].[RedoLabs] where Status = 'Pending' AND ([SubmittedTime] >= @SubmittedTime OR [SubmittedTime] <= @SubmittedTime) ";
    //        //you can notice here I have added table name like this [dbo].[Contacts] with [dbo], its mendatory when you use Sql Dependency  
    //        using (SqlConnection con = new SqlConnection(conStr))
    //        {
    //            SqlCommand cmd = new SqlCommand(sqlCommand, con);
    //            cmd.Parameters.AddWithValue("@SubmittedTime", currentTime);
    //            if (con.State != System.Data.ConnectionState.Open)
    //            {
    //                con.Open();
    //            }

    //            SqlDependency sqlDep = new SqlDependency(cmd);
    //            sqlDep.OnChange += sqlDep_OnChange;
    //            //we must have to execute the command here  
    //            using (SqlDataReader reader = cmd.ExecuteReader())
    //            {
    //                con.Close();
    //            }
    //        }
    //    }

    //    public void sqlDep_OnChange(object sender, SqlNotificationEventArgs e)
    //    {
    //        //or you can also check => if (e.Info == SqlNotificationInfo.Insert) , if you want notification only for inserted record  
    //        if (e.Type == SqlNotificationType.Change)
    //        {
    //            SqlDependency sqlDep = sender as SqlDependency;
    //            sqlDep.OnChange -= sqlDep_OnChange;


    //            //from here we will send notification message to client  
    //            var notificationHub = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
    //            notificationHub.Clients.All.notify("added");
    //            //re-register notification  

    //            RegisterNotification(DateTime.Now);
    //        }
    //    }

    //    public List<Inspinia_MVC5_SeedProject.Models.RedoLab> GetData(DateTime SubmittedDateTime, string No)
    //    {
    //        using (Inspinia_MVC5_SeedProject.Models.AuditContext dc = new Inspinia_MVC5_SeedProject.Models.AuditContext())
    //        {
    //            return dc.RedoLabs.Where(a => a.Status == "Pending" && (a.SubmittedTime >= SubmittedDateTime || a.SubmittedTime <= SubmittedDateTime)).OrderByDescending(a => a.SubmittedTime).ToList();
    //        }
    //    }
    //}

    //public class ReportingErrorsLabNotificationManager
    //{
    //    public void RegisterNotification(DateTime currentTime)
    //    {
    //        string conStr = ConfigurationManager.ConnectionStrings["AuditContext"].ConnectionString;

    //        string sqlCommand = @"SELECT [Id],[IPNumber],[TestName] from [dbo].[ReportingErrorLabs] where Status = 'Pending' AND ([SubmittedTime] >= @SubmittedTime OR [SubmittedTime] <= @SubmittedTime) ";
    //        //you can notice here I have added table name like this [dbo].[Contacts] with [dbo], its mendatory when you use Sql Dependency  
    //        using (SqlConnection con = new SqlConnection(conStr))
    //        {
    //            SqlCommand cmd = new SqlCommand(sqlCommand, con);
    //            cmd.Parameters.AddWithValue("@SubmittedTime", currentTime);
    //            if (con.State != System.Data.ConnectionState.Open)
    //            {
    //                con.Open();
    //            }

    //            SqlDependency sqlDep = new SqlDependency(cmd);
    //            sqlDep.OnChange += sqlDep_OnChange;
    //            //we must have to execute the command here  
    //            using (SqlDataReader reader = cmd.ExecuteReader())
    //            {
    //                con.Close();
    //            }
    //        }
    //    }

    //    public void sqlDep_OnChange(object sender, SqlNotificationEventArgs e)
    //    {
    //        //or you can also check => if (e.Info == SqlNotificationInfo.Insert) , if you want notification only for inserted record  
    //        if (e.Type == SqlNotificationType.Change)
    //        {
    //            SqlDependency sqlDep = sender as SqlDependency;
    //            sqlDep.OnChange -= sqlDep_OnChange;


    //            //from here we will send notification message to client  
    //            var notificationHub = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
    //            notificationHub.Clients.All.notify("added");
    //            //re-register notification  

    //            RegisterNotification(DateTime.Now);
    //        }
    //    }

    //    public List<Inspinia_MVC5_SeedProject.Models.ReportingErrorLab> GetData(DateTime SubmittedDateTime, string No)
    //    {
    //        using (Inspinia_MVC5_SeedProject.Models.AuditContext dc = new Inspinia_MVC5_SeedProject.Models.AuditContext())
    //        {
    //            return dc.ReportingErrorLabs.Where(a => a.Status == "Pending" && (a.SubmittedTime >= SubmittedDateTime || a.SubmittedTime <= SubmittedDateTime)).OrderByDescending(a => a.SubmittedTime).ToList();
    //        }
    //    }
    //}

    //public class CorrelationWithClinicalLabNotificationManager
    //{
    //    public void RegisterNotification(DateTime currentTime)
    //    {
    //        string conStr = ConfigurationManager.ConnectionStrings["AuditContext"].ConnectionString;

    //        string sqlCommand = @"SELECT [Id],[IPNumber],[TestName] from [dbo].[CorrelationWithClinicalLabs] where Status = 'Pending' AND ([SubmittedTime] >= @SubmittedTime OR [SubmittedTime] <= @SubmittedTime) ";
    //        //you can notice here I have added table name like this [dbo].[Contacts] with [dbo], its mendatory when you use Sql Dependency  
    //        using (SqlConnection con = new SqlConnection(conStr))
    //        {
    //            SqlCommand cmd = new SqlCommand(sqlCommand, con);
    //            cmd.Parameters.AddWithValue("@SubmittedTime", currentTime);
    //            if (con.State != System.Data.ConnectionState.Open)
    //            {
    //                con.Open();
    //            }

    //            SqlDependency sqlDep = new SqlDependency(cmd);
    //            sqlDep.OnChange += sqlDep_OnChange;
    //            //we must have to execute the command here  
    //            using (SqlDataReader reader = cmd.ExecuteReader())
    //            {
    //                con.Close();
    //            }
    //        }
    //    }

    //    public void sqlDep_OnChange(object sender, SqlNotificationEventArgs e)
    //    {
    //        //or you can also check => if (e.Info == SqlNotificationInfo.Insert) , if you want notification only for inserted record  
    //        if (e.Type == SqlNotificationType.Change)
    //        {
    //            SqlDependency sqlDep = sender as SqlDependency;
    //            sqlDep.OnChange -= sqlDep_OnChange;


    //            //from here we will send notification message to client  
    //            var notificationHub = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
    //            notificationHub.Clients.All.notify("added");
    //            //re-register notification  

    //            RegisterNotification(DateTime.Now);
    //        }
    //    }

    //    public List<Inspinia_MVC5_SeedProject.Models.CorrelationWithClinicalLab> GetData(DateTime SubmittedDateTime, string No)
    //    {
    //        using (Inspinia_MVC5_SeedProject.Models.AuditContext dc = new Inspinia_MVC5_SeedProject.Models.AuditContext())
    //        {
    //            return dc.CorrelationWithClinicalLabs.Where(a => a.Status == "Pending" && (a.SubmittedTime >= SubmittedDateTime || a.SubmittedTime <= SubmittedDateTime)).OrderByDescending(a => a.SubmittedTime).ToList();
    //        }
    //    }
    //}

    //public class CriticalValueWardNotificationManager
    //{
    //    public void RegisterNotification(DateTime currentTime)
    //    {
    //        string conStr = ConfigurationManager.ConnectionStrings["AuditContext"].ConnectionString;

    //        string sqlCommand = @"SELECT [SlNo],[IPNumber],[Lab_Name] from [dbo].[CriticalValueReportings] where Root_Cause_Analysis_Status = 'Open' AND ([DateAndTime_of_Sample_Collection] >= @SubmittedTime OR [DateAndTime_of_Sample_Collection] <= @SubmittedTime) ";
    //        //you can notice here I have added table name like this [dbo].[Contacts] with [dbo], its mendatory when you use Sql Dependency  
    //        using (SqlConnection con = new SqlConnection(conStr))
    //        {
    //            SqlCommand cmd = new SqlCommand(sqlCommand, con);
    //            cmd.Parameters.AddWithValue("@SubmittedTime", currentTime);
    //            if (con.State != System.Data.ConnectionState.Open)
    //            {
    //                con.Open();
    //            }

    //            SqlDependency sqlDep = new SqlDependency(cmd);
    //            sqlDep.OnChange += sqlDep_OnChange;
    //            //we must have to execute the command here  
    //            using (SqlDataReader reader = cmd.ExecuteReader())
    //            {
    //                con.Close();
    //            }
    //        }
    //    }

    //    public void sqlDep_OnChange(object sender, SqlNotificationEventArgs e)
    //    {
    //        //or you can also check => if (e.Info == SqlNotificationInfo.Insert) , if you want notification only for inserted record  
    //        if (e.Type == SqlNotificationType.Change)
    //        {
    //            SqlDependency sqlDep = sender as SqlDependency;
    //            sqlDep.OnChange -= sqlDep_OnChange;


    //            //from here we will send notification message to client  
    //            var notificationHub = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
    //            notificationHub.Clients.All.notify("added");
    //            //re-register notification  

    //            RegisterNotification(DateTime.Now);
    //        }
    //    }

    //    public List<Inspinia_MVC5_SeedProject.Models.CriticalValueReporting> GetData(DateTime SubmittedDateTime, string No)
    //    {
    //        using (Inspinia_MVC5_SeedProject.Models.AuditContext dc = new Inspinia_MVC5_SeedProject.Models.AuditContext())
    //        {
    //            return dc.CriticalValueReportings.Where(a => a.Root_Cause_Analysis_Status == "Open" && (a.DateAndTime_of_Sample_Collection >= SubmittedDateTime || a.DateAndTime_of_Sample_Collection <= SubmittedDateTime)).OrderByDescending(a => a.DateAndTime_of_Sample_Collection).ToList();
    //        }
    //    }
    //}

    //public class CriticalValueLabNotificationManager
    //{
    //    public void RegisterNotification(DateTime currentTime)
    //    {
    //        string conStr = ConfigurationManager.ConnectionStrings["AuditContext"].ConnectionString;

    //        string sqlCommand = @"SELECT [SlNo],[IPNumber],[Lab_Name] from [dbo].[CriticalValueReportings] where Quality_Status = 'Open' AND ([DateAndTime_of_Sample_Collection] >= @SubmittedTime OR [DateAndTime_of_Sample_Collection] <= @SubmittedTime) ";
    //        //you can notice here I have added table name like this [dbo].[Contacts] with [dbo], its mendatory when you use Sql Dependency  
    //        using (SqlConnection con = new SqlConnection(conStr))
    //        {
    //            SqlCommand cmd = new SqlCommand(sqlCommand, con);
    //            cmd.Parameters.AddWithValue("@SubmittedTime", currentTime);
    //            if (con.State != System.Data.ConnectionState.Open)
    //            {
    //                con.Open();
    //            }

    //            SqlDependency sqlDep = new SqlDependency(cmd);
    //            sqlDep.OnChange += sqlDep_OnChange;
    //            //we must have to execute the command here  
    //            using (SqlDataReader reader = cmd.ExecuteReader())
    //            {
    //                con.Close();
    //            }
    //        }
    //    }

    //    public void sqlDep_OnChange(object sender, SqlNotificationEventArgs e)
    //    {
    //        //or you can also check => if (e.Info == SqlNotificationInfo.Insert) , if you want notification only for inserted record  
    //        if (e.Type == SqlNotificationType.Change)
    //        {
    //            SqlDependency sqlDep = sender as SqlDependency;
    //            sqlDep.OnChange -= sqlDep_OnChange;


    //            //from here we will send notification message to client  
    //            var notificationHub = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
    //            notificationHub.Clients.All.notify("added");
    //            //re-register notification  

    //            RegisterNotification(DateTime.Now);
    //        }
    //    }

    //    public List<Inspinia_MVC5_SeedProject.Models.CriticalValueReporting> GetData(DateTime SubmittedDateTime, string No)
    //    {
    //        using (Inspinia_MVC5_SeedProject.Models.AuditContext dc = new Inspinia_MVC5_SeedProject.Models.AuditContext())
    //        {
    //            return dc.CriticalValueReportings.Where(a => a.Quality_Status == "Open" && (a.DateAndTime_of_Sample_Collection >= SubmittedDateTime || a.DateAndTime_of_Sample_Collection <= SubmittedDateTime)).OrderByDescending(a => a.DateAndTime_of_Sample_Collection).ToList();
    //        }
    //    }
    //}


    //#endregion

    //#region radiology
    //public class RedoRadiologyNotificationManager
    //{
    //    public void RegisterNotification(DateTime currentTime)
    //    {
    //        string conStr = ConfigurationManager.ConnectionStrings["AuditContext"].ConnectionString;

    //        string sqlCommand = @"SELECT [Id],[IPNumber],[ImagingModality] from [dbo].[RedoRadiologies] where Status = 'Pending' AND ([SubmittedTime] >= @SubmittedTime OR [SubmittedTime] <= @SubmittedTime) ";
    //        //you can notice here I have added table name like this [dbo].[Contacts] with [dbo], its mendatory when you use Sql Dependency  
    //        using (SqlConnection con = new SqlConnection(conStr))
    //        {
    //            SqlCommand cmd = new SqlCommand(sqlCommand, con);
    //            cmd.Parameters.AddWithValue("@SubmittedTime", currentTime);
    //            if (con.State != System.Data.ConnectionState.Open)
    //            {
    //                con.Open();
    //            }

    //            SqlDependency sqlDep = new SqlDependency(cmd);
    //            sqlDep.OnChange += sqlDep_OnChange;
    //            //we must have to execute the command here  
    //            using (SqlDataReader reader = cmd.ExecuteReader())
    //            {
    //                con.Close();
    //            }
    //        }
    //    }

    //    public void sqlDep_OnChange(object sender, SqlNotificationEventArgs e)
    //    {
    //        //or you can also check => if (e.Info == SqlNotificationInfo.Insert) , if you want notification only for inserted record  
    //        if (e.Type == SqlNotificationType.Change)
    //        {
    //            SqlDependency sqlDep = sender as SqlDependency;
    //            sqlDep.OnChange -= sqlDep_OnChange;


    //            //from here we will send notification message to client  
    //            var notificationHub = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
    //            notificationHub.Clients.All.notify("added");
    //            //re-register notification  

    //            RegisterNotification(DateTime.Now);
    //        }
    //    }

    //    public List<Inspinia_MVC5_SeedProject.Models.RedoRadiologies> GetData(DateTime SubmittedDateTime, string No)
    //    {
    //        using (Inspinia_MVC5_SeedProject.Models.AuditContext dc = new Inspinia_MVC5_SeedProject.Models.AuditContext())
    //        {
    //            return dc.RedoRadiologies.Where(a => a.Status == "Pending" && (a.SubmittedTime >= SubmittedDateTime || a.SubmittedTime <= SubmittedDateTime)).OrderByDescending(a => a.SubmittedTime).ToList();
    //        }
    //    }
    //}


    //public class ReportingErrorNotificationManager
    //{
    //    public void RegisterNotification(DateTime currentTime)
    //    {
    //        string conStr = ConfigurationManager.ConnectionStrings["AuditContext"].ConnectionString;

    //        string sqlCommand = @"SELECT [Id],[IPNumber],[ImagingModality] from [dbo].[RedoRadiologies] where Status = 'Pending' AND ([SubmittedTime] >= @SubmittedTime OR [SubmittedTime] <= @SubmittedTime) ";
    //        //you can notice here I have added table name like this [dbo].[Contacts] with [dbo], its mendatory when you use Sql Dependency  
    //        using (SqlConnection con = new SqlConnection(conStr))
    //        {
    //            SqlCommand cmd = new SqlCommand(sqlCommand, con);
    //            cmd.Parameters.AddWithValue("@SubmittedTime", currentTime);
    //            if (con.State != System.Data.ConnectionState.Open)
    //            {
    //                con.Open();
    //            }

    //            SqlDependency sqlDep = new SqlDependency(cmd);
    //            sqlDep.OnChange += sqlDep_OnChange;
    //            //we must have to execute the command here  
    //            using (SqlDataReader reader = cmd.ExecuteReader())
    //            {
    //                con.Close();
    //            }
    //        }
    //    }

    //    public void sqlDep_OnChange(object sender, SqlNotificationEventArgs e)
    //    {
    //        //or you can also check => if (e.Info == SqlNotificationInfo.Insert) , if you want notification only for inserted record  
    //        if (e.Type == SqlNotificationType.Change)
    //        {
    //            SqlDependency sqlDep = sender as SqlDependency;
    //            sqlDep.OnChange -= sqlDep_OnChange;


    //            //from here we will send notification message to client  
    //            var notificationHub = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
    //            notificationHub.Clients.All.notify("added");
    //            //re-register notification  

    //            RegisterNotification(DateTime.Now);
    //        }
    //    }

    //    public List<Inspinia_MVC5_SeedProject.Models.ReportingError> GetData(DateTime SubmittedDateTime, string No)
    //    {
    //        using (Inspinia_MVC5_SeedProject.Models.AuditContext dc = new Inspinia_MVC5_SeedProject.Models.AuditContext())
    //        {
    //            return dc.ReportingErrors.Where(a => a.Status == "Pending" && (a.SubmittedTime >= SubmittedDateTime || a.SubmittedTime <= SubmittedDateTime)).OrderByDescending(a => a.SubmittedTime).ToList();
    //        }
    //    }
    //}

    //public class CorrelationWithClinicalNotificationManager
    //{
    //    public void RegisterNotification(DateTime currentTime)
    //    {
    //        string conStr = ConfigurationManager.ConnectionStrings["AuditContext"].ConnectionString;

    //        string sqlCommand = @"SELECT [Id],[IPNumber],[ImagingModality] from [dbo].[CorrelationWithClinical] where Status = 'Pending' AND ([SubmittedTime] >= @SubmittedTime OR [SubmittedTime] <= @SubmittedTime) ";
    //        //you can notice here I have added table name like this [dbo].[Contacts] with [dbo], its mendatory when you use Sql Dependency  
    //        using (SqlConnection con = new SqlConnection(conStr))
    //        {
    //            SqlCommand cmd = new SqlCommand(sqlCommand, con);
    //            cmd.Parameters.AddWithValue("@SubmittedTime", currentTime);
    //            if (con.State != System.Data.ConnectionState.Open)
    //            {
    //                con.Open();
    //            }

    //            SqlDependency sqlDep = new SqlDependency(cmd);
    //            sqlDep.OnChange += sqlDep_OnChange;
    //            //we must have to execute the command here  
    //            using (SqlDataReader reader = cmd.ExecuteReader())
    //            {
    //                con.Close();
    //            }
    //        }
    //    }

    //    public void sqlDep_OnChange(object sender, SqlNotificationEventArgs e)
    //    {
    //        //or you can also check => if (e.Info == SqlNotificationInfo.Insert) , if you want notification only for inserted record  
    //        if (e.Type == SqlNotificationType.Change)
    //        {
    //            SqlDependency sqlDep = sender as SqlDependency;
    //            sqlDep.OnChange -= sqlDep_OnChange;


    //            //from here we will send notification message to client  
    //            var notificationHub = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
    //            notificationHub.Clients.All.notify("added");
    //            //re-register notification  

    //            RegisterNotification(DateTime.Now);
    //        }
    //    }

    //    //public List<Inspinia_MVC5_SeedProject.Models.CorrelationWithClinical> GetData(DateTime SubmittedDateTime, string No)
    //    //{
    //    //    using (Inspinia_MVC5_SeedProject.Models.AuditContext dc = new Inspinia_MVC5_SeedProject.Models.AuditContext())
    //    //    {
    //    //        return dc.CorrelationWithClinicals.Where(a => a.Status == "Pending" && (a.SubmittedTime >= SubmittedDateTime || a.SubmittedTime <= SubmittedDateTime)).OrderByDescending(a => a.SubmittedTime).ToList();
    //    //    }
    //    //}
    //}

    //#endregion

    #region complaint management
    public class ComplaintAdminNotification
    {
        public void RegisterNotification(DateTime currentTime)
        {
            string conStr = ConfigurationManager.ConnectionStrings["AuditContext"].ConnectionString;

            string sqlCommand = @"SELECT [ComplaintNumber],[Department],[Status] from [dbo].[ComplaintManagement] where  ([DateTime] >= @SubmittedTime OR [DateTime] <= @SubmittedTime) ";
            //you can notice here I have added table name like this [dbo].[Contacts] with [dbo], its mendatory when you use Sql Dependency  
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand(sqlCommand, con);
                cmd.Parameters.AddWithValue("@SubmittedTime", currentTime);
                if (con.State != System.Data.ConnectionState.Open)
                {
                    con.Open();
                }

                SqlDependency sqlDep = new SqlDependency(cmd);
                sqlDep.OnChange += sqlDep_OnChange;
                //we must have to execute the command here  
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    con.Close();
                }
            }
        }

        public void sqlDep_OnChange(object sender, SqlNotificationEventArgs e)
        {
            //or you can also check => if (e.Info == SqlNotificationInfo.Insert) , if you want notification only for inserted record  
            if (e.Type == SqlNotificationType.Change)
            {
                SqlDependency sqlDep = sender as SqlDependency;
                sqlDep.OnChange -= sqlDep_OnChange;


                //from here we will send notification message to client  
                var notificationHub = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
                notificationHub.Clients.All.notify("added");
                //re-register notification  

                RegisterNotification(DateTime.Now);
            }
        }

        public List<Inspinia_MVC5_SeedProject.Models.ComplaintManagement> GetData(DateTime ComplaintDateTime, string No)
        {
            using (Inspinia_MVC5_SeedProject.Models.AuditContext dc = new Inspinia_MVC5_SeedProject.Models.AuditContext())
            {
                return dc.ComplaintManagement.Where(a => a.Status == "Delegation pending" && (a.DateTime >= ComplaintDateTime || a.DateTime <= ComplaintDateTime)).OrderByDescending(a => a.DateTime).ToList();
            }
        }

    }

    public class ComplaintDelegateNotification
    {
        public void RegisterNotification(DateTime currentTime)
        {
            string conStr = ConfigurationManager.ConnectionStrings["AuditContext"].ConnectionString;

            string sqlCommand = @"SELECT [ComplaintNumber],[Department],[Status] from [dbo].[ComplaintManagement] where  ([DateTime] >= @SubmittedTime OR [DateTime] <= @SubmittedTime) ";
            //you can notice here I have added table name like this [dbo].[Contacts] with [dbo], its mendatory when you use Sql Dependency  
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand(sqlCommand, con);
                cmd.Parameters.AddWithValue("@SubmittedTime", currentTime);
                if (con.State != System.Data.ConnectionState.Open)
                {
                    con.Open();
                }

                SqlDependency sqlDep = new SqlDependency(cmd);
                sqlDep.OnChange += sqlDep_OnChange;
                //we must have to execute the command here  
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    con.Close();
                }
            }
        }

        public void sqlDep_OnChange(object sender, SqlNotificationEventArgs e)
        {
            //or you can also check => if (e.Info == SqlNotificationInfo.Insert) , if you want notification only for inserted record  
            if (e.Type == SqlNotificationType.Change)
            {
                SqlDependency sqlDep = sender as SqlDependency;
                sqlDep.OnChange -= sqlDep_OnChange;


                //from here we will send notification message to client  
                var notificationHub = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
                notificationHub.Clients.All.notify("added");
                //re-register notification  

                RegisterNotification(DateTime.Now);
            }
        }

        public List<Inspinia_MVC5_SeedProject.Models.ComplaintManagement> GetData(DateTime ComplaintDateTime, string Department)
        {
            using (Inspinia_MVC5_SeedProject.Models.AuditContext dc = new Inspinia_MVC5_SeedProject.Models.AuditContext())
            {

                List<Models.ComplaintManagement> items = new List<Models.ComplaintManagement>();
                string constr = ConfigurationManager.ConnectionStrings["AuditContext"].ConnectionString.ToString();
                string query = "select ComplaintNumber,Department,Status from dbo.ComplaintManagement where Department = '" + Department + "' and (Status = 'Assessment pending') and (DateTime >= '" + Convert.ToDateTime(ComplaintDateTime) + "' OR DateTime <= '" + Convert.ToDateTime(ComplaintDateTime) + "' ) ";
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    items.Add(new Models.ComplaintManagement
                    {
                        ComplaintNumber = dr["ComplaintNumber"].ToString(),


                        Department = dr["Department"].ToString(),
                        Status = dr["Status"].ToString()






                    }
                   );
                }

                con.Close();
                cmd.Dispose();
                dr.Close();

                return items;

                //  return dc.Incidents.Where(a => a.IncidentStatus == "Delegated" || a.IncidentStatus== "Re-delegated" && a.IncidentDateTime >= IncidentDateTime || a.IncidentDateTime <= IncidentDateTime && a.DelegatedTo == Department).OrderByDescending(a => a.IncidentDateTime).ToList();
            }
        }

    }




    #endregion complaint management
}