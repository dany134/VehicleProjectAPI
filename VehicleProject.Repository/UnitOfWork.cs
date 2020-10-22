using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleProject.DAL;
using VehicleProject.Models;
using VehicleProject.Repository.Common;
namespace VehicleProject.Repository
{
   public class UnitOfWork : IUnitOfWork
    {
        private readonly VehicleContext context;
       
        public UnitOfWork(VehicleContext Context)
        {
            context = Context ?? throw new ArgumentNullException(nameof(context)); 
            
        }
        
        

        public async Task Save()
        {
            
             await context.SaveChangesAsync();
            
            
           
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
