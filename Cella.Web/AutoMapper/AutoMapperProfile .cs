using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cella.Models;

namespace WareHouseCrm.Web.AutoMapper {
    public class AutoMapperProfile : Profile{

        public AutoMapperProfile()
        {


            CreateMap<StockItemVm, Product>();

            CreateMap<Product, StockItemVm>();

        }
    }
}
