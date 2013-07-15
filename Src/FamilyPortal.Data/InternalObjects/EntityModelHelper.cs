using FamilyPortal.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyPortal.Data.InternalObjects
{
    public class EntityModelHelper
    {
        /// <summary>
        /// Get entity context from non-null application context.
        /// </summary>
        public static FamilyPortalEntities GetEntityContext(IAppContext appContext)
        {
            return GetEntityContext(appContext, false);
        }

        /// <summary>
        /// Get entity context from application context. 
        /// If the appContext is not specified, new entity context object will be created
        /// </summary>
        public static FamilyPortalEntities GetEntityContextAllowNull(IAppContext appContext)
        {
            return GetEntityContext(appContext, true);
        }

        private static FamilyPortalEntities GetEntityContext(IAppContext appContext, bool allowNull = false)
        {
            if (appContext == null)
            {
                // create new entity context object if the appContext is not specified
                if (allowNull)
                {
                    var entityContext = new FamilyPortalEntities();
                    return entityContext;
                }
                else
                {
                    throw new Exception();
                }
            }
            else
            {
                return (FamilyPortalEntities)appContext.GetPersistenceContext();
            }
        }
    }
}
