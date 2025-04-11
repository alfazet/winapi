using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture2.Infrastucture
{
    public interface IBindable<TEntiy> where TEntiy: class
    {
        Task<bool> Bind(TEntiy bindContext);
        Task ClearBinding();
    }
}
