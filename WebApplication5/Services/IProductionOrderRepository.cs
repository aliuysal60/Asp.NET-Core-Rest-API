using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Models;

namespace WebApplication5.Services
{
    public interface IProductionOrderRepository
    {
        ProductionOrder Add(ProductionOrder productionorder);
        IEnumerable<ProductionOrder> GetAll();
        ProductionOrder GetById(int id);
        void Delete(ProductionOrder productionorder);
        void Update(ProductionOrder productionorder);
    }

}
