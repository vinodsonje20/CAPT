using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Interfaces
{
    public interface IMasterEntity
    {
        bool IsActive { get; set; }
        int? CreatedBy { get; set; }
        DateTime? CreatedDate { get; set; }
        int? ModifiedBy { get; set; }
        DateTime? ModifiedDate { get; set; }
        int GetId();
        string GetName();
    }
}
