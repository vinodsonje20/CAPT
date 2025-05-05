using Infrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Models
{
    public class CheckStatus : IMasterEntity
    {
        public int CheckStatusId { get; set; }
        public string CheckStatusName { get; set; }
        public bool IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int GetId() => CheckStatusId;
        public string GetName() => CheckStatusName;
    }
}
