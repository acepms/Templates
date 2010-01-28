//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated using CSLA 3.8.X CodeSmith Templates.
//     Changes to this file will be lost after each regeneration.
//     To extend the functionality of this class, please modify the partial class 'OrderStatus.cs'.
//
//     Template: EditableChild.DataAccess.ParameterizedSQL.cst
//     Template website: http://code.google.com/p/codesmith/
// </autogenerated>
//------------------------------------------------------------------------------
#region Using declarations

using System;
using System.Data;
using System.Data.SqlClient;

using Csla;
using Csla.Data;

#endregion

namespace PetShop.Tests.ParameterizedSQL
{
    public partial class OrderStatus
    {
        protected override void Child_Create()
        {
            // TODO: load default values
            // omit this override if you have no defaults to set
            //base.Child_Create();
        }

        private void Child_Fetch(OrderStatusCriteria criteria)
        {
            string commandText = string.Format("SELECT [OrderId], [LineNum], [Timestamp], [Status] FROM [dbo].[OrderStatus] {0}", ADOHelper.BuildWhereStatement(criteria.StateBag));
            using (SqlConnection connection = new SqlConnection(ADOHelper.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    command.Parameters.AddRange(ADOHelper.SqlParameters(criteria.StateBag));
                    using(var reader = new SafeDataReader(command.ExecuteReader()))
                    {
                        if(reader.Read())
                            Map(reader);
                        else
                            throw new Exception(string.Format("The record was not found in 'OrderStatus' using the following criteria: {0}.", criteria));
                    }
                }
            }
        }

        private void Child_Insert(Order order)
        {
            const string commandText = "INSERT INTO [dbo].[OrderStatus] ([OrderId], [LineNum], [Timestamp], [Status]) VALUES (@p_OrderId, @p_LineNum, @p_Timestamp, @p_Status)";
            using (SqlConnection connection = new SqlConnection(ADOHelper.ConnectionString))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand(commandText, connection))
                {
                    command.Parameters.AddWithValue("@p_OrderId", order.OrderId);
					command.Parameters.AddWithValue("@p_LineNum", LineNum);
					command.Parameters.AddWithValue("@p_Timestamp", Timestamp);
					command.Parameters.AddWithValue("@p_Status", Status);
                    
                    using(var reader = new SafeDataReader(command.ExecuteReader()))
                    {
                        if(reader.Read())
                        {
                        }
                    }
                }
            }
        }

        private void Child_Update(Order order)
        {
            const string commandText = "UPDATE [dbo].[OrderStatus]  SET [OrderId] = @p_OrderId, [LineNum] = @p_LineNum, [Timestamp] = @p_Timestamp, [Status] = @p_Status WHERE [OrderId] = @p_OrderId AND [LineNum] = @p_LineNum";
            using (SqlConnection connection = new SqlConnection(ADOHelper.ConnectionString))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand(commandText, connection))
                {
					command.Parameters.AddWithValue("@p_OrderId", order.OrderId);
					command.Parameters.AddWithValue("@p_LineNum", LineNum);
					command.Parameters.AddWithValue("@p_Timestamp", Timestamp);
					command.Parameters.AddWithValue("@p_Status", Status);

                    using(var reader = new SafeDataReader(command.ExecuteReader()))
                    {
                        //RecordsAffected: The number of rows changed, inserted, or deleted. -1 for select statements; 0 if no rows were affected, or the statement failed. 
                        if(reader.RecordsAffected == 0)
                            throw new DBConcurrencyException("The entity is out of date on the client. Please update the entity and try again. This could also be thrown if the sql statement failed to execute.");

                    }
                }
            }
        }

        private void Child_DeleteSelf()
        {
            DataPortal_Delete(new OrderStatusCriteria(OrderId, LineNum));
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        protected void DataPortal_Delete(OrderStatusCriteria criteria)
        {
            string commandText = string.Format("DELETE FROM [dbo].[OrderStatus] {0}", ADOHelper.BuildWhereStatement(criteria.StateBag));
            using (SqlConnection connection = new SqlConnection(ADOHelper.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    command.Parameters.AddRange(ADOHelper.SqlParameters(criteria.StateBag));
					
					//result: The number of rows changed, inserted, or deleted. -1 for select statements; 0 if no rows were affected, or the statement failed. 
                    int result = command.ExecuteNonQuery();
                    if (result == 0)
                        throw new DBConcurrencyException("The entity is out of date on the client. Please update the entity and try again. This could also be thrown if the sql statement failed to execute.");
                }
            }
        }

        private void Map(SafeDataReader reader)
        {
            using(BypassPropertyChecks)
            {
                LoadProperty(_orderIdProperty, reader.GetInt32("OrderId"));
                LoadProperty(_lineNumProperty, reader.GetInt32("LineNum"));
                LoadProperty(_timestampProperty, reader.GetDateTime("Timestamp"));
                LoadProperty(_statusProperty, reader.GetString("Status"));
            }

            MarkAsChild();
            MarkOld();
        }
    }
}