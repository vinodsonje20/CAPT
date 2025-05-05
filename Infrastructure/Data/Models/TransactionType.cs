using Infrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Models
{
    public class TransactionType : IMasterEntity
    {
        public int TransactionTypeId { get; set; }
        public string TransactionTypeName { get; set; }
        public bool IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int GetId() => TransactionTypeId;
        public string GetName() => TransactionTypeName;

    }
}
