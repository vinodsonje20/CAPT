using Infrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Models
{
    public class DispositionType : IMasterEntity
    {
        public int DispositionTypeId { get; set; }
        public string DispositionTypeName { get; set; }
        public bool IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int GetId() => DispositionTypeId;
        public string GetName() => DispositionTypeName;
    }
}
