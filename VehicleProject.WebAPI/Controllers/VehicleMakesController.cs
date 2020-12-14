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
using VehicleProject.Service;
using VehicleProject.Service.Common;
using VehicleProject.Common.Extensions;
using VehicleProject.WebAPI.ViewModels;
using VehicleProject.Models.Common;

namespace VehicleProject.WebAPI.Controllers
{
    public class VehicleMakesController : ApiController
    {

        private IVehicleMakeService _vehicleService;
        private IMapper _mapper; 
       
        public VehicleMakesController(IVehicleMakeService vehicleMakeService, IMapper mapper)
        {
            _vehicleService = vehicleMakeService;
            _mapper = mapper;
            
        }
        [HttpGet]
        [Route("api/VehicleMakes/dropList")]
        public async Task <IHttpActionResult> GetMakesList()
        {
            IEnumerable<IVehicleMake> makes = await _vehicleService.GetMakesForDropDown();
            List<VehicleMakeViewModel> viewModel = _mapper.Map<List<VehicleMakeViewModel>>(makes);
            return Ok(viewModel);
        }
        // GET: api/VehicleMakes
        public async Task<IHttpActionResult> GetVehicleMakes(string searchString, int? page, string sortBy)
        {
            Filtering filter = new Filtering(searchString);
            Sorting sorting = new Sorting(sortBy);
            Paging paging = new Paging(page);
            IEnumerable<IVehicleMake> makes = await _vehicleService.GetMakesList(filter, paging, sorting);
            List<VehicleMakeViewModel> viewModel = _mapper.Map<List<VehicleMakeViewModel>>(makes);
            return Ok(viewModel);
           
        }

        // GET: api/VehicleMakes/5
        [ResponseType(typeof(VehicleMakeViewModel))]
        public async Task<IHttpActionResult> GetVehicleMake(int id)
        {
            IVehicleMake vehicleMake = await _vehicleService.GetMakeById(id);
            VehicleMakeViewModel viewModel = _mapper.Map<VehicleMakeViewModel>(vehicleMake);
            if (vehicleMake == null)
            {
                return NotFound();
            }

            return Ok(viewModel);
        }

        // PUT: api/VehicleMakes/5
        [ResponseType(typeof(VehicleMakeViewModel))]
        public async Task<IHttpActionResult> PutVehicleMake(int id, VehicleMakeViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != viewModel.Id)
            {
                return BadRequest();
            }

            IVehicleMake make = _mapper.Map<VehicleMake>(viewModel);
                await _vehicleService.UpdateMake(make);
            //VehicleMakeViewModel viewModel = _mapper.Map<VehicleMakeViewModel>(vehicleMake);
            
            return Ok(viewModel);
        }

        // POST: api/VehicleMakes
        [ResponseType(typeof(VehicleMakeViewModel))]
        public async Task<IHttpActionResult> PostVehicleMake(VehicleMakeViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            IVehicleMake make = _mapper.Map<VehicleMake>(viewModel);
            await _vehicleService.InsertMake(make);

            //VehicleMakeViewModel viewModel = _mapper.Map<VehicleMakeViewModel>(make);
            return CreatedAtRoute("DefaultApi", new { id = viewModel.Id }, viewModel);
        }

        // DELETE: api/VehicleMakes/5
        [HttpDelete]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> DeleteVehicleMake(int id)
        {
            
            IVehicleMake make = await _vehicleService.GetMakeById(id);
            if (make == null)
            {
                return NotFound();
            }

            
            await _vehicleService.DeleteMake(id);         
            
            return  StatusCode(HttpStatusCode.NoContent);
        }

        
    }
}