using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarket.Core.Entities;

namespace SuperMarket.Core.Interfaces
{
    public interface ISupplierRespository
    {
        Task<IEnumerable<SupplierEntity>> GetSupplierSync(string? Name);
        Task<SupplierEntity> AddSupplierAsync(SupplierEntity supplierEntity);
        Task<SupplierEntity> UpdateSupplierAsync(Guid SupplierId,SupplierEntity supplierEntity);
        Task<bool> DeleteSupplierAsync(Guid SupplierId);
    }
}
