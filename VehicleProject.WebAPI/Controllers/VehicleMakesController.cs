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


        // GET: api/VehicleMakes
        public async Task<IHttpActionResult> GetVehicleMakes(string searchString, int? page)
        {
            Filtering filter = new Filtering(searchString);
            
            Paging paging = new Paging(page);
            IEnumerable<VehicleMake> makes = await _vehicleService.GetMakesList(filter, paging);
            List<VehicleMakeViewModel> viewModel = _mapper.Map<List<VehicleMakeViewModel>>(makes);
            return Ok(viewModel);
           
        }

        // GET: api/VehicleMakes/5
        [ResponseType(typeof(VehicleMakeViewModel))]
        public async Task<IHttpActionResult> GetVehicleMake(int id)
        {
            VehicleMake vehicleMake = await _vehicleService.GetMakeById(id);
            VehicleMakeViewModel viewModel = _mapper.Map<VehicleMakeViewModel>(vehicleMake);
            if (vehicleMake == null)
            {
                return NotFound();
            }

            return Ok(viewModel);
        }

        // PUT: api/VehicleMakes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutVehicleMake(int id, VehicleMake vehicleMake)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vehicleMake.Id)
            {
                return BadRequest();
            }

    
            
                await _vehicleService.UpdateMake(vehicleMake);
            VehicleMakeViewModel viewmodel = _mapper.Map<VehicleMakeViewModel>(vehicleMake);
     

            return Ok(viewmodel);
        }

        // POST: api/VehicleMakes
        [ResponseType(typeof(VehicleMake))]
        public async Task<IHttpActionResult> PostVehicleMake(VehicleMake vehicleMake)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           
            await _vehicleService.InsertMake(vehicleMake);
            
            VehicleMakeViewModel viewModel = _mapper.Map<VehicleMakeViewModel>(vehicleMake);
            return CreatedAtRoute("DefaultApi", new { id = viewModel.Id }, viewModel);
        }

        // DELETE: api/VehicleMakes/5
        [HttpDelete]
        [ResponseType(typeof(VehicleMake))]
        public async Task<IHttpActionResult> DeleteVehicleMake(int id)
        {
            
            VehicleMake make = await _vehicleService.GetMakeById(id);
            if (make == null)
            {
                return NotFound();
            }

            
            await _vehicleService.DeleteMake(id);         
            
            return  StatusCode(HttpStatusCode.NoContent);
        }

    
    

        
    }
}