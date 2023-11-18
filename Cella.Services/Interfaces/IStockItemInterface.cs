using Cella.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cella.BL.Interfaces
{
    public interface IStockItemInterface
    {

        void AddStockItem(StockItem stockItem);

        void UpdateStockItem(StockItem stockItem);
        bool DeleteStockItem(StockItem stockItem);
        Task<IEnumerable<StockItem>> GetStockItemById(int id);
        Task<IEnumerable<StockItem>> GetAllStockItems();

    }
}
