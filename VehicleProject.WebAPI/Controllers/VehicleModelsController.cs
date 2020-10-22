using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using VehicleProject.DAL;
using VehicleProject.Models;
using VehicleProject.Repository.Common;
using VehicleProject.Service.Common;
using VehicleProject.WebAPI.ViewModels;
using VehicleProject.Common;
using System.Web.Mvc;
using VehicleProject.Common.Extensions;

namespace VehicleProject.WebAPI.Controllers
{
    public class VehicleModelsController : ApiController
    {
      
        private IVehicleModelService _service;
        private IMapper _mapper;
        
            
        public VehicleModelsController(IVehicleModelService service, IMapper mapper)
        {
            
            _service = service;
            _mapper = mapper;
        }

        // GET: api/VehicleModels
        public async Task<IHttpActionResult> GetVehicleModels(string searchString, int? page)
        {
            Filtering filter = new Filtering(searchString);
            Paging pages = new Paging(page);
            var models = await _service.GetModelsList(filter, pages);
            List<VehicleModelViewModel> viewModel = _mapper.Map<List<VehicleModelViewModel>>(models);
            return Ok(viewModel);
        }

        // GET: api/VehicleModels/5
        [ResponseType(typeof(VehicleModel))]
        public async Task<IHttpActionResult> GetVehicleModel(int id)
        {
            VehicleModel vehicleModel = await _service.GetModelById(id);
            VehicleModelViewModel viewModel = _mapper.Map<VehicleModelViewModel>(vehicleModel);
            if (vehicleModel == null)
            {
                return NotFound();
            }

            return Ok(viewModel);
        }

        // PUT: api/VehicleModels/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutVehicleModel(int id, VehicleModel vehicleModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vehicleModel.Id)
            {
                return BadRequest();
            }

                
               await  _service.UpdateModel(vehicleModel);
            VehicleModelViewModel viewModel = _mapper.Map<VehicleModelViewModel>(vehicleModel);

            return Ok(viewModel);
        }

        // POST: api/VehicleModels
        [ResponseType(typeof(VehicleModel))]
        public async Task<IHttpActionResult> PostVehicleModel(VehicleModel vehicleModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            
            await _service.InsertModel(vehicleModel);
            
            VehicleModelViewModel viewModel = _mapper.Map<VehicleModelViewModel>(vehicleModel);

            return CreatedAtRoute("DefaultApi", new { id = viewModel.Id }, viewModel);
        }

        // DELETE: api/VehicleModels/5
        [ResponseType(typeof(VehicleModel))]
        public async Task<IHttpActionResult> DeleteVehicleModel(int id)
        {
            VehicleModel vehicleModel = await _service.GetModelById(id);
            
            if (vehicleModel == null)
            {
                return NotFound();
            }

            ;
            await _service.DeleteModel(id);       
            return  StatusCode(HttpStatusCode.NoContent);
        }

    

       
      
    }
}