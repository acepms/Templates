
//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated using CSLA 3.6.x CodeSmith Templates.
//     Changes to this file will be lost after each regeneration.
//     To extend the functionality of this class, please modify the partial class 'Category.cs'.
//
//     Template: EditableRoot.DataAccess.cst
//     Template website: http://code.google.com/p/codesmith/
// </autogenerated>
//------------------------------------------------------------------------------
#region using declarations

using System;

using Csla;
using Csla.Data;

using PetShop.Data;

#endregion

namespace PetShop.Business
{
	public partial class Category
	{		
		#region Data Access

		[RunLocal]
		protected override void DataPortal_Create()
		{
			//base.DataPortal_Create();

			ValidationRules.CheckRules();
		}

		private void DataPortal_Fetch(CategoryCriteria criteria)
		{
            using(SafeDataReader reader = DataAccessLayer.Instance.CategoryFetch(criteria.StateBag)) 
			{
				if(reader.Read())
				{	
					Fetch(reader);
				}
			}
        }
		
        private void Fetch(SafeDataReader reader)
		{
			LoadProperty(_categoryIdProperty, reader.GetString("CategoryId"));
			LoadProperty(_nameProperty, reader.GetString("Name"));
			LoadProperty(_descnProperty, reader.GetString("Descn"));


            MarkOld();
        }
		
		[Transactional(TransactionalTypes.TransactionScope)]
		protected override void DataPortal_Insert()
		{
			using(SafeDataReader reader = DataAccessLayer.Instance.CategoryInsert(ReadProperty(_categoryIdProperty), ReadProperty(_nameProperty), ReadProperty(_descnProperty)))
			{
				if(reader.Read())
				{

				}
			}
            
            FieldManager.UpdateChildren(this);
		}
		
		[Transactional(TransactionalTypes.TransactionScope)]
		protected override void DataPortal_Update()
		{
            using(SafeDataReader reader = DataAccessLayer.Instance.CategoryUpdate(ReadProperty(_categoryIdProperty), ReadProperty(_nameProperty), ReadProperty(_descnProperty)))
            {
            }
            
            FieldManager.UpdateChildren(this);
		}
		
		[Transactional(TransactionalTypes.TransactionScope)]
		protected override void DataPortal_DeleteSelf()
		{
            DataPortal_Delete(new CategoryCriteria(CategoryId));
        }
		
		[Transactional(TransactionalTypes.TransactionScope)]
		protected override void DataPortal_Delete(object criteria)
		{
			CategoryCriteria theCriteria = criteria as CategoryCriteria;
            if (theCriteria != null)
            {
				using(SafeDataReader reader = DataAccessLayer.Instance.CategoryDelete(theCriteria.StateBag)) 
				{
				}
			}
        }


		#endregion
	}
}