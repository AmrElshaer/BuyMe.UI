using BuyMe.Application.Common.Models;
using BuyMe.Application.CustomField.Commonds.DeleteCustomField;
using BuyMe.Application.CustomField.Commonds.UpSertCustomField;
using BuyMe.Application.CustomField.Queries.GetCustomFields;
using BuyMe.Application.CustomFieldData.Queries.GetAllCustFieldData;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ByMe.Presentation.Controllers
{
    public class CustomFieldController: BaseController
    {
        [HttpPost]
        public async Task<IActionResult> UpSertCustomField(UpSertCustomerFieldCommond commond)
        {
            return Ok(await Mediator.Send(commond));
        }
        [HttpPost]
        public async Task<IActionResult> DeleteCustomField(DeleteCustomFieldCommond commond)
        {
            return Ok(await Mediator.Send(commond));
        }
        [HttpGet]
        public async Task<IActionResult> GetCustomData(string category)
        {
            return Ok(await Mediator.Send(new GetAllCustomFieldDataQuery(category)));
        }
        [HttpGet]
        public async Task<IActionResult> GetCustomFields(string category)
        {
            return Ok(await Mediator.Send(new GetCustomFieldQuery(CustomCategoryModel.Product)));
        }
    }   
}
