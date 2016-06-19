using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DecisionTech.Data.Contracts
{
    public interface IDealRepository
    {
        JsonResult GetDeal();
    }
}
