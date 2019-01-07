using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Models;

namespace WebApplication5.Services
{
    public class InMemoryProductionOrderRepository : IProductionOrderRepository
    {
        private readonly ProductionOrdersAPIContext _context;


        public InMemoryProductionOrderRepository(ProductionOrdersAPIContext context)
        {
            _context = context;
        }


        public ProductionOrder Add(ProductionOrder productionorder)
        {
            var addedProductionOrder = _context.Add(productionorder);
            _context.SaveChanges();
            productionorder.Id = addedProductionOrder.Entity.Id;


            return productionorder;
        }


        public void Delete(ProductionOrder productionorder)
        {
            _context.Remove(productionorder);
            _context.SaveChanges();
        }


        public IEnumerable<ProductionOrder> GetAll()
        {
            return _context.ProductionOrders.ToList();
        }


        public ProductionOrder GetById(int id)
        {
            return _context.ProductionOrders.SingleOrDefault(x => x.Id == id);
        }


        public void Update(ProductionOrder productionorder)
        {
            var productionorderToUpdate = GetById(productionorder.Id);
            productionorderToUpdate.ProductionStockNo = productionorder.ProductionStockNo;
            productionorderToUpdate.OrderNo = productionorder.OrderNo;
            productionorderToUpdate.CreateDate = productionorder.CreateDate;
            _context.Update(productionorderToUpdate);
            _context.SaveChanges();
        }
    }


}
