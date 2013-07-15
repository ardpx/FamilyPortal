using FamilyPortal.Api.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FamilyPortal.Api.Controllers
{
    public class ResourceController : ApiController
    {
        #region five classic RESTful APIs

        ///  GET api/resource
        /// <summary>
        /// Get all Resource objects
        /// </summary>
        /// <returns>List of Resource objects</returns>
        [ActionName("DefaultWebApiAction")]
        public List<ResourceDC> Get()
        {
            var ResourceList = new List<ResourceDC>();
            ResourceList.Add(new ResourceDC { URL = "GET api/resource" });
            return ResourceList;
        }

        /// GET api/resource/5
        /// <summary>
        /// Get the specific Resource by its unique id
        /// </summary>
        /// <param name="id">Unique id of Resource</param>
        /// <returns>Resource object</returns>
        [ActionName("DefaultWebApiAction")]
        public ResourceDC Get(int id)
        {
            return new ResourceDC { URL = "GET api/resource/" + id.ToString() };
        }

        /// POST api/resource
        /// <summary>
        /// Create new resource object
        /// </summary>
        /// <param name="value">new resource data</param>
        [ActionName("DefaultWebApiAction")]
        public void Post([FromBody]string value)
        {
        }

        /// PUT api/resource/5
        /// <summary>
        /// Change the value for the specific Resource object by its id
        /// </summary>
        /// <param name="id">Unique id of Resource</param>
        /// <param name="value">Resource data for updating</param>
        [ActionName("DefaultWebApiAction")]
        public void Put(int id, [FromBody]string value)
        {
        }

        /// DELETE api/resource/5
        /// <summary>
        /// Delete the sepcific Resource object by its id
        /// </summary>
        /// <param name="id">Unique id of Resource</param>
        [ActionName("DefaultWebApiAction")]
        public void Delete(int id)
        {
        }

        #endregion

        #region other Restful APIs

        /// PATCH api/resource/5
        /// <summary>
        /// Partially change the value for the specific Resource object by its id
        /// </summary>
        /// <param name="id">Unique id of Resource</param>
        /// <param name="value">Resource data for prtial updating</param>
        [ActionName("DefaultWebApiAction")]
        [HttpPatch]
        public void Patch(int id, [FromBody]string value)
        {
        }

        #endregion

        #region more traditonal MVC action APIs

        /// GET api/resource/3/subresource1
        /// <summary>
        /// Get the sub-resource1 of the specific Resource object by its unique id
        /// </summary>
        /// <param name="id">Unique id of Resource</param>
        /// <returns>sub-resource1 data</returns>
        [HttpGet]
        [ActionName("SubResource1")]
        public string DoSomeAction(int id)
        {
            return string.Format("GET api/resource/{0}/subResource1", id);

        }

        /// GET api/resource/subresource2
        /// <summary>
        /// Get the sub-resource2 of Resource
        /// </summary>
        /// <returns>sub-resource2 data</returns>
        [HttpGet]
        [ActionName("SubResource2")]
        public string DoSomeOtherAction()
        {
            return "api/resource/subresource2";
        }

        #endregion
    }
}
